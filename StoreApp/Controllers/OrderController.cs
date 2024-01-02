using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.Abstract;
using StoreApp.Entities.Models;

namespace StoreApp.Controllers
{
    public class OrderController : Controller
    {   
        private readonly IServiceManager _services;
        private readonly Cart _cart;

        public OrderController(IServiceManager services, Cart cart)
        {
            _services = services;
            _cart = cart;
        }

        [Authorize]
        public ViewResult Checkout()
        {
            return View(new Order());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout([FromForm] Order order)
        {
            if (_cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty.");
            }

            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                _services.OrderService.SaveOrder(order);
                _cart.Clear();
                return RedirectToPage("/Complete", new { OrderId = order.OrderId });
            }
            else
            {
                return View();
            }
        }
    }
}
