using Microsoft.EntityFrameworkCore;
using BikeRack.Data;
using BikeRack.Models;
using BikeRack.Repositories.Interfaces;

namespace BikeRack.Repositories;

public class FuncionarioRepository : IFuncionarioRepository
{
  private readonly AluguelContext _context;

  public FuncionarioRepository(AluguelContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Funcionario>> GetAllAsync()
  {
    return await _context.Funcionarios.ToListAsync();
  }

  public async Task<Funcionario?> GetByIdAsync(string matricula)
  {
    return await _context.Funcionarios.FindAsync(matricula);
  }

  public Funcionario Add(Funcionario funcionario)
  {
    _context.Funcionarios.Add(funcionario);
    _context.SaveChanges();
    return funcionario;
  }

  public Funcionario Update(Funcionario funcionario)
  {
    _context.Entry(funcionario).State = EntityState.Modified;
    _context.SaveChanges();
    return funcionario;
  }

  public void Delete(string matricula)
  {
   var funcionario = _context.Funcionarios.Find(matricula);
   if (funcionario != null)
   {
     _context.Funcionarios.Remove(funcionario);
     _context.SaveChanges();
   }
  }
}
