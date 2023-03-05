using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Destinations
{
    public class UpdateDestinationPhotoDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        public string Description { get; set; }

        [Required]
        public int DestinationId { get; set; }
    }
}
