using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Hotels
{
    public class UpdateHotelInputDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Required]
        public int DestinationId { get; set; }
    }
}
