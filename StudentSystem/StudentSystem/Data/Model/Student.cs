using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data.Model
{
    public class Student
    {
        public Student()
        {
            this.CourseEnrollments = new HashSet<Course>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(10)]
        [MinLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<Course> CourseEnrollments { get; set; }
    }
}
