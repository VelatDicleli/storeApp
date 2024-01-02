using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using StoreApp.Business.Abstract;
using StoreApp.Entities.Dtos;
using StoreApp.Entities.Models;
using System.IO;
using static System.Formats.Asn1.AsnWriter;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {   private readonly IServiceManager _services;
        

        public ProductController(IServiceManager _services)
        {
                this._services = _services;
        }
        public IActionResult Index()
        {
            List<ProductDto> model = _services.ProductService.GetAllProducts(false).ToList();
            return View(model);
        }

        public IActionResult Create()
        {
           
           ViewBag.Categories = _services.CategoryService.GetCategories(false).ToList(); 

           return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDtoForInsertion productDto, IFormFile? file) 
        {
            ViewBag.Categories = _services.CategoryService.GetCategories(false).ToList();

            if (ModelState.IsValid) {
               
                if(file != null)
                {   
                    
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images",file.FileName);
                    using (var stream = new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);

                    }
                    productDto.ImageUrl = String.Concat("/images/", file.FileName);
                }

                
                productDto.ImageUrl = "/images/no_image.jpg";
                
                _services.ProductService.Add(productDto);
                return RedirectToAction("Index");
            }

            
            return View();

        }

        
        public IActionResult Edit(int id)
        {
            var model = _services.ProductService.GetProductForUpdate(id, false);

            ViewBag.Categories = _services.CategoryService.GetCategories(false).ToList();
           
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDtoForUpdate productDto, IFormFile? file, string? existingImageUrl)
        {
            ViewBag.Categories = _services.CategoryService.GetCategories(false).ToList();
            
            if (ModelState.IsValid)
            {   

                if(file != null)
                {

                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);

                    }

                    productDto.ImageUrl = String.Concat("/images/", file.FileName);
                    _services.ProductService.Update(productDto);
                    return RedirectToAction("Index");
                }

                else if(!string.IsNullOrEmpty(existingImageUrl))
                {
                 
                    productDto.ImageUrl = existingImageUrl;
                    _services.ProductService.Update(productDto);
                    return RedirectToAction("Index");

                }

            }


            
            return View();
            
            
        }

        public IActionResult Remove(int id) {

            _services.ProductService.RemoveProduct(id);
            return RedirectToAction("Index");
        
        }
    }
}
