using System.Collections.Generic;

namespace WebStore.App01.Services.Interfaces
{

	public interface IDataService<TEntity>
	{
		IEnumerable<TEntity> GetAll();
		TEntity GetById(int id);
		void Commit();
		void AddNew(TEntity model);
		void Delete(int id);
	}

}
