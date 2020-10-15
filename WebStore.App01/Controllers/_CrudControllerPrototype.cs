using Microsoft.AspNetCore.Mvc;
using WebStore.App01.Infra;

namespace WebStore.App01.Controllers
{

	public abstract class _CrudControllerPrototype<TEntity>
		: Controller
	{

		public abstract TEntity GetNewEntity();
		public abstract int GetEntityId(TEntity model);
		public abstract void CopyEntityContent(TEntity inModel, TEntity outModel);


		private readonly IRepositoryData<TEntity> _repository;


		public _CrudControllerPrototype(
			IRepositoryData<TEntity> repository)
		{
			_repository = repository;
		}


		public virtual IActionResult Index()
		{
			return View(_repository.GetAll());
		}


		public virtual IActionResult Details(
			int id)
		{
			var model = _repository.GetById(id);
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
				model = _repository.GetById(id.Value);
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
			int id = GetEntityId(model);
			if (id > 0)
			{
				var dbItem = _repository.GetById(id);
				if (dbItem == null)
					return NotFound();
				CopyEntityContent(model, dbItem);
			}
			else
				_repository.AddNew(model);
			_repository.Commit();
			return RedirectToAction(nameof(Index));
		}


		public virtual IActionResult Delete(
			int id)
		{
			_repository.Delete(id);
			return RedirectToAction(nameof(Index));
		}

	}

}
