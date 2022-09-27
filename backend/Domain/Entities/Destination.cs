using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Destination
    {
        public Destination()
        {
            DestinationPhotos = new HashSet<DestinationPhoto>();
            Excursions = new HashSet<Excursion>();
            Hotels = new HashSet<Hotel>();
            Products = new HashSet<Product>();
        }

        public int DestinationId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<DestinationPhoto> DestinationPhotos { get; set; }
        public virtual ICollection<Excursion> Excursions { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
