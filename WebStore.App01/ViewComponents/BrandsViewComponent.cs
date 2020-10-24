using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebStore.App01.Services.Interfaces;
using WebStore.App01.ViewModels;

namespace WebStore.App01.ViewComponents
{

	public class BrandsViewComponent
		: ViewComponent
	{

		private readonly IProductService _productService;


		public BrandsViewComponent(
			IProductService productService)
		{
			_productService = productService;
		}


		public IViewComponentResult Invoke()
		{
			var brands = getBrands();
			return View(brands);
		}


		// privates

		private IEnumerable<BrandViewModel> getBrands()
		{
			var dbBrands = _productService.GetBrands();
			return dbBrands.Select(x => new BrandViewModel
			{
				Id = x.Id,
				Name = x.Name,
				Order = x.Order,
				ProductsCount = 0
			}).OrderBy(x => x.Order).ToList();
		}

	}

}
