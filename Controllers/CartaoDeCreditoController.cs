using Microsoft.AspNetCore.Mvc;
using BikeRack.Interfaces;
using BikeRack.Models;
using BikeRack.Models.DTOs;
using BikeRack.Repositories.Interfaces;

namespace BikeRack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartaoDeCreditoController : Controller
    {
        private readonly ICartaoDeCreditoRepository _cartaoDeCreditoRepository;

        public CartaoDeCreditoController(ICartaoDeCreditoRepository cartaoDeCreditoRepository)
        {
            _cartaoDeCreditoRepository = cartaoDeCreditoRepository;
        }

        [HttpGet("/cartaoDeCredito/{idCiclista}")]
        public async Task<ActionResult<CartaoDeCredito>> Get(int idCiclista)
        {
            var cartao = await _cartaoDeCreditoRepository.GetByCiclistaIdAsync(idCiclista);

            if (cartao == null)
            {
                return NotFound(new { Codigo = "404", Mensagem = "Cartão de crédito não encontrado" });
            }

            if (string.IsNullOrEmpty(cartao.Numero) || string.IsNullOrEmpty(cartao.Cvv) || cartao.Validade < DateOnly.FromDateTime(DateTime.Now))
            {
                return StatusCode(402, new { Codigo = "402", Mensagem = "Dados do cartão inválidos" });
            }

            return Ok(cartao);
        }

        [HttpPut("/cartaoDeCredito/{idCiclista}")]
        public async Task<ActionResult<CartaoDeCredito>> Put(int idCiclista, [FromBody] NovoCartaoDeCreditoDto cartaoAtualizado)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => new { Codigo = "422", Mensagem = e.ErrorMessage }));
            }

            var cartao = await _cartaoDeCreditoRepository.GetByCiclistaIdAsync(idCiclista);

            if (cartao == null)
            {
                return NotFound(new { Codigo = "404", Mensagem = "Cartão de crédito não encontrado" });
            }

            cartao.NomeTitular = cartaoAtualizado.NomeTitular;
            cartao.Numero = cartaoAtualizado.Numero;
            cartao.Validade = cartaoAtualizado.Validade;
            cartao.Cvv = cartaoAtualizado.Cvv;

            await _cartaoDeCreditoRepository.UpdateAsync(cartao);

            return Ok(cartao);
        }
    }
}
