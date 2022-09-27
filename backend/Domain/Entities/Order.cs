using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public double UnitPricePaid { get; set; }
        public double Total { get; set; }
        public DateTime DateOrder { get; set; }
        public bool? State { get; set; }
        public int ProductId { get; set; }
        public string CustomerId { get; set; } = null!;
        public byte? RatingScaleId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual RatingScale? RatingScale { get; set; }
    }
}
