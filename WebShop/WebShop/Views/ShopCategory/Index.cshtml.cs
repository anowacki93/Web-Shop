using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebShop.Context;
using WebShop.Models;

namespace WebShop.Views.ShopCategory
{
    public class IndexModel : PageModel
    {
        private readonly WebShop.Context.WebShopDbContext _context;

        public IndexModel(WebShop.Context.WebShopDbContext context)
        {
            _context = context;
        }

        public IList<ShopCategoryModel> ShopCategoryModel { get;set; }

        public async Task OnGetAsync()
        {
            ShopCategoryModel = await _context.Categories.ToListAsync();
        }
    }
}
