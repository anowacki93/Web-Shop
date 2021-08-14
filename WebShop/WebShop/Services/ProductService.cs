using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Context;
using WebShop.Models;
using WebShop.Services.Interfaces;

namespace WebShop.Services
{
    public class ProductService : IProductService
    {
        private readonly WebShopDbContext _context;
        public ProductService(WebShopDbContext context)
        {
            _context = context;
        }
        public bool Create(ProductModel model)
        {

            _context.Products.Add(model);

            return _context.SaveChanges() > 0;
        }
        public ProductModel Get(int id)
        {
            return _context.Products.SingleOrDefault(b => b.Id == id);
        }
        public IList<ProductModel> GetAll()
        {
            return _context.Products.ToList();
        }
        public bool Update(ProductModel model)
        {
            _context.Products.Update(model);
            return _context.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var model = _context.Products.SingleOrDefault(b => b.Id == id);
            if (model == null)
                return false;
            _context.Products.Remove(model);
            return _context.SaveChanges() > 0;
        }
    }
}
