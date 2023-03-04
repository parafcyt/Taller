using Domain.BaseEntity;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class RatingScale : Entity
    {
        public RatingScale()
        {
            Orders = new HashSet<Order>();
        }

        public byte RatingScaleId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
