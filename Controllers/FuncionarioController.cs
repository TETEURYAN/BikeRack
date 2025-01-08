using Microsoft.AspNetCore.Mvc;
using BikeRack.Interfaces;
using BikeRack.Models;
using BikeRack.Models.DTOs;
using BikeRack.Repositories.Interfaces;

namespace BikeRack.Controllers;
[ApiController]
[Route("[controller]")]
public class FuncionarioController : Controller
{
  private readonly IFuncionarioRepository _ifuncionarioRepository;

  public FuncionarioController(IFuncionarioRepository ifuncionarioRepository)
  {
    _ifuncionarioRepository = ifuncionarioRepository;
  }
  [HttpGet]
  public async Task<ActionResult<List<Funcionario>>> Get()
  {
    var funcionarios = await _ifuncionarioRepository.GetAllAsync();
    if (funcionarios == null || !funcionarios.Any())
    {
        return NoContent();
    }
    return Ok(funcionarios);
  }

  [HttpGet("{idFuncionario}")]
  public async Task<ActionResult<Funcionario>> Get(string idFuncionario)
  {
    var funcionario = await _ifuncionarioRepository.GetByIdAsync(idFuncionario);
    if (funcionario == null)
    {
        var erro = new Erro
        {
            Codigo = "404",
            Mensagem = $"Funcionário com o ID '{idFuncionario}' não foi encontrado."
        };

        return NotFound(erro); 
    }
    return Ok(funcionario); 
   }
  

 [HttpPost]
public ActionResult<Funcionario> Post(NovoFuncionario novoFuncionario)
{
     var errosDeValidacao = ValidarNovoFuncionario(novoFuncionario);

     if (errosDeValidacao.Any())
     {
        return UnprocessableEntity(errosDeValidacao);
     }

    var funcionario = new Funcionario
    {
        Matricula = Guid.NewGuid().ToString(),
        Senha = novoFuncionario.Senha,
        ConfirmacaoSenha = novoFuncionario.ConfirmacaoSenha,
        Email = novoFuncionario.Email,
        Nome = novoFuncionario.Nome,
        Idade = novoFuncionario.Idade,
        Funcao = novoFuncionario.Funcao,
        CPF = novoFuncionario.CPF
    };

    _ifuncionarioRepository.Add(funcionario);

    return StatusCode(201, funcionario);
}

[HttpPut("{idFuncionario}")]
public async Task<ActionResult<Funcionario>> Put(string idFuncionario, NovoFuncionario novoFuncionario)
{
    var errosDeValidacao = ValidarNovoFuncionario(novoFuncionario);

    if (errosDeValidacao.Any())
    {
        return UnprocessableEntity(errosDeValidacao);
    }

    var funcionarioExistente = await _ifuncionarioRepository.GetByIdAsync(idFuncionario);

    if (funcionarioExistente == null)
    {
        var erro = new Erro
        {
            Codigo = "404",
            Mensagem = $"Funcionário com o ID '{idFuncionario}' não foi encontrado."
        };
        return NotFound(erro);
    }

    funcionarioExistente.Nome = novoFuncionario.Nome;
    funcionarioExistente.Email = novoFuncionario.Email;
    funcionarioExistente.Idade = novoFuncionario.Idade;
    funcionarioExistente.Funcao = novoFuncionario.Funcao;
    funcionarioExistente.CPF = novoFuncionario.CPF;
    funcionarioExistente.Senha = novoFuncionario.Senha;
    funcionarioExistente.ConfirmacaoSenha = novoFuncionario.ConfirmacaoSenha;

    _ifuncionarioRepository.Update(funcionarioExistente);

    return Ok(funcionarioExistente);
}

 [HttpDelete("{idFuncionario}")]
public async Task<ActionResult<Funcionario>> Delete(string idFuncionario)
{
    var funcionario = _ifuncionarioRepository.GetByIdAsync(idFuncionario).Result;
    if (funcionario == null)
    {
        var erro = new Erro
        {
            Codigo = "404",
            Mensagem = $"Funcionário com o ID '{idFuncionario}' não foi encontrado."
        };
        return NotFound(erro); 
    }
    _ifuncionarioRepository.Delete(idFuncionario);
    return NoContent();
}
private List<Erro> ValidarNovoFuncionario(NovoFuncionario novoFuncionario)
{
    var erros = new List<Erro>();

    if (novoFuncionario == null)
    {
        erros.Add(new Erro
        {
            Codigo = "422",
            Mensagem = "O corpo da requisição não pode ser nulo."
        });
        return erros;
    }

    if (string.IsNullOrWhiteSpace(novoFuncionario.Senha))
    {
        erros.Add(new Erro
        {
            Codigo = "422",
            Mensagem = "O campo 'senha' é obrigatório."
        });
    }

    if (string.IsNullOrWhiteSpace(novoFuncionario.ConfirmacaoSenha))
    {
        erros.Add(new Erro
        {
            Codigo = "422",
            Mensagem = "O campo 'confirmacaoSenha' é obrigatório."
        });
    }

    if (!string.Equals(novoFuncionario.Senha, novoFuncionario.ConfirmacaoSenha))
    {
        erros.Add(new Erro
        {
            Codigo = "422",
            Mensagem = "A senha e a confirmação de senha devem ser iguais."
        });
    }

    if (string.IsNullOrWhiteSpace(novoFuncionario.Email))
    {
        erros.Add(new Erro
        {
            Codigo = "422",
            Mensagem = "O campo 'email' é obrigatório."
        });
    }

    if (string.IsNullOrWhiteSpace(novoFuncionario.Nome))
    {
        erros.Add(new Erro
        {
            Codigo = "422",
            Mensagem = "O campo 'nome' é obrigatório."
        });
    }

    if (novoFuncionario.Idade <= 0)
    {
        erros.Add(new Erro
        {
            Codigo = "422",
            Mensagem = "O campo 'idade' deve ser maior que zero."
        });
    }

    if (string.IsNullOrWhiteSpace(novoFuncionario.CPF))
    {
        erros.Add(new Erro
        {
            Codigo = "422",
            Mensagem = "O campo 'cpf' é obrigatório."
        });
    }

    if (!new[] { "administrativo", "reparador" }.Contains(novoFuncionario.Funcao.ToLower()))
        {
            erros.Add(new Erro
            {
                Codigo = "422",
                Mensagem = "A função deve ser 'administrativo' ou 'reparador'."
            });
        }

    return erros;
}
}
