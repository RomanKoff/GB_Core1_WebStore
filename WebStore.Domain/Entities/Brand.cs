using WebStore.Domain.Entities.Interfaces;

namespace WebStore.Domain.Entities
{

	public class Brand
		: _EntityNamedBase,
		IEntityOrdered
	{
		public int Order { get; set; }
	}

}
