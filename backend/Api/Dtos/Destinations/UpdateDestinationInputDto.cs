namespace Api.Dtos.Destinations
{
    public class UpdateDestinationInputDto
    {
        public int DestinationId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
