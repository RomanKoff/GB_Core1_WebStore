using System.Collections.Generic;
using System.Linq;
using WebStore.App01.Models;

namespace WebStore.App01.Infra
{

	public class InMemoryEmployeesRepository
		: IRepositoryData<EmployeeModel>
	{

		private readonly List<EmployeeModel> _items;


		public InMemoryEmployeesRepository()
		{
			_items = new List<EmployeeModel>
			{
				new EmployeeModel {
					Id = 1,
					FirstName = "Пупкин",
					SurName = "Вася",
					Patronymic = "Иванович",
					Age = 22,
					Position = "Директор"
				},
				new EmployeeModel {
					Id = 2,
					FirstName = "Холявко",
					SurName = "Иван",
					Patronymic = "Александрович",
					Age = 30,
					Position = "Программист"
				},
				new EmployeeModel {
					Id = 3,
					FirstName = "Серов",
					SurName = "Роберт",
					Patronymic = "Сигизмундович",
					Age = 50,
					Position = "Зав. склада"
				}
			};
		}


		public IEnumerable<EmployeeModel> GetAll()
		{
			return _items;
		}


		public EmployeeModel GetById(
			int id)
		{
			return _items.FirstOrDefault(
				x => x.Id.Equals(id));
		}


		public void Commit()
		{
		}


		public void AddNew(
			EmployeeModel model)
		{
			model.Id = _items.Max(x => x.Id) + 1;
			_items.Add(model);
		}


		public void Delete(
			int id)
		{
			var item = GetById(id);
			if (item != null)
			{
				_items.Remove(item);
			}
		}

	}

}
