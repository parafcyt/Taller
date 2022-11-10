using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Transports
{
    public class UpdateTransportInputDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
