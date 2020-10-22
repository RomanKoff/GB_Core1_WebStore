using WebStore.Domain.Entities.Interfaces;

namespace WebStore.App01.ViewModels
{

	public class ProductViewModel
		: IEntityNamed,
		IEntityOrdered
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Order { get; set; }
		public string ImageUrl { get; set; }
		public decimal Price { get; set; }
	}

}
