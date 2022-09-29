using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Destinations
{
    public class InputDestinationDto
    {
        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}
