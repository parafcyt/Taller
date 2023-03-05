using Domain.BaseEntity;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Payment : Entity
    {
        public Payment()
        {
            Orders = new HashSet<Order>();
        }

        public int PaymentId { get; set; }
        public int SourceId { get; set; }
        public DateTime CreatedtDate { get; set; }
        public DateTime ApprovedDate { get; set; }
        public string PaymentMethodId { get; set; } = null!;
        public string PaymentTypeId { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
