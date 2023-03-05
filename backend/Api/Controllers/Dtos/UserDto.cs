using System.ComponentModel.DataAnnotations;

namespace Api.Controllers.Dtos
{
    //TODO: Se tiene que llamar CreateCustomerDto
    public class UserDto
    {
        public string? DisplayName { get; set; }

        [Required]
        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        [Required]
        public string Uid { get; set; }
    }
}
