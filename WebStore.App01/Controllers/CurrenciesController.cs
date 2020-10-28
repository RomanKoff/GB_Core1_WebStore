using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.App01.Services.Interfaces;
using WebStore.Domain.Entities;

namespace WebStore.App01.Controllers
{

	[Authorize]
	[Route("currencies")]
	public class CurrenciesController
		: _CrudControllerPrototype<Currency>
	{

		public CurrenciesController(
			IDataService<Currency> service)
			: base(service)
		{
		}


		[NonAction]
		public override Currency GetNewEntity()
		{
			return new Currency();
		}


		[NonAction]
		public override void CopyEntityContent(
			Currency inModel,
			Currency outModel)
		{
			outModel.Char = inModel.Char;
			outModel.Country = inModel.Country;
			outModel.Name = inModel.Name;
			outModel.Rate = inModel.Rate;
			outModel.Unit = inModel.Unit;
		}


		public override IActionResult Index()
		{ return base.Index(); }


		[HttpGet]
		[Route("{id}")]
		public override IActionResult Details(int id)
		{ return base.Details(id); }


		[HttpGet]
		[Route("edit/{id?}")]
		[Authorize(Roles = "Administrators")]
		public override IActionResult Edit(int? id)
		{ return base.Edit(id); }


		[HttpPost]
		[Route("edit/{id?}")]
		[Authorize(Roles = "Administrators")]
		public override IActionResult Edit(Currency model)
		{ return base.Edit(model); }


		[Route("delete/{id}")]
		[Authorize(Roles = "Administrators")]
		public override IActionResult Delete(int id)
		{ return base.Delete(id); }

	}

}
