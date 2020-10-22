using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebStore.App01.ViewModels;
using WebStore.Domain.Entities;
using WebStore.Domain.Services.Interfaces;

namespace WebStore.App01.Controllers
{

	public class CatalogController
		: Controller
	{

		private readonly IProductService _productService;


		public CatalogController(
			IProductService productService)
		{
			_productService = productService;
		}


		public IActionResult Shop(
			int? categoryId,
			int? brandId)
		{
			var products = _productService.GetProducts(
				new ProductFilter { BrandId = brandId, CategoryId = categoryId });
			var model = new CatalogViewModel()
			{
				BrandId = brandId,
				CategoryId = categoryId,
				Products = products.Select(x => new ProductViewModel()
				{
					Id = x.Id,
					ImageUrl = x.ImageUrl,
					Name = x.Name,
					Order = x.Order,
					Price = x.Price
				}).OrderBy(x => x.Order).ToList()
			};
			return View(model);
		}


		public IActionResult ProductDetails()
		{
			return View();
		}

	}

}
