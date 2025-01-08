using BikeRack.Models;

namespace BikeRack.Repositories.Interfaces
{
    public interface IGestaoAluguelRepository
    {
        bool PermiteAluguel(int idCiclista);
        Task<GestaoAluguel> Add(int idCiclista, int trancaInicio, int idBicicleta, int idCartao);
        Task<GestaoAluguel?> GetAluguelAtivoPorCiclistaAsync(int idCiclista);
        Task FinalizarAluguelAsync(GestaoAluguel aluguel); 
    }
}

