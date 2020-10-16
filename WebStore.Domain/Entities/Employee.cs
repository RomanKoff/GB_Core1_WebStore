using WebStore.Domain.Entities.Interfaces;

namespace WebStore.Domain.Entities
{

	public class Employee
		: _EntityBase,
		IEntityBase
	{
		public string FirstName { get; set; }
		public string SurName { get; set; }
		public string Patronymic { get; set; }
		public int Age { get; set; }
		public string Position { get; set; }
	}

}