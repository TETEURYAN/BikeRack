using BikeRack.Models.DTOs;

namespace BikeRack.Models
{
    public class CiclistaResponseDto: CiclistaDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
