using System.Collections.Generic;
using System.Linq;
using WebStore.Domain.Entities;

namespace WebStore.Domain.Services
{

	public class InMemoryEmployeesService
		: IDataService<Employee>
	{

		private readonly List<Employee> _items;


		public InMemoryEmployeesService()
		{
			_items = new List<Employee>
			{
				new Employee {
					Id = 1,
					FirstName = "Пупкин",
					SurName = "Вася",
					Patronymic = "Иванович",
					Age = 22,
					Position = "Директор"
				},
				new Employee {
					Id = 2,
					FirstName = "Холявко",
					SurName = "Иван",
					Patronymic = "Александрович",
					Age = 30,
					Position = "Программист"
				},
				new Employee {
					Id = 3,
					FirstName = "Серов",
					SurName = "Роберт",
					Patronymic = "Сигизмундович",
					Age = 50,
					Position = "Зав. склада"
				}
			};
		}


		public IEnumerable<Employee> GetAll()
		{
			return _items;
		}


		public Employee GetById(
			int id)
		{
			return _items.FirstOrDefault(
				x => x.Id.Equals(id));
		}


		public void Commit()
		{
		}


		public void AddNew(
			Employee model)
		{
			model.Id = _items.Any() ? _items.Max(x => x.Id) + 1 : 1;
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
