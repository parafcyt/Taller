using Domain.BaseEntity;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class RegistrationMethod : Entity
    {
        public RegistrationMethod()
        {
            Customers = new HashSet<Customer>();
        }

        public byte RegistrationMethodId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
