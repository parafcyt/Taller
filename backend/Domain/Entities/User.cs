using Domain.BaseEntity;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class User : Entity
    {
        public int UserId { get; set; }
        public string LoginName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool Active { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
