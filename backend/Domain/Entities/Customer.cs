using Domain.BaseEntity;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Customer : Entity
    {
        public Customer()
        {
            Favorites = new HashSet<Favorite>();
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string CustomerSourceId { get; set; } = null!;
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Dni { get; set; }
        public string? Email { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? PhoneNumber { get; set; }
        public bool RegistrationCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte RegistrationMethodId { get; set; }

        public virtual RegistrationMethod RegistrationMethod { get; set; } = null!;
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
