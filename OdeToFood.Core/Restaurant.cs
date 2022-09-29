using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Core
{
    public class Restaurant 
    {
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Name{ get; set; }
        [Required]
        [StringLength(250)]
        public string Location { get; set; }
        [Required]
        [Range(0,4)]
        public CuisineType Cuisine { get; set; }
    }
}
