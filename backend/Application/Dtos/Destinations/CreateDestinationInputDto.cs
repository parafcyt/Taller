using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Destinations
{
    public class CreateDestinationInputDto
    {
        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}
