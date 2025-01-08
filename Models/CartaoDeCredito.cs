namespace BikeRack.Models
{
    public class CartaoDeCredito
    {
        public int Id { get; set; }
        public string NomeTitular { get; set; }
        public string Numero { get; set; }
        public DateOnly Validade {  get; set; }
        public string Cvv { get; set; }
        public int CiclistaId { get; set; }
    }
}
