namespace BikeRack.Models
{
    public class Passaporte
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateOnly Validade {  get; set; }
        public string Pais { get; set; }
        public int CiclistaId { get; set; }
    }
}
