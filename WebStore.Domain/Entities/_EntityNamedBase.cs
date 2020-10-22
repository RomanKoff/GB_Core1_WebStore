using WebStore.Domain.Entities.Interfaces;

namespace WebStore.Domain.Entities
{

	public abstract class _EntityNamedBase
		: _EntityBase,
		IEntityNamed
	{
		public string Name { get; set; }
	}

}
