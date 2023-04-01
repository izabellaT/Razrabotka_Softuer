using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data.Model
{
   public class Course
    {
        public Course()
        {
            this.StudentsEnrolled = new HashSet<Student>();
            this.Resources = new HashSet<Resource>();
            this.HomeworkSubmissions = new HashSet<Homework>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
       
        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public double Price { get; set; }
        public ICollection<Student> StudentsEnrolled { get; set; }
        public ICollection<Resource> Resources { get; set; }
        public ICollection<Homework> HomeworkSubmissions { get; set; }
    }
}
