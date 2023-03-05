using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Transports
{
    public class UpdateTransportDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
