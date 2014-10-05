using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GadgetStore.Models
{
    public class ItemModel
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        [ForeignKey("CategoryModel")]
        public int CategoryId { get; set; }
        [ForeignKey("ManufactureModel")]       
        public int ManufactureId { get; set; }        
        public decimal Price { get; set; }
        public int PurchaseAmount { get; set; }
        public DateTime AddedAt { get; set; }                
        public virtual CategoryModel CategoryModel { get; set; }
        public virtual ManufactureModel ManufactureModel { get; set; }        
    }
}
