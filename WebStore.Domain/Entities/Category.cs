using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Interfaces;

namespace WebStore.Domain.Entities
{

	[Table("Categories")]
	public class Category
		: _EntityNamedBase,
		IEntityOrdered, IEntityTree
	{
		public int Order { get; set; }
		public int? ParentId { get; set; }

		[ForeignKey("ParentId")]
		public virtual Category ParentCategory { get; set; }

		public virtual ICollection<Product> Products { get; set; }
	}

}
