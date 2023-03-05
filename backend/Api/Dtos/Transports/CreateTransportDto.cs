using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Transports
{
    public class CreateTransportDto
    {
        [Required]
        public string Name { get; set; }
    }
}
