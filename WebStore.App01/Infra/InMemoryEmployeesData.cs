using System.Collections.Generic;
using System.Linq;
using WebStore.App01.Models;

namespace WebStore.App01.Infra
{

	public class InMemoryEmployeesData
		: IEmployeesData
	{

		private readonly List<EmployeeModel> _employees;


		public InMemoryEmployeesData()
		{
			_employees = new List<EmployeeModel>(3)
			{
				new EmployeeModel{
					Id = 1,
					FirstName = "Вася",
					SurName = "Пупкин",
					Patronymic = "Иванович",
					Age = 22,
					Position = "Директор"
				},
				new EmployeeModel{
					Id = 2,
					FirstName = "Иван",
					SurName = "Холявко",
					Patronymic = "Александрович",
					Age = 30,
					Position = "Программист"
				},
				new EmployeeModel{
					Id = 3,
					FirstName = "Роберт",
					SurName = "Серов",
					Patronymic = "Сигизмундович",
					Age = 50,
					Position = "Зав. склада"
				}
			};
		}


		public IEnumerable<EmployeeModel> GetAll()
		{
			return _employees;
		}


		public EmployeeModel GetById(
			int id)
		{
			return _employees.FirstOrDefault(
				x => x.Id.Equals(id));
		}


		public void Commit()
		{
		}


		public void AddNew(
			EmployeeModel model)
		{
			model.Id = _employees.Max(x => x.Id) + 1;
			_employees.Add(model);
		}


		public void Delete(
			int id)
		{
			var employee = GetById(id);
			if (employee != null)
			{
				_employees.Remove(employee);
			}
		}

	}

}
