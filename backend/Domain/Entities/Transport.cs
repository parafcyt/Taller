using Domain.BaseEntity;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Transport : Entity
    {
        public Transport()
        {
            ProductTransports = new HashSet<ProductTransport>();
        }

        public int TransportId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ProductTransport> ProductTransports { get; set; }
    }
}
