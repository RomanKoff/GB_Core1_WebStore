using WebStore.Domain.Entities.Interfaces;

namespace WebStore.Domain.Entities
{

	public class Category
		: _EntityNamedBase,
		IEntityOrdered, IEntityTree
	{
		public int Order { get; set; }
		public int? ParentId { get; set; }
	}

}
