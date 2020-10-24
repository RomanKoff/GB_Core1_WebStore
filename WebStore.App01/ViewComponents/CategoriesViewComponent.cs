using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebStore.App01.Services.Interfaces;
using WebStore.App01.ViewModels;

namespace WebStore.App01.ViewComponents
{

	public class CategoriesViewComponent
		: ViewComponent
	{

		private readonly IProductService _productService;


		public CategoriesViewComponent(
			IProductService productService)
		{
			_productService = productService;
		}


		public IViewComponentResult Invoke()
		{
			var categories = getCategories();
			return View(categories);
		}


		// privates

		private List<CategoryViewModel> getCategories()
		{
			var res = new List<CategoryViewModel>();
			var categories = _productService.GetCategories();
			var parents = categories
				.Where(x => !x.ParentId.HasValue).ToArray();
			foreach (var item in parents)
				res.Add(new CategoryViewModel()
				{
					Id = item.Id,
					Name = item.Name,
					Order = item.Order,
					ParentSection = null
				});
			foreach (var sectionViewModel in res)
			{
				var childs = categories
					.Where(x => x.ParentId.Equals(sectionViewModel.Id));
				foreach (var item in childs)
					sectionViewModel.ChildSections.Add(new CategoryViewModel()
					{
						Id = item.Id,
						Name = item.Name,
						Order = item.Order,
						ParentSection = sectionViewModel
					});
				sectionViewModel.ChildSections = sectionViewModel.ChildSections
					.OrderBy(x => x.Order).ToList();
			}
			res = res
				.OrderBy(x => x.Order).ToList();
			return res;
		}

	}

}
