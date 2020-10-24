using System.Collections.Generic;
using System.Linq;
using WebStore.Domain.Entities;
using WebStore.App01.Services.Interfaces;

namespace WebStore.App01.Services
{

	public class InMemoryProductService
		: IProductService
	{

		public IEnumerable<Category> GetCategories()
		{
			return _categories;
		}


		public IEnumerable<Brand> GetBrands()
		{
			return _brands;
		}


		public IEnumerable<Product> GetProducts(ProductFilter filter)
		{
			var products = _products;
			if (filter.CategoryId.HasValue)
				products = products.Where(
					x => x.CategoryId.Equals(filter.CategoryId))
					.ToList();
			if (filter.BrandId.HasValue)
				products = products.Where(
					x => x.BrandId.HasValue
					&& x.BrandId.Value.Equals(filter.BrandId.Value))
					.ToList();
			return products;
		}


		// privates

		private readonly List<Category> _categories = new List<Category>
		{
			new Category() { Id = 1, Name = "Sportswear 123" },
			new Category() { Id = 2, Name = "Nike", ParentId = 1 },
			new Category() { Id = 3, Name = "Under Armour", Order = 1, ParentId = 1 }
		};

		private readonly List<Brand> _brands = new List<Brand>()
		{
			new Brand() { Id = 1, Name = "Acne 123" },
			new Brand() { Id = 2, Name = "Grüne Erde", Order = 1 },
			new Brand() { Id = 3, Name = "Albiro", Order = 2 }
		};

		private readonly List<Product> _products = new List<Product>
		{
			new Product() { Id = 1, Name = "Pixel Infrared Thermal Imager", Price = 1025, ImageUrl = "product1.jpg", Order = 0, CategoryId = 2, BrandId = 1 },
			new Product() { Id = 2, Name = "Mini Electric Welding Machine", Price = 1025, ImageUrl = "product2.jpg", Order = 1, CategoryId = 2, BrandId = 1 },
			new Product() { Id = 3, Name = "Digital Microscope", Price = 1025, ImageUrl = "product3.jpg", Order = 2, CategoryId = 2, BrandId = 1 }
		};

	}

}
