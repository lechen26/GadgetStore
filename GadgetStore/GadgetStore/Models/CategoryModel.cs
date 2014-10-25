using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GadgetStore.Models
{
    public class CategoryModel
    {
        [Key]
<<<<<<< HEAD
        public int CategoryId { get; set; }        
        public string Name { get; set; }
        public string Decription { get; set; }
=======
        [Display(Name="ID")]
        public int CategoryId { get; set; }        
        [Required(ErrorMessage="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage="Description is required")]
        public string Description { get; set; }
>>>>>>> origin/chen
        public string PhotoUrl { get; set; }        
    }
}
