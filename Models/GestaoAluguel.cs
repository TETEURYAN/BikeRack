namespace BikeRack.Models;
public class GestaoAluguel
{
    public int Id { get; set; }
    public int Bicicleta { get; set; }
    public DateTime HoraInicio { get; set; }
    public int? TrancaFim { get; set; }
    public DateTime? HoraFim { get; set; }
    public decimal? Cobranca { get; set; }
    public int Ciclista { get; set; }
    public int TrancaInicio { get; set; }
    public int CartaoDeCredito {  get; set; }
    
}
