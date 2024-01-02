using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.Abstract;

namespace StoreApp.Components
{
    public class CategoriesMenuViewComponent:ViewComponent
    {
        private readonly IServiceManager serviceManager;

        public CategoriesMenuViewComponent(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        public IViewComponentResult Invoke()
        {
            var categories = serviceManager.CategoryService.GetCategories(true);
            return View(categories);
        }
    }
}
