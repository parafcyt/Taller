using Domain.BaseEntity;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class DestinationPhoto : Entity
    {
        public int DestinationPhotoId { get; set; }
        public string Url { get; set; } = null!;
        public string? Description { get; set; }
        public int DestinationId { get; set; }

        public virtual Destination Destination { get; set; } = null!;
    }
}
