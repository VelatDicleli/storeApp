using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.Abstract;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;

        public OrderController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var orders = _manager.OrderService.Orders;
            return View(orders);
        }

        [HttpPost]
        public IActionResult Complete([FromForm] int OrderId)
        {
            _manager.OrderService.Complete(OrderId);
            return RedirectToAction("Index");
        }
    }
}
