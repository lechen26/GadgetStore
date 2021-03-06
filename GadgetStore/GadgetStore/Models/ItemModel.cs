﻿using System;
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
        [Display(Name = "ID")]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        [ForeignKey("CategoryModel")]
        public int CategoryId { get; set; }
        [ForeignKey("ManufactureModel")]       
        public int ManufactureId { get; set; }        
        public decimal Price { get; set; }      
        public virtual CategoryModel CategoryModel { get; set; }
        public virtual ManufactureModel ManufactureModel { get; set; }
        public virtual List<OrderDetailModel> OrderDetails { get; set; }

    }
}
