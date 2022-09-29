namespace Application.Dtos.Destinations
{
    public class DestinationDto
    {
        public int DestinationId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
