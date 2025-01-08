using BikeRack.Models;
using BikeRack.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace BikeRack.Validations
{
    public class PassaporteRequired : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var Ciclista = validationContext.ObjectInstance as CiclistaDto;
            var passaporte = value as NovoPassaporteDto;
            if (Ciclista.Nacionalidade == "ESTRANGEIRO" && passaporte is null)
            {
                return new ValidationResult("Passaporte é obrigatório para estrangeiros");
            }
            return ValidationResult.Success;
        }
    }
}
