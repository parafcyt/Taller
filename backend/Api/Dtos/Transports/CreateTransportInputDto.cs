using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Transports
{
    public class CreateTransportInputDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
