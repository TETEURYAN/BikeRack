using System.ComponentModel.DataAnnotations;

namespace BikeRack.Models.DTOs
{
    public class NovoCartaoDeCreditoDto
    {
        public required string NomeTitular { get; set; }
        public required string Numero { get; set; }
        public DateOnly Validade { get; set; }
        [Required]
        public required string Cvv { get; set; }
    }
}
