using System.Collections.Generic;
using WebStore.Domain.Entities;

namespace WebStore.Domain.Services.Interfaces
{

	public interface IProductService
	{
		IEnumerable<Category> GetCategories();
		IEnumerable<Brand> GetBrands();
		IEnumerable<Product> GetProducts(ProductFilter filter);
	}

}
