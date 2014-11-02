using System.Collections.Generic;
using GadgetStore.Models;

namespace GadgetStore.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<CartModel> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}