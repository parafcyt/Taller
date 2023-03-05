using Domain.BaseEntity;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Order : Entity
    {
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public double? Discount { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte OrderStateId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public byte RatingScaleId { get; set; }
        public int PaymentId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual OrderState OrderState { get; set; } = null!;
        public virtual Payment Payment { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual RatingScale RatingScale { get; set; } = null!;
    }
}
