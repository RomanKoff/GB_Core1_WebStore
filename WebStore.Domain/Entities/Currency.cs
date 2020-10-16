using WebStore.Domain.Entities.Interfaces;

namespace WebStore.Domain.Entities
{

	public class Currency
		: _EntityNamedBase,
		IEntityNamed
	{
		public string Country { get; set; }
		public string Unit { get; set; }
		public string Char { get; set; }
		public double Rate { get; set; }
	}

}
