using System.ComponentModel.DataAnnotations;

namespace GadgetStore.Models
{
    public class CartModel
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual ItemModel Item { get; set; }
    }
}