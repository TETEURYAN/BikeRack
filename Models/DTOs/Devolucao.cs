namespace BikeRack.Models.DTOs;

public class Devolucao
{
        public int bicicleta { get; set; }
        public DateTime horaInicio { get; set; }
        public int trancaFim { get; set; }
        public DateTime horaFim {  get; set; }
        public int cobranca {  get; set; }
        public int ciclista { get; set; }
}
