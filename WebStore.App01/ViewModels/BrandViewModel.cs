using WebStore.Domain.Entities.Interfaces;

namespace WebStore.App01.ViewModels
{

	public class BrandViewModel
		: IEntityNamed,
		IEntityOrdered
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Order { get; set; }

		public int ProductsCount { get; set; }
	}


}
