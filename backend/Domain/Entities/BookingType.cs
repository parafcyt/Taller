using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class BookingType
    {
        public BookingType()
        {
            Products = new HashSet<Product>();
        }

        public byte BookingTypeId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
