using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Destinations
{
    public class CreateDestinationDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
