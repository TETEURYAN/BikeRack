using BikeRack.Models;
using BikeRack.Models.DTOs;

namespace BikeRack.Interfaces
{
    public interface ICiclistaRepository
    {
        Task Add(Ciclista ciclista);
        Task<Ciclista> Update(int id, CiclistaDto ciclistaAtualizado);
        Task<Ciclista?> GetByIdAsync(int id);
        Task<Ciclista> Ativar(int id);
        Task<Ciclista> Desativar(int id);
        bool ExisteEmail(string email);
    }
}
