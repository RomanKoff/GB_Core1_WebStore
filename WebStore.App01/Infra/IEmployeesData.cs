using System.Collections.Generic;
using WebStore.App01.Models;

namespace WebStore.App01.Infra
{

	public interface IEmployeesData
	{
		IEnumerable<EmployeeModel> GetAll();
		EmployeeModel GetById(int id);
		void Commit();
		void AddNew(EmployeeModel model);
		void Delete(int id);
	}

}
