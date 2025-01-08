namespace BikeRack.Models
{
    public class Ciclista
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Nome { get; set; }
        public DateOnly nascimento { get; set; }
        public string CPF {  get; set; }
        public string Nacionalidade { get; set; }
        public string Email { get; set; }
        public string UrlFotoDocumento { get; set; }
        public string Senha {  get; set; }
        public Passaporte Passaporte { get; set; }
        public CartaoDeCredito CartaoDeCredito { get; set; }
    }
}
