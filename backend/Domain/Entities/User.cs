using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class User
    {
        public string UserId { get; set; } = null!;
        public bool State { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
    }
}
