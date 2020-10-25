using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.App01.Services.Interfaces;
using WebStore.Domain.Entities;

namespace WebStore.App01.Controllers
{

	[Authorize]
	[Route("users")]
	public class EmployeesController
		: _CrudControllerPrototype<Employee>
	{

		public EmployeesController(
			IDataService<Employee> service)
			: base(service)
		{
		}


		[NonAction]
		public override Employee GetNewEntity()
		{
			return new Employee();
		}


		[NonAction]
		public override void CopyEntityContent(
			Employee inModel,
			Employee outModel)
		{
			outModel.FirstName = inModel.FirstName;
			outModel.SurName = inModel.SurName;
			outModel.Age = inModel.Age;
			outModel.Patronymic = inModel.Patronymic;
			outModel.Position = inModel.Position;
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
		public override IActionResult Edit(Employee model)
		{ return base.Edit(model); }


		[Route("delete/{id}")]
		public override IActionResult Delete(int id)
		{ return base.Delete(id); }

	}

}
