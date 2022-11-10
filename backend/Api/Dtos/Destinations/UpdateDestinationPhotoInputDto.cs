using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Destinations
{
    public class UpdateDestinationPhotoInputDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Url { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Required]
        public int DestinationId { get; set; }
    }
}
