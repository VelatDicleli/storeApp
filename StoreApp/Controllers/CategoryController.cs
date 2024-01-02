using Microsoft.AspNetCore.Mvc;
using StoreApp.DataAccess.GenericRepo.Absract;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {   
        IRepoManager repoManager;
        public CategoryController(IRepoManager repoManager)
        {
            this.repoManager = repoManager;
                
        }
        public IActionResult Index()
        {
            var model = repoManager.category.FindAll(false).ToList();
            return View(model);
        }
    }
}
