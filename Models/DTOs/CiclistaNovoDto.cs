using System.ComponentModel.DataAnnotations;
using BikeRack.Validations;

namespace BikeRack.Models.DTOs
{
    public class CiclistaNovoDto: CiclistaDto
    {
        [Required(ErrorMessage = "Senha é um campo obrigatório")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Confirmar a senha é obrigatório")]
        [Compare("Senha", ErrorMessage = "Senhas não são idênticas")]
        public string ConfirmacaoSenha { get; set; }
    }
}
