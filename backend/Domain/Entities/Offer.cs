using Domain.BaseEntity;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Offer : Entity
    {
        public int OfferId { get; set; }
        public double OfferPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }
        public bool Active { get; set; }
        public string? BannerText { get; set; }
        public DateTime CreatedtDate { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
