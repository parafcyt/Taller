using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class ProductTransport
    {
        public int ProductTransportId { get; set; }
        public byte Order { get; set; }
        public string? Information { get; set; }
        public int ProductId { get; set; }
        public int TransportId { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Transport Transport { get; set; } = null!;
    }
}
