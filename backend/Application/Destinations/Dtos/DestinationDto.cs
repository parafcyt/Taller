
namespace Application.Destinations.Dtos
{
    public class DestinationDto
    {
        public int DestinationId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
