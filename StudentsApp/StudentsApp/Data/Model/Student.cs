using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsApp.Data.Model
{
    public class Student
    {
        public Student()
        {
            this.StudentSubjects = new HashSet<StudentSubject>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; }

    }
}
