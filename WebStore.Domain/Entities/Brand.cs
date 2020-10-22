using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Interfaces;

namespace WebStore.Domain.Entities
{

	[Table("Brands")]
	public class Brand
		: _EntityNamedBase,
		IEntityOrdered
	{
		public int Order { get; set; }

		public virtual ICollection<Product> Products { get; set; }
	}

}
