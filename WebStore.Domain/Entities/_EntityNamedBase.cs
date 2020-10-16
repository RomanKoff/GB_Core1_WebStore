using WebStore.Domain.Entities.Interfaces;

namespace WebStore.Domain.Entities
{

	public abstract class _EntityNamedBase
		: IEntityNamed
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

}
