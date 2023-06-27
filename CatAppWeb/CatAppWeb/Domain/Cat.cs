using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatAppWeb.Domain
{
    public class Cat
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Breed { get; set; }

        [Required]
        [Range(1, 30)]
        public int Age { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
