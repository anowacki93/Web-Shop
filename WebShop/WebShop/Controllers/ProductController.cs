using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;
using WebShop.Services.Interfaces;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _modelService;
        private readonly IShopCategoryService _categoryService;
        public ProductController(IProductService modelService, IShopCategoryService categoryService)
        {
            _modelService = modelService;
            _categoryService = categoryService;
        }
        

        public IActionResult Index()
        {   //Po utworzeniu userów
            //var user = User.Identity.Name;
            //var modelData = _modelService.GetAll().Where(x => x.UserId == user);
            //Przed utworzeniem userow
            var modelData = _modelService.GetAll();
            
            return View(modelData);
        }
        public IActionResult Create()
        {
            ProductModel model = new ProductModel();
            model.ShopCategoryModelList = new SelectList(_categoryService.GetAll().Select(x => x.Name).ToList(), model.ShopCategoryName);
            return View(model);
        }
        [HttpPost]
        public IActionResult Create([FromForm] ProductModel model) //[FromForm] - potrzebne do mapowania danych z formularza na obiekt w przypadku gdy korzystamy z Razora lub zwykłego HTMLa. Przy taghelperach nie jest to konieczne tak jak w tym przypadku
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //model.UserId = User.Identity.Name;
                    model.ShopCategoryModel = _categoryService.GetAll().Where(x => x.Name == model.ShopCategoryName).Single();
                    _modelService.Create(model);
                    //context.SaveChanges();
                }
                catch (Exception)
                {
                    return View(model);
                }
                return Redirect("Index");
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult Remove(int id)
        {
            return View(_modelService.Get(id));
        }
        [HttpPost]
        public IActionResult RemoveConfirm(int id)
        {
            try
            {
                _modelService.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                throw;
            }
            return Redirect("Index");
        }
        public IActionResult Edit(int id)
        {
            return View(_modelService.Get(id));
        }
        [HttpPost]
        public IActionResult EditSave(ProductModel model)
        {
            try
            {

                _modelService.Update(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                throw;
            }
            return Redirect("Index");
        }
        public IActionResult Details(int id)
        {
            return View(_modelService.Get(id));
        }
        public IActionResult Show()
        {
            var modelData = _modelService.GetAll();
            return View(modelData.Count());
        }
    }
}
