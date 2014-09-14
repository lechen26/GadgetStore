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
        public int ManufactureId { get; set; }        
        public string Name { get; set; }        
        public string Decription { get; set; }        
        public string PhotoUrl { get; set; }                
    }
}