using Microsoft.AspNetCore.Mvc;
using StoreApp.DataAccess.Abstract;
using StoreApp.DataAccess.GenericRepo.Absract;
using StoreApp.Models;
using System.Diagnostics;

namespace StoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IRepoManager repoManager;

        public HomeController(IRepoManager repoManager)
        {
               this.repoManager = repoManager;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var model = repoManager.product.GetAll(false);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}