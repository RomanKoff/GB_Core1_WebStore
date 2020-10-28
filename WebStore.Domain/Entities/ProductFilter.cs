using System.Collections.Generic;

namespace WebStore.Domain.Entities
{

	public class ProductFilter
	{
		public int? CategoryId { get; set; }
		public int? BrandId { get; set; }
		public List<int> Ids { get; set; }
	}

}
