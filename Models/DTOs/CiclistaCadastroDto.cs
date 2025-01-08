using System.ComponentModel.DataAnnotations;

namespace BikeRack.Models.DTOs
{
    public class CiclistaCadastroDto
    {
        [Required(ErrorMessage = "Dados do Ciclista são obrigatórios")]
        public CiclistaNovoDto? Ciclista { get; set; }
        [Required(ErrorMessage ="Dados do meio de pagamento são obrigatórios")]
        public NovoCartaoDeCreditoDto? MeioDePagamento { get; set; }

    }
}
