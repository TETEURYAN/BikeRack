using Microsoft.EntityFrameworkCore;
using BikeRack.Data;
using BikeRack.Interfaces;
using BikeRack.Models;
using BikeRack.Models.DTOs;

namespace BikeRack.Repositories
{
    public class CiclistaRepository : ICiclistaRepository
    {
        private readonly AluguelContext _context;

        public CiclistaRepository(AluguelContext context)
        {
            _context = context;
        }
        public async Task Add(Ciclista ciclista)
        {
            ciclista.Status = "AGUARDANDO_CONFIRMACAO";
            _context.Ciclistas.Add(ciclista);
            await _context.SaveChangesAsync();
        }

        public async Task<Ciclista> Ativar(int id)
        {
            var ciclista = await GetByIdAsync(id);
            if (ciclista == null)
            {
                return null;
            }
            ciclista.Status = "ATIVO";
            await _context.SaveChangesAsync();
            return ciclista;
        }

        public async Task<Ciclista> Desativar(int id)
        {
            var ciclista = await _context.Ciclistas.FindAsync(id);
            if (ciclista == null)
            {
                return null;
            }
            ciclista.Status = "INATIVO";
            await _context.SaveChangesAsync();
            return ciclista;
        }

        public bool ExisteEmail(string email)
        {
            Ciclista? ciclista = _context.Ciclistas
                                    .Where(c => c.Email == email)
                                    .FirstOrDefault();
            if (ciclista == null)
            {
                return false;
            } else
            {
                return true;
            }
        }

        public async Task<Ciclista?> GetByIdAsync(int id)
        {
            return await _context.Ciclistas
                    .Include(c => c.CartaoDeCredito)
                    .Include(c => c.Passaporte)
                    .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Ciclista> Update(int id, CiclistaDto ciclistaAtualizado)
        {
            var ciclista = await GetByIdAsync(id);
            if (ciclista == null)
            {
                return null;
            }
            ciclista.Nome = ciclistaAtualizado.Nome;
            ciclista.nascimento = ciclistaAtualizado.nascimento;
            ciclista.CPF = ciclistaAtualizado.CPF;
            ciclista.Passaporte = new Passaporte
            {
                Numero = ciclista.Passaporte.Numero,
                Validade = ciclista.Passaporte.Validade,
                Pais = ciclista.Passaporte.Pais
            };
            ciclista.Nacionalidade = ciclistaAtualizado.Nacionalidade;
            ciclista.Email = ciclistaAtualizado.Email;
            ciclista.UrlFotoDocumento = ciclistaAtualizado.UrlFotoDocumento;
            await _context.SaveChangesAsync();
            return ciclista;

        }
    }
}
