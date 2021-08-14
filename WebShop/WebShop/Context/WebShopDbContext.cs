using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Context
{
	public class WebShopDbContext : IdentityDbContext
	{
		public WebShopDbContext(DbContextOptions<WebShopDbContext> options) : base(options)
		{

		}

		public DbSet<ShopCategoryModel> Categories { get; set; }
		public DbSet<ProductModel> Products{ get; set; }

	}
}
