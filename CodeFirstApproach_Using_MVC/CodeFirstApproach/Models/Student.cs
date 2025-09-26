using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstApproach.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Column("StudentName",TypeName="varchar(100)")]
        [Required]
        public String? Name { get; set; }
        [Column("StudentGender", TypeName = "varchar(100)")]
        public String? Gender { get; set; }
        public int Age { get; set; }
        public int Standard { get; set; }



    }
}
