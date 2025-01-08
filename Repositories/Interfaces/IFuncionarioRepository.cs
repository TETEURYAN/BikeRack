using BikeRack.Models;

namespace BikeRack.Repositories.Interfaces;

public interface IFuncionarioRepository
{
  Task<IEnumerable<Funcionario>> GetAllAsync();
  Task<Funcionario?> GetByIdAsync(string matricula);
  Funcionario Add(Funcionario funcionario);
  Funcionario Update(Funcionario funcionario);
  void Delete(string matricula);
}
