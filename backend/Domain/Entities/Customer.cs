using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Favorites = new HashSet<Favorite>();
            Orders = new HashSet<Order>();
        }

        public string CustomerId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Dni { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
