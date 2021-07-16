using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Context
{
	public class DbContext : IdentityDbContext
	{
		public DbContext(DbContextOptions<DbContext> options) : base(options)
		{

		}
	}
}
