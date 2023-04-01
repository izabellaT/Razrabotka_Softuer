using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestierMask.Data.Model
{
    public class Project
    {
        public Project()
        {
            this.Tasks = new HashSet<Task>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        public DateTime OpenDate { get; set; }
        public DateTime DueDate { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
