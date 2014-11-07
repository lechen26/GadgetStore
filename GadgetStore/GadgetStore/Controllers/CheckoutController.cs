using System;
using System.Linq;
using System.Web.Mvc;
using WebMatrix.WebData;
using GadgetStore.Models;
namespace GadgetStore.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        GadgetEntities storeDB = new GadgetEntities();
        const string PromoCode = "GADGETS4FREE";

        // GET: /Checkout/AddressAndPayment
        public ActionResult AddressAndPayment()
        {

            var username = User.Identity.Name;
            var context = new GadgetEntities();
            var id = WebSecurity.CurrentUserId;
            var user = context.UserProfile.SingleOrDefault(u => u.UserId == id);

            var order = new OrderModel();
            order.LastName = user.LastName;
            order.FirstName = user.FirstName;
            order.Email = user.EmailAddress;
            order.City = user.City;
            order.Country = user.Country;
            order.Address = user.Address;

            return View(order);
        }

        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new OrderModel();
            TryUpdateModel(order);

            try
            {
                if (string.Equals(values["PromoCode"], PromoCode,
                    StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    //Save Order
                    storeDB.Orders.Add(order);
                    storeDB.SaveChanges();
                    //Process the order
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete",
                        new { id = order.OrderId });
                }
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        //
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = storeDB.Orders.Any(
                o => o.OrderId == id &&
                o.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }

    }
}
