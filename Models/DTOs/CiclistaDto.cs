using BikeRack.Validations;
using System.ComponentModel.DataAnnotations;

namespace BikeRack.Models.DTOs
{
    public class CiclistaDto
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        public string Nome { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        public DateOnly nascimento { get; set; }

        [RegularExpression(@"(\d\d\d\d\d\d\d\d\d\d\d)?", ErrorMessage = "CPF inválido")]
        [CpfRequired]
        public string CPF { get; set; }

        [PassaporteRequired]
        public NovoPassaporteDto? Passaporte { get; set; }

        [Required(ErrorMessage = "Nacionalidade é um campo obrigatório")]
        [RegularExpression(@"(BRASILEIRO|ESTRANGEIRO)?", ErrorMessage = "Nacionalidade inválida")]
        public string Nacionalidade { get; set; }

        [Required(ErrorMessage = "Email é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Foto do documento é obrigatório")]
        [Url(ErrorMessage = "Foto inválida")]
        public string UrlFotoDocumento { get; set; }
    }
}
