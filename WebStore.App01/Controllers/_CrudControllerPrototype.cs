using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Entities.Interfaces;
using WebStore.Domain.Services.Interfaces;

namespace WebStore.App01.Controllers
{

	public abstract class _CrudControllerPrototype<TEntity>
		: Controller
	{

		public abstract TEntity GetNewEntity();
		public abstract void CopyEntityContent(TEntity inModel, TEntity outModel);


		private readonly IDataService<TEntity> _service;


		public _CrudControllerPrototype(
			IDataService<TEntity> service)
		{
			_service = service;
		}


		public virtual IActionResult Index()
		{
			return View(_service.GetAll());
		}


		public virtual IActionResult Details(
			int id)
		{
			var model = _service.GetById(id);
			if (model == null)
				return NotFound();
			return View(model);
		}


		public virtual IActionResult Edit(
			int? id)
		{
			TEntity model;
			if (id.HasValue)
			{
				model = _service.GetById(id.Value);
				if (model == null)
					return NotFound();
			}
			else
				model = GetNewEntity();
			return View(model);
		}


		public virtual IActionResult Edit(
			TEntity model)
		{
			int id = (model as IEntityBase).Id;
			if (id > 0)
			{
				var dbItem = _service.GetById(id);
				if (dbItem == null)
					return NotFound();
				CopyEntityContent(model, dbItem);
			}
			else
				_service.AddNew(model);
			_service.Commit();
			return RedirectToAction(nameof(Index));
		}


		public virtual IActionResult Delete(
			int id)
		{
			_service.Delete(id);
			return RedirectToAction(nameof(Index));
		}

	}

}
