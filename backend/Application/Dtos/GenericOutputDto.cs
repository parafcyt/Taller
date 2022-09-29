using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class GenericOutputDto
    {
        public int Code { get; set; }
        public string Message { get; set; } = null!;
        public string Details { get; set; } = null!;
    }
}
