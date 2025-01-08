using BikeRack.Models;

namespace BikeRack.Services.Interfaces
{
    public interface IHttpService
    {
        Task<Bicicleta> GetBicicletaNaTranca(int idTranca);
        Task<bool> CobrarCartao(int idCiclista, double valor);
        Task<bool> DestrancarTranca(int idTranca, int? idBicicleta = null);
        Task<bool> EnviarEmail(string email, string assunto, string mensagem);
    }
}
