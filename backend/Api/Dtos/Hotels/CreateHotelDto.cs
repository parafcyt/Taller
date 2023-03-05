using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Hotels
{
    public class CreateHotelDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int DestinationId { get; set; }
    }
}
