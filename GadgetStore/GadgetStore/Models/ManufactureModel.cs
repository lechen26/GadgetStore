using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GadgetStore.Models
{
    public class ManufactureModel
    {
        [Key]
<<<<<<< HEAD
        public int ManufactureId { get; set; }        
        public string Name { get; set; }        
        public string Decription { get; set; }        
=======
        [Display(Name = "ID")]
        public int ManufactureId { get; set; }        
        public string Name { get; set; }        
        public string Description { get; set; }        
>>>>>>> origin/chen
        public string PhotoUrl { get; set; }                
    }
}