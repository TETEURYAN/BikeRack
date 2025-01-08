using BikeRack.Data;
using BikeRack.Models;
using BikeRack.Repositories.Interfaces;

namespace BikeRack.Repositories
{
    public class GestaoAluguelRepository : IGestaoAluguelRepository
    {
        private readonly AluguelContext _context;

        public GestaoAluguelRepository(AluguelContext context)
        {
            _context = context;
        }

        public async Task<GestaoAluguel> Add(int idCiclista, int trancaInicio, int idBicicleta, int idCartao)
        {
            GestaoAluguel novoAluguel = new GestaoAluguel()
            {
                Ciclista = idCiclista,
                TrancaInicio = trancaInicio,
                Cobranca = 10,
                Bicicleta = idBicicleta,
                CartaoDeCredito = idCartao,
                HoraInicio = DateTime.UtcNow
            };
            _context.GestaoAluguel.Add(novoAluguel);
            await _context.SaveChangesAsync();
            return novoAluguel;
        }

        public bool PermiteAluguel(int idCiclista)
        {

            GestaoAluguel? aluguel = _context.GestaoAluguel
                        .Where(a => a.Ciclista == idCiclista && a.TrancaFim == null)
                        .FirstOrDefault();
            if (aluguel == null)
            {
                return true;
            } else
            {
                return false;
            }

        }

        public async Task<GestaoAluguel?> GetAluguelAtivoPorCiclistaAsync(int idCiclista)
        {
            return await Task.FromResult(
            _context.GestaoAluguel
            .Where(a => a.Ciclista == idCiclista && a.TrancaFim == null)
            .FirstOrDefault()
            );
        }

        public async Task FinalizarAluguelAsync(GestaoAluguel aluguel)
        {
            _context.GestaoAluguel.Update(aluguel);
            await _context.SaveChangesAsync();
        }

    }
}
