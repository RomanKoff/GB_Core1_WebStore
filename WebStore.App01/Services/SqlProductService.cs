using System.Collections.Generic;
using System.Linq;
using WebStore.App01.Services.Interfaces;
using WebStore.DAL;
using WebStore.Domain.Entities;

namespace WebStore.App01.Services
{

	public class SqlProductService
		: IProductService
	{

		private readonly WebStoreContext _context;


		public SqlProductService(
			WebStoreContext context)
		{
			_context = context;
		}


		public IEnumerable<Category> GetCategories()
		{
			return _context.Categories.ToList();
		}


		public IEnumerable<Brand> GetBrands()
		{
			return _context.Brands.ToList();
		}


		public IEnumerable<Product> GetProducts(
			ProductFilter filter)
		{
			var contextProducts = _context.Products.AsQueryable();
			if (filter.BrandId.HasValue)
				contextProducts.Where(c => c.BrandId.HasValue
					&& c.BrandId.Value.Equals(filter.BrandId.Value));
			if (filter.CategoryId.HasValue)
				contextProducts = contextProducts.Where(c => c.CategoryId.Equals(filter.CategoryId.Value));
			return contextProducts.ToList();
		}

	}

}
