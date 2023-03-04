using Domain.BaseEntity;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Excursion : Entity
    {
        public Excursion()
        {
            ProductExcursions = new HashSet<ProductExcursion>();
        }

        public int ExcursionId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int DestinationId { get; set; }

        public virtual Destination Destination { get; set; } = null!;
        public virtual ICollection<ProductExcursion> ProductExcursions { get; set; }
    }
}
