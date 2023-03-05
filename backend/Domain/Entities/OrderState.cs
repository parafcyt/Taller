using Domain.BaseEntity;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class OrderState : Entity
    {
        public OrderState()
        {
            Orders = new HashSet<Order>();
        }

        public byte OrderStateId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
