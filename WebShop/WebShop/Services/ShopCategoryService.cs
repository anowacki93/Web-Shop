using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Context;
using WebShop.Models;
using WebShop.Services.Interfaces;

namespace WebShop.Services
{
    public class ShopCategoryService : IShopCategoryService
    {
        private readonly WebShopDbContext _context;
        public ShopCategoryService(WebShopDbContext context)
        {
            _context = context;
        }
        public bool Create(ShopCategoryModel model)
        {

            _context.Categories.Add(model);

            return _context.SaveChanges() > 0;
        }
        public ShopCategoryModel Get(int id)
        {
            return _context.Categories.SingleOrDefault(b => b.Id == id);
        }
        public IList<ShopCategoryModel> GetAll()
        {
            return _context.Categories.ToList();
        }
        public bool Update(ShopCategoryModel model)
        {
            _context.Categories.Update(model);
            return _context.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var model = _context.Categories.SingleOrDefault(b => b.Id == id);
            if (model == null)
                return false;
            _context.Categories.Remove(model);
            return _context.SaveChanges() > 0;
        }
    }
}
