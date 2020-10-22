using System.Collections.Generic;
using WebStore.Domain.Entities.Interfaces;

namespace WebStore.App01.ViewModels
{

	public class CategoryViewModel
		: IEntityNamed,
		IEntityOrdered
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Order { get; set; }

		public List<CategoryViewModel> ChildSections { get; set; }
		public CategoryViewModel ParentSection { get; set; }

		public CategoryViewModel()
		{
			ChildSections = new List<CategoryViewModel>();
		}
	}

}
