﻿using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Interfaces;

namespace WebStore.Domain.Entities
{

	[Table("Products")]
	public class Product
		: _EntityNamedBase,
		IEntityOrdered
	{

		public int Order { get; set; }
		public int CategoryId { get; set; }
		public int BrandId { get; set; }
		public string ImageUrl { get; set; }
		public decimal Price { get; set; }
		
		[ForeignKey("CategoryId")]
		public virtual Category Category { get; set; }

		[ForeignKey("BrandId")]
		public virtual Brand Brand { get; set; }

	}

}