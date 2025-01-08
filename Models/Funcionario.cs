using System.ComponentModel.DataAnnotations;

namespace BikeRack.Models 
{
  public class Funcionario
  {
    [Key]
    public string Matricula { get; set; }
    public string Senha { get; set; }
    [Required] [Compare("Senha")]
    public string ConfirmacaoSenha { get; set; }
    public string Email { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Funcao { get; set; }
    public string CPF { get; set; }
  }
}