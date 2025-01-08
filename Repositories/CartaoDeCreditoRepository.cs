using BikeRack.Models;
using BikeRack.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using BikeRack.Data;

namespace BikeRack.Repositories
{
    public class CartaoDeCreditoRepository : ICartaoDeCreditoRepository
    {
        private readonly AluguelContext _context;

        public CartaoDeCreditoRepository(AluguelContext context)
        {
            _context = context;
        }

        public async Task<CartaoDeCredito?> GetByCiclistaIdAsync(int ciclistaId)
        {
            return await _context.CartoesDeCredito
                                 .FirstOrDefaultAsync(c => c.CiclistaId == ciclistaId);
        }

        public async Task UpdateAsync(CartaoDeCredito cartao)
        {
            _context.CartoesDeCredito.Update(cartao);
            await _context.SaveChangesAsync();
        }
    }
}
