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
        [Display(Name="ID")]
        public int CategoryId { get; set; }        
        [Required(ErrorMessage="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage="Description is required")]
        public string Description { get; set; }
        public string PhotoUrl { get; set; }        
    }
}
