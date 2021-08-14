using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Services.Interfaces
{
    public interface IProductService
    {
        public bool Create(ProductModel model);
        public ProductModel Get(int id);
        public IList<ProductModel> GetAll();
        public bool Update(ProductModel model);
        public bool Delete(int id);
    }
}
