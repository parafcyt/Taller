using Domain.BaseEntity;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class ProductExcursion : Entity
    {
        public int ProductExcursionId { get; set; }
        public int ProductId { get; set; }
        public int ExcursionId { get; set; }

        public virtual Excursion Excursion { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
