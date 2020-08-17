using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIExampleModels.ViewModels
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Name Lengh Shoulb be mora than 3 charector and lessthan 12 charector")]
        public string Name { get; set; }
    }
}
