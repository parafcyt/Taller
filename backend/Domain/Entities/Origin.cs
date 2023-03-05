using Domain.BaseEntity;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Origin : Entity
    {
        public Origin()
        {
            Products = new HashSet<Product>();
        }

        public int OriginId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
