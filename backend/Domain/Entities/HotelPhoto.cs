using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class HotelPhoto
    {
        public int HotelPhotoId { get; set; }
        public string Url { get; set; } = null!;
        public string? Description { get; set; }
        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; } = null!;
    }
}
