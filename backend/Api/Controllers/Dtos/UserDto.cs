using System.ComponentModel.DataAnnotations;

namespace Api.Controllers.Dtos
{
    public class UserDto
    {
        public string? DisplayName { get; set; }

        [Required]
        public string Email { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        [Required]
        public string Uid { get; set; } = null!;
    }
}
