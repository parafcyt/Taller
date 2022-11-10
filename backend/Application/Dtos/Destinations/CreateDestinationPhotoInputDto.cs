using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Destinations
{
    public class CreateDestinationPhotoInputDto
    {
        [Required]
        public string Url { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Required]
        public int DestinationId { get; set; }
    }
}
