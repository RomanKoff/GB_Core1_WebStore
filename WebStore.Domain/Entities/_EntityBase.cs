using WebStore.Domain.Entities.Interfaces;

namespace WebStore.Domain.Entities
{

	public abstract class _EntityBase
		: IEntityBase
	{
		public int Id { get; set; }
	}

}
