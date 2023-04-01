using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data.Model
{
    public class Homework
    {
        //public Homework()
        //{
        //}
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

       // [Required]
        //public ContentType ContentType { get; set; }

        [Required]
        public DateTime SubmissionTime { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
