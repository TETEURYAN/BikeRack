using Microsoft.AspNetCore.Mvc;
using BikeRack.Interfaces;
using BikeRack.Models;
using BikeRack.Models.DTOs;
using BikeRack.Repositories.Interfaces;

namespace BikeRack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CiclistaController : Controller
    {
        private readonly ICiclistaRepository _iCiclistaRepository;
        private readonly IGestaoAluguelRepository _iGestaoAluguelRepository;

        public CiclistaController(ICiclistaRepository ciclistaRepository, IGestaoAluguelRepository gestaoAluguelRepository)
        {
            _iCiclistaRepository = ciclistaRepository;
            _iGestaoAluguelRepository = gestaoAluguelRepository;
        }

        [HttpPost]
        public async Task<ActionResult<CiclistaResponseDto>> Post(CiclistaCadastroDto request)
        {
            if (!ModelState.IsValid)
            {
                List<Erro> LstErros = [];
                foreach (var campos in ModelState.Values)
                {
                    foreach (var erro in campos.Errors)
                    {
                        LstErros.Add(new Erro { Codigo = "422", Mensagem = erro.ErrorMessage });
                    }
                }
                return UnprocessableEntity(LstErros);
            }

            //
            //
            // Inserir aqui a validação de cartão de crédito na fase de integração
            //
            //

            CartaoDeCredito novoCartao = new CartaoDeCredito
            {
                NomeTitular = request.MeioDePagamento.NomeTitular,
                Numero = request.MeioDePagamento.Numero,
                Validade = request.MeioDePagamento.Validade,
                Cvv = request.MeioDePagamento.Cvv,
            };

            Passaporte? passaporte;
            if (request.Ciclista.Passaporte != null)
            {
                passaporte = new Passaporte();
                passaporte.Numero = request.Ciclista.Passaporte.Numero;
                passaporte.Validade = request.Ciclista.Passaporte.Validade;
                passaporte.Pais = request.Ciclista.Passaporte.Pais;
            } else
            {
                passaporte = null;
            }


            Ciclista novoCiclista = new Ciclista
            {
                Nome = request.Ciclista.Nome,
                nascimento = request.Ciclista.nascimento,
                CPF = request.Ciclista.CPF,
                Nacionalidade = request.Ciclista.Nacionalidade.ToUpper(),
                Email = request.Ciclista.Email,
                UrlFotoDocumento = request.Ciclista.UrlFotoDocumento,
                Senha = request.Ciclista.Senha,
                Passaporte = passaporte,
                CartaoDeCredito = novoCartao
            };

            await _iCiclistaRepository.Add(novoCiclista);


            CiclistaResponseDto resulCiclista = new CiclistaResponseDto
            {
                Id = novoCiclista.Id,
                Status = novoCiclista.Status,
                Nome = novoCiclista.Nome,
                nascimento = novoCiclista.nascimento,
                CPF = novoCiclista.CPF,
                Passaporte = new NovoPassaporteDto { Numero = novoCiclista.Passaporte.Numero,
                Validade = novoCiclista.Passaporte.Validade,
                Pais = novoCiclista.Passaporte.Pais},
                Nacionalidade = novoCiclista.Nacionalidade,
                Email = novoCiclista.Email,
                UrlFotoDocumento = novoCiclista.UrlFotoDocumento
            };

            //
            //
            // Inserir aqui o envio de e-mail na fase de integração
            //
            //

            return Ok(resulCiclista);
        }

        [HttpGet("/[controller]/{idCiclista}")]
        public async Task<ActionResult<CiclistaResponseDto>> Get(int idCiclista)
        {
            Ciclista ciclista = await _iCiclistaRepository.GetByIdAsync(idCiclista);

            if (ciclista == null) {
                return NotFound(new Erro { Codigo = "404", Mensagem="Ciclista não encontrado"});
            }

            CiclistaResponseDto ciclistaResponse = new CiclistaResponseDto
            {
                Id = ciclista.Id,
                Status = ciclista.Status,
                Nome = ciclista.Nome,
                nascimento = ciclista.nascimento,
                CPF = ciclista.CPF,
                Passaporte = new NovoPassaporteDto { Numero = ciclista.Passaporte.Numero,
                    Validade = ciclista.Passaporte.Validade,
                    Pais = ciclista.Passaporte.Pais
                },
                Nacionalidade = ciclista.Nacionalidade,
                Email = ciclista.Email,
                UrlFotoDocumento = ciclista.UrlFotoDocumento
            };

            return Ok(ciclistaResponse);
        }

        [HttpPut("/[controller]/{idCiclista}")]
        public async Task<ActionResult<CiclistaResponseDto>> Put(int idCiclista, CiclistaDto ciclistaAtualizado)
        {
            if (!ModelState.IsValid)
            {
                List<Erro> LstErros = [];
                foreach (var campos in ModelState.Values)
                {
                    foreach (var erro in campos.Errors)
                    {
                        LstErros.Add(new Erro { Codigo = "422", Mensagem = erro.ErrorMessage });
                    }
                }
                return UnprocessableEntity(LstErros);
            }

            Ciclista ciclista = await _iCiclistaRepository.Update(idCiclista, ciclistaAtualizado);

            if (ciclista == null)
            {
                return NotFound(new Erro { Codigo = "404", Mensagem = "Ciclista não encontrado" });
            }

            CiclistaResponseDto ciclistaResponse = new CiclistaResponseDto
            {
                Id = ciclista.Id,
                Status = ciclista.Status,
                Nome = ciclista.Nome,
                nascimento = ciclista.nascimento,
                CPF = ciclista.CPF,
                Passaporte = new NovoPassaporteDto { Numero = ciclista.Passaporte.Numero,
                    Validade = ciclista.Passaporte.Validade,
                    Pais = ciclista.Passaporte.Pais
                },
                Nacionalidade = ciclista.Nacionalidade,
                Email = ciclista.Email,
                UrlFotoDocumento = ciclista.UrlFotoDocumento
            };

            return Ok(ciclistaResponse);
        }


        [HttpPost("/[controller]/{idCiclista}/ativar")]
        public async Task<ActionResult<CiclistaResponseDto>> Ativar(int idCiclista)
        {
            Ciclista ciclista = await _iCiclistaRepository.Ativar(idCiclista);

            if (ciclista == null)
            {
                return NotFound(new Erro { Codigo = "404", Mensagem = "Ciclista não encontrado" });
            }

            CiclistaResponseDto ciclistaResponse = new CiclistaResponseDto
            {
                Id = ciclista.Id,
                Status = ciclista.Status,
                Nome = ciclista.Nome,
                nascimento = ciclista.nascimento,
                CPF = ciclista.CPF,
                Passaporte = new NovoPassaporteDto { Numero = ciclista.Passaporte.Numero,
                    Validade = ciclista.Passaporte.Validade,
                    Pais = ciclista.Passaporte.Pais
                },
                Nacionalidade = ciclista.Nacionalidade,
                Email = ciclista.Email,
                UrlFotoDocumento = ciclista.UrlFotoDocumento
            };

            return Ok(ciclistaResponse);
        }

        [HttpGet("/[controller]/existeEmail/{email}")]
        public IActionResult ExisteEmail(string email)
        {
            if (email == null)
            {
                return BadRequest("Email não enviado como parâmetro");
            }

            bool existeEmail = _iCiclistaRepository.ExisteEmail(email);

            return Ok(existeEmail);
        }

        [HttpGet("/[controller]/{idCiclista}/permiteAluguel")]
        public async Task<ActionResult<bool>> permiteAluguel(int idCiclista)
        {
            Ciclista? ciclista = await _iCiclistaRepository.GetByIdAsync(idCiclista);

            if (ciclista == null)
            {
                return NotFound(new Erro { Codigo = "404", Mensagem="Ciclista não encontrado"});
            }

            if (ciclista.Status != "ATIVO")
            {
                return false;
            }

            bool permiteAluguel = _iGestaoAluguelRepository.PermiteAluguel(idCiclista);
            return Ok(permiteAluguel);
        }
    }
}
