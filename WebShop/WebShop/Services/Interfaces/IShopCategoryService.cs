using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Services.Interfaces
{
    public interface IShopCategoryService
    {
        public bool Create(ShopCategoryModel model);
        public ShopCategoryModel Get(int id);
        public IList<ShopCategoryModel> GetAll();
        public bool Update(ShopCategoryModel model);
        public bool Delete(int id);
    }
}
