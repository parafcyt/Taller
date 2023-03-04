using Domain.BaseEntity;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Hotel : Entity
    {
        public Hotel()
        {
            HotelPhotos = new HashSet<HotelPhoto>();
            Products = new HashSet<Product>();
        }

        public int HotelId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int DestinationId { get; set; }

        public virtual Destination Destination { get; set; } = null!;
        public virtual ICollection<HotelPhoto> HotelPhotos { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
