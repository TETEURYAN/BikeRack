using BikeRack.Models;
using BikeRack.Services.Interfaces;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BikeRack.Services
{
    public class HttpService : IHttpService
    {
        public async Task<Bicicleta> GetBicicletaNaTranca(int idTranca)
        {
            //using (HttpClient httpClient = new HttpClient() { BaseAddress = new Uri("") })
            //{
            //    var response = await httpClient.GetFromJsonAsync<Bicicleta>($"/tranca/{idTranca}/bicicleta");
            //    return response;
            //}

            var response = new Bicicleta() { id=1};

            return response;
        }

        public async Task<bool> CobrarCartao(int idCiclista, double valor)
        {
            //using (HttpClient httpClient = new HttpClient() { BaseAddress = new Uri("") })
            //{
            //    string body = JsonSerializer.Serialize(new {valor = valor, ciclista = idCiclista});
            //    StringContent jsonContent = new StringContent(body, Encoding.UTF8, "application/json");
            //    var response = await httpClient.PostAsync("", jsonContent);
            //    if (response.StatusCode.ToString() == "OK")
            //    {
            //        return true;
            //    } else
            //    {
            //        return false;
            //    }
                
            //}

            return true;
        }

        public async Task<bool> DestrancarTranca(int idTranca, int? idBicicleta = null)
        {
            //using (HttpClient httpClient = new HttpClient() { BaseAddress = new Uri("") })
            //{
            //    string body;
            //    if (idBicicleta != null)
            //    {
            //       body  = JsonSerializer.Serialize(new { bicicleta = idBicicleta });
            //    }
            //    else
            //    {
            //        body = "";
            //    }
                
            //    StringContent jsonContent = new StringContent(body, Encoding.UTF8, "application/json");
            //    var response = await httpClient.PostAsync("", jsonContent);
            //    if (response.StatusCode.ToString() == "OK")
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }

            //}

            return true;
        }

        public async Task<bool> EnviarEmail(string email, string assunto, string mensagem)
        {
            //using (HttpClient httpClient = new HttpClient() { BaseAddress = new Uri("") })
            //{
            //    string body = JsonSerializer.Serialize(new { email = email, assunto = assunto, mensagem = mensagem});

            //    StringContent jsonContent = new StringContent(body, Encoding.UTF8, "application/json");
            //    var response = await httpClient.PostAsync("", jsonContent);
            //    if (response.StatusCode.ToString() == "OK")
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }

            //}

            return true;
        }
    }
}
