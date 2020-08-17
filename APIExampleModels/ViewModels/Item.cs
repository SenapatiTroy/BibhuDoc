using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace APIExampleModels.ViewModels
{
    public class Item
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; } 
        [Required]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Name Lengh Shoulb be mora than 3 charector and lessthan 12 charector")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
