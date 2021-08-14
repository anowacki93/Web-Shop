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
    public class DeleteModel : PageModel
    {
        private readonly WebShop.Context.WebShopDbContext _context;

        public DeleteModel(WebShop.Context.WebShopDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ShopCategoryModel ShopCategoryModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShopCategoryModel = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

            if (ShopCategoryModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShopCategoryModel = await _context.Categories.FindAsync(id);

            if (ShopCategoryModel != null)
            {
                _context.Categories.Remove(ShopCategoryModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
