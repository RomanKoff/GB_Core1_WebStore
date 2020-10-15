using Microsoft.AspNetCore.Mvc;
using WebStore.App01.Infra;
using WebStore.App01.Models;

namespace WebStore.App01.Controllers
{

	[Route("users")]
	public class EmployeesController
		: Controller
	{

		private readonly IEmployeesData _employeesData;


		public EmployeesController(
			IEmployeesData employeesData)
		{
			_employeesData = employeesData;
		}


		public IActionResult Index()
		{
			return View(_employeesData.GetAll());
		}


		[HttpGet]
		[Route("{id}")]
		public IActionResult Details(
			int id)
		{
			var employee = _employeesData.GetById(id);
			if (employee == null)
				return NotFound();
			return View(employee);
		}


		[HttpGet]
		[Route("edit/{id?}")]
		public IActionResult Edit(
			int? id)
		{
			EmployeeModel model;
			if (id.HasValue)
			{
				model = _employeesData.GetById(id.Value);
				if (model == null)
					return NotFound();
			}
			else
				model = new EmployeeModel();
			return View(model);
		}


		[HttpPost]
		[Route("edit/{id?}")]
		public IActionResult Edit(
			EmployeeModel model)
		{
			if (model.Id > 0)
			{
				var dbItem = _employeesData.GetById(model.Id);
				if (dbItem == null)
					return NotFound();
				dbItem.FirstName = model.FirstName;
				dbItem.SurName = model.SurName;
				dbItem.Age = model.Age;
				dbItem.Patronymic = model.Patronymic;
				dbItem.Position = model.Position;
			}
			else
				_employeesData.AddNew(model);
			_employeesData.Commit();
			return RedirectToAction(nameof(Index));
		}


		[Route("delete/{id}")]
		public IActionResult Delete(
			int id)
		{
			_employeesData.Delete(id);
			return RedirectToAction(nameof(Index));
		}

	}

}
