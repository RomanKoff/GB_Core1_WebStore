using System.Collections.Generic;
using System.Linq;
using WebStore.App01.Models;

namespace WebStore.App01.Infra
{

	public class InMemoryCurrenciesRepository
		: IRepositoryData<CurrencyModel>
	{

		private readonly List<CurrencyModel> _items;


		public InMemoryCurrenciesRepository()
		{
			_items = new List<CurrencyModel>
			{
				new CurrencyModel {
					Id = 1,
					Country = "Евросоюз",
					Name = "Евро",
					Char = "€",
					Unit = "EUR",
					Rate = 90.8
				},
				new CurrencyModel {
					Id = 2,
					Country = "Великобритания",
					Name = "Фунт",
					Char = "£",
					Unit = "GBP",
					Rate = 100.1
				},
				new CurrencyModel {
					Id = 3,
					Country = "Канада",
					Name = "Доллар",
					Char = "$",
					Unit = "CAD",
					Rate = 58.81
				},
				new CurrencyModel {
					Id = 4,
					Country = "Китай",
					Name = "Юань",
					Char = "¥",
					Unit = "CNY",
					Rate = 11.47
				},
				new CurrencyModel {
					Id = 5,
					Country = "Лихтенштейн",
					Name = "Франк",
					Char = "₣",
					Unit = "CHF",
					Rate = 84.47
				},
				new CurrencyModel {
					Id = 6,
					Country = "Россия",
					Name = "Рубль",
					Char = "₽",
					Unit = "RUB",
					Rate = 1
				},
				new CurrencyModel {
					Id = 7,
					Country = "США",
					Name = "Доллар",
					Char = "$",
					Unit = "USD",
					Rate = 77.28
				},
				new CurrencyModel {
					Id = 8,
					Country = "Япония",
					Name = "Иена",
					Char = "¥",
					Unit = "JPY",
					Rate = 0.733
				},
			};
		}


		public IEnumerable<CurrencyModel> GetAll()
		{
			return _items;
		}


		public CurrencyModel GetById(
			int id)
		{
			return _items.FirstOrDefault(
				x => x.Id.Equals(id));
		}


		public void Commit()
		{
		}


		public void AddNew(
			CurrencyModel model)
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
