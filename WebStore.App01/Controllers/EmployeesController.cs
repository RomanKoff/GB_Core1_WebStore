﻿using Microsoft.AspNetCore.Mvc;
using WebStore.App01.Infra;
using WebStore.App01.Models;

namespace WebStore.App01.Controllers
{

	[Route("users")]
	public class EmployeesController
		: _CrudControllerPrototype<EmployeeModel>
	{

		public EmployeesController(
			IRepositoryData<EmployeeModel> repository)
			: base(repository)
		{
		}


		[NonAction]
		public override EmployeeModel GetNewEntity()
		{
			return new EmployeeModel();
		}


		[NonAction]
		public override int GetEntityId(
			EmployeeModel model)
		{
			return model.Id;
		}


		[NonAction]
		public override void CopyEntityContent(
			EmployeeModel inModel,
			EmployeeModel outModel)
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
		public override IActionResult Edit(EmployeeModel model)
		{ return base.Edit(model); }


		[Route("delete/{id}")]
		public override IActionResult Delete(int id)
		{ return base.Delete(id); }

	}

}
