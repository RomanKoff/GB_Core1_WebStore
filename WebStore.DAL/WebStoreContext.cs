using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebStore.Domain.Entities;

namespace WebStore.DAL
{

	public class WebStoreContext
		: IdentityDbContext<User>
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Brand> Brands { get; set; }

		public WebStoreContext(
			DbContextOptions options)
			: base(options)
		{
		}
	}

}
