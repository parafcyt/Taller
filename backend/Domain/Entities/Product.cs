using Domain.BaseEntity;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Product : Entity
    {
        public Product()
        {
            Favorites = new HashSet<Favorite>();
            Offers = new HashSet<Offer>();
            Orders = new HashSet<Order>();
            ProductExcursions = new HashSet<ProductExcursion>();
            ProductTransports = new HashSet<ProductTransport>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string? DocumentationDes { get; set; }
        public bool State { get; set; }
        public byte BookingTypeId { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
        public int HotelId { get; set; }

        public virtual BookingType BookingType { get; set; } = null!;
        public virtual Destination Destination { get; set; } = null!;
        public virtual Hotel Hotel { get; set; } = null!;
        public virtual Origin Origin { get; set; } = null!;
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductExcursion> ProductExcursions { get; set; }
        public virtual ICollection<ProductTransport> ProductTransports { get; set; }
    }
}
