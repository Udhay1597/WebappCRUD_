using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebappCodeFirst.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Column("Student_Name",TypeName="varchar(100)")]

        [Required]
        public string Name { get; set; }
        [Column("Gender", TypeName = "varchar(20)")]

        [Required]
        public int?Gender { get; set; }

        [Required]
        public int?Age { get; set; }

        [Required]
        public int?Standard { get; set; }
    }
}
