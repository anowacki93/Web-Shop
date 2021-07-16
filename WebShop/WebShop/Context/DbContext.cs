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
	public class DbContext : IdentityDbContext
	{
		public DbContext(DbContextOptions<DbContext> options) : base(options)
		{

		}

		public DbSet<ShoppingCartModel> ShoppingCart { get; set; }
			public DbSet<WarehouseModel> Warehouse { get; set; }
	
	}
}
