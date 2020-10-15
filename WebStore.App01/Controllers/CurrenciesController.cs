using Microsoft.AspNetCore.Mvc;
using WebStore.App01.Infra;
using WebStore.App01.Models;

namespace WebStore.App01.Controllers
{

	[Route("currencies")]
	public class CurrenciesController
		: _CrudControllerPrototype<CurrencyModel>
	{

		public CurrenciesController(
			IRepositoryData<CurrencyModel> repository)
			: base(repository)
		{
		}


		[NonAction]
		public override CurrencyModel GetNewEntity()
		{
			return new CurrencyModel();
		}


		[NonAction]
		public override int GetEntityId(
			CurrencyModel model)
		{
			return model.Id;
		}


		[NonAction]
		public override void CopyEntityContent(
			CurrencyModel inModel,
			CurrencyModel outModel)
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
		public override IActionResult Edit(int? id)
		{ return base.Edit(id); }


		[HttpPost]
		[Route("edit/{id?}")]
		public override IActionResult Edit(CurrencyModel model)
		{ return base.Edit(model); }


		[Route("delete/{id}")]
		public override IActionResult Delete(int id)
		{ return base.Delete(id); }

	}

}
