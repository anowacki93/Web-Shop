using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public string ShopCategoryName { get; set; }
        [NotMapped]
        public SelectList? ShopCategoryModelList { get; set; }
        public ShopCategoryModel ShopCategoryModel { get; set; }
    }
}
