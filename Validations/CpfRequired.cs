using BikeRack.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace BikeRack.Validations
{
    public class CpfRequired : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var Ciclista = validationContext.ObjectInstance as CiclistaDto;
            if (Ciclista.Nacionalidade == "BRASILEIRO" && string.IsNullOrEmpty(value as string))
            {
                return new ValidationResult("CPF é obrigatório para brasileiros");
            }
            return ValidationResult.Success;
        }
    }
}
