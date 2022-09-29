using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Destinations.Dtos
{
    public class DestinationDto
    {
        public int DestinationId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
