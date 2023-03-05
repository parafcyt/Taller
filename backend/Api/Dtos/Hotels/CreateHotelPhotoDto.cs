using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Hotels
{
    public class CreateHotelPhotoDto
    {
        [Required]
        public string Url { get; set; }

        public string Description { get; set; }

        [Required]
        public int HotelId { get; set; }
    }
}
