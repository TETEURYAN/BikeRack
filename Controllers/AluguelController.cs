using Microsoft.AspNetCore.Mvc;
using BikeRack.Interfaces;
using BikeRack.Models;
using BikeRack.Models.DTOs;
using BikeRack.Repositories;
using BikeRack.Repositories.Interfaces;
using BikeRack.Services.Interfaces;

namespace BikeRack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AluguelController : Controller
    {
        private readonly IHttpService _httpService;
        private readonly IGestaoAluguelRepository _gestaoAluguelRepository;
        private readonly ICiclistaRepository _ciclistaRepository;

        public AluguelController(IHttpService httpService, 
                                IGestaoAluguelRepository gestaoAluguelRepository, 
                                ICiclistaRepository ciclistaRepository) 
        { 
            _httpService = httpService;
            _gestaoAluguelRepository = gestaoAluguelRepository;
            _ciclistaRepository = ciclistaRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Aluguel>> Aluguel(NovoAluguel novoAluguel)
        {
            Ciclista? ciclista = await _ciclistaRepository.GetByIdAsync(novoAluguel.ciclista);
            if (ciclista == null)
            {
                return NotFound(new Erro() { Codigo = "404", Mensagem = "Ciclista não encontrado"});
            }

            Bicicleta bicicleta = await _httpService.GetBicicletaNaTranca(novoAluguel.trancaInicio);
            if (bicicleta.erro != null)
            {
                return UnprocessableEntity(new Erro() { Codigo = bicicleta.erro, Mensagem = bicicleta.mensagem});
            }

            bool confirmacaoCobranca = await _httpService.CobrarCartao(novoAluguel.ciclista, 10);
            if(confirmacaoCobranca == false)
            {
                return UnprocessableEntity(new Erro() { Codigo = "422", Mensagem = "Cobrança ao cartão de crédito falhou" });
            }

            GestaoAluguel? aluguelCriado =  await _gestaoAluguelRepository.Add(novoAluguel.ciclista,
                novoAluguel.trancaInicio,
                bicicleta.id
                ,ciclista.CartaoDeCredito.Id);

            await _httpService.DestrancarTranca(novoAluguel.trancaInicio, bicicleta.id);


            string emailMensagem = $"Olá, {ciclista.Nome}! Obrigado por alugar uma bicicleta com conosco! Segue os detalhes do seu aluguel: \n" +
                $"Horário da retirada: {aluguelCriado.HoraInicio}\n" +
                $"Totem de retirada: {aluguelCriado.TrancaInicio}\n" +
                $"Valor cobrado: {aluguelCriado.Cobranca}";
            await _httpService.EnviarEmail(ciclista.Email, $"{ciclista.Nome} alugou uma nova bicicleta!", emailMensagem);
            return Ok(aluguelCriado);
        }
        [HttpPost("/devolucao")]
        public async Task<ActionResult<Devolucao>> Devolucao(NovoDevolucao novoDevolucao)
        {
            var ciclista = await _ciclistaRepository.GetByIdAsync(novoDevolucao.Ciclista);
            if (ciclista == null)
            {
                return NotFound(new Erro { Codigo = "404", Mensagem = "Ciclista não encontrado" });
            }

            var aluguelAtivo = await _gestaoAluguelRepository.GetAluguelAtivoPorCiclistaAsync(novoDevolucao.Ciclista);
            if (aluguelAtivo == null || aluguelAtivo.Bicicleta == 0)
            {
                return UnprocessableEntity(new Erro { Codigo = "422", Mensagem = "Nenhum aluguel ativo encontrado para o ciclista" });
            }

            bool destrancada = await _httpService.DestrancarTranca(novoDevolucao.TrancaFim);
            if (!destrancada)
            {
                return UnprocessableEntity(new Erro { Codigo = "422", Mensagem = "Erro ao destrancar a tranca de devolução" });
            }

            double duracaoHoras = (DateTime.UtcNow - aluguelAtivo.HoraInicio).TotalHours;
            decimal valorExtra = duracaoHoras > 2 ? (decimal)((Math.Ceiling(duracaoHoras - 2) * 2) * 5) : 0;

            if (valorExtra > 0)
            {
                bool cobrancaRealizada = await _httpService.CobrarCartao(novoDevolucao.Ciclista, (double)valorExtra);
                if (!cobrancaRealizada)
                {
                    return UnprocessableEntity(new Erro { Codigo = "422", Mensagem = "Cobrança adicional não autorizada" });
                }
            }

            aluguelAtivo.HoraFim = DateTime.UtcNow;
            aluguelAtivo.TrancaFim = novoDevolucao.TrancaFim;
            aluguelAtivo.Cobranca += valorExtra;

            await _gestaoAluguelRepository.FinalizarAluguelAsync(aluguelAtivo);

            string mensagem = $"Olá, {ciclista.Nome}! Segue os detalhes da devolução da bicicleta: \n" +
                            $"Horário de início: {aluguelAtivo.HoraInicio}\n" +
                            $"Horário de término: {aluguelAtivo.HoraFim}\n" +
                            $"Totem de devolução: {aluguelAtivo.TrancaFim}\n" +
                            $"Valor total: {aluguelAtivo.Cobranca:C}";
            await _httpService.EnviarEmail(ciclista.Email, "Devolução de Bicicleta Realizada!", mensagem);

            var devolucaoDto = new Devolucao
            {
                bicicleta = aluguelAtivo.Bicicleta,
                horaInicio = aluguelAtivo.HoraInicio,
                trancaFim = (int)aluguelAtivo.TrancaFim,
                horaFim = (DateTime)aluguelAtivo.HoraFim,
                cobranca = (int)(aluguelAtivo.Cobranca ?? 0),
                ciclista = aluguelAtivo.Ciclista
            };

            return Ok(devolucaoDto); 
        }

    }
}
