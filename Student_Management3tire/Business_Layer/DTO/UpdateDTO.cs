using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.DTO
{
    public class UpdateDTO
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string? EmailId { get; set; }
    }
}
