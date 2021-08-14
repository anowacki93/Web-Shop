using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;
using WebShop.Services.Interfaces;

namespace WebShop.Controllers
{
    public class ShopCategoryController : Controller
    {
        private readonly IShopCategoryService _modelService;
        public ShopCategoryController(IShopCategoryService modelService)
        {
            _modelService = modelService;
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
            ShopCategoryModel model = new ShopCategoryModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create([FromForm] ShopCategoryModel model) //[FromForm] - potrzebne do mapowania danych z formularza na obiekt w przypadku gdy korzystamy z Razora lub zwykłego HTMLa. Przy taghelperach nie jest to konieczne tak jak w tym przypadku
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //model.UserId = User.Identity.Name;

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
        public IActionResult EditSave(ShopCategoryModel model)
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
