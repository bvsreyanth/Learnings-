using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public int PhoneNumber { get; set; }
        public string? EmailId { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
