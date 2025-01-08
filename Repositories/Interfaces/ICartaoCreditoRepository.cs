using BikeRack.Models;

namespace BikeRack.Repositories.Interfaces
{
    public interface ICartaoDeCreditoRepository
    {
        Task<CartaoDeCredito?> GetByCiclistaIdAsync(int ciclistaId);
        Task UpdateAsync(CartaoDeCredito cartao);
    }
}
