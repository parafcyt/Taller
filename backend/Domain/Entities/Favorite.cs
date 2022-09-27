using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Favorite
    {
        public int FavoriteId { get; set; }
        public int ProductId { get; set; }
        public string CustomerId { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
