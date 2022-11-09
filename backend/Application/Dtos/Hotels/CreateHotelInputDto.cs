using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Hotels
{
    public class CreateHotelInputDto
    {
        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        public int DestinationId { get; set; }
    }
}
