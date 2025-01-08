using System.ComponentModel.DataAnnotations;

namespace BikeRack.Models.DTOs
{
    public class NovoPassaporteDto
    {
        [Required(ErrorMessage = "O numero do passaporte é obrigatório")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "A validade do passaporte é obrigatório")]
        public DateOnly Validade { get; set; }

        [Required(ErrorMessage = "O pais do passaporte é obrigatório")]
        public string Pais { get; set; }
    }
}
