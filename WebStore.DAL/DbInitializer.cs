﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebStore.Domain.Entities;

namespace WebStore.DAL
{

	public static class DbInitializer
	{

		public static void Initialize(
			WebStoreContext context)
		{
			context.Database.EnsureCreated();

			// categories
			if (!context.Categories.Any())
			{
				var categories = new List<Category>
				{
					new Category { Id = 1, Name = "Sportswear 2", Order = 0, ParentId = null },
					new Category { Id = 2, Name = "Nike", Order = 0, ParentId = 1 },
					new Category { Id = 3, Name = "Under Armour", Order = 1, ParentId = 1 },
					new Category { Id = 4, Name = "Adidas", Order = 2, ParentId = 1 },
					new Category { Id = 5, Name = "Puma", Order = 3, ParentId = 1 },
					new Category { Id = 6, Name = "ASICS", Order = 4, ParentId = 1 },
					new Category { Id = 7, Name = "Mens", Order = 1, ParentId = null },
					new Category { Id = 8, Name = "Fendi", Order = 0, ParentId = 7 },
					new Category { Id = 9, Name = "Guess", Order = 1, ParentId = 7 },
					new Category { Id = 10, Name = "Valentino", Order = 2, ParentId = 7 },
					new Category { Id = 11, Name = "Dior", Order = 3, ParentId = 7 },
					new Category { Id = 12, Name = "Versace", Order = 4, ParentId = 7 },
					new Category { Id = 13, Name = "Armani", Order = 5, ParentId = 7 },
					new Category { Id = 14, Name = "Prada", Order = 6, ParentId = 7 },
					new Category { Id = 15, Name = "Dolce and Gabbana", Order = 7, ParentId = 7 },
					new Category { Id = 16, Name = "Chanel", Order = 8, ParentId = 7 },
					new Category { Id = 17, Name = "Gucci", Order = 1, ParentId = 7 },
					new Category { Id = 18, Name = "Womens", Order = 2, ParentId = null },
					new Category { Id = 19, Name = "Fendi", Order = 0, ParentId = 18 },
					new Category { Id = 20, Name = "Guess", Order = 1, ParentId = 18 },
					new Category { Id = 21, Name = "Valentino", Order = 2, ParentId = 18 },
					new Category { Id = 22, Name = "Dior", Order = 3, ParentId = 18 },
					new Category { Id = 23, Name = "Versace", Order = 4, ParentId = 18 },
					new Category { Id = 24, Name = "Kids", Order = 3, ParentId = null },
					new Category { Id = 25, Name = "Fashion", Order = 4, ParentId = null },
					new Category { Id = 26, Name = "Households", Order = 5, ParentId = null },
					new Category { Id = 27, Name = "Interiors", Order = 6, ParentId = null },
					new Category { Id = 28, Name = "Clothing", Order = 7, ParentId = null },
					new Category { Id = 29, Name = "Bags", Order = 8, ParentId = null },
					new Category { Id = 30, Name = "Shoes", Order = 9, ParentId = null }
				};
				using var trans = context.Database.BeginTransaction();
				foreach (var section in categories)
					context.Categories.Add(section);
				context.Database.ExecuteSqlRaw(
					"SET IDENTITY_INSERT [dbo].[Categories] ON");
				context.SaveChanges();
				context.Database.ExecuteSqlRaw(
					"SET IDENTITY_INSERT [dbo].[Categories] OFF");
				trans.Commit();
			}

			// brands
			if (!context.Brands.Any())
			{
				var brands = new List<Brand>
				{
					new Brand { Id = 1, Name = "Acne", Order = 0 },
					new Brand { Id = 2, Name = "Grüne Erde", Order = 1 },
					new Brand { Id = 3, Name = "Albiro", Order = 2 },
					new Brand { Id = 4, Name = "Ronhill", Order = 3 },
					new Brand { Id = 5, Name = "Oddmolly", Order = 4 },
					new Brand { Id = 6, Name = "Boudestijn", Order = 5 },
					new Brand { Id = 7, Name = "Rösch creative culture", Order = 6 },
				};
				using var trans = context.Database.BeginTransaction();
				foreach (var brand in brands)
					context.Brands.Add(brand);
				context.Database.ExecuteSqlRaw(
					"SET IDENTITY_INSERT [dbo].[Brands] ON");
				context.SaveChanges();
				context.Database.ExecuteSqlRaw(
					"SET IDENTITY_INSERT [dbo].[Brands] OFF");
				trans.Commit();
			}

			// products
			if (!context.Products.Any())
			{
				var products = new List<Product>
				{
					new Product() { Id = 1, Name = "Pixel Infrared Thermal Imager", Price = 1025, ImageUrl = "product1.jpg", Order = 0, CategoryId = 2, BrandId = 1 },
					new Product() { Id = 2, Name = "Mini Electric Welding Machine", Price = 1025, ImageUrl = "product2.jpg", Order = 1, CategoryId = 2, BrandId = 1 },
					new Product() { Id = 3, Name = "Digital Microscope", Price = 1025, ImageUrl = "product3.jpg", Order = 2, CategoryId = 2, BrandId = 1 },
					new Product() { Id = 4, Name = "USB Digital Storage Oscilloscope", Price = 1025, ImageUrl = "product4.jpg", Order = 3, CategoryId = 2, BrandId = 1 },
					new Product() { Id = 5, Name = "Intelligent 2 in 1 Digital", Price = 1025, ImageUrl = "product5.jpg", Order = 4, CategoryId = 2, BrandId = 2 },
					new Product() { Id = 6, Name = "Spindle Motor", Price = 1025, ImageUrl = "product6.jpg", Order = 5, CategoryId = 2, BrandId = 2 },
					new Product() { Id = 7, Name = "Digits LED Display", Price = 1025, ImageUrl = "product7.jpg", Order = 6, CategoryId = 2, BrandId = 2 },
					new Product() { Id = 8, Name = "Digital Oscilloscope", Price = 1025, ImageUrl = "product8.jpg", Order = 7, CategoryId = 25, BrandId = 2 },
					new Product() { Id = 9, Name = "HD Intelligent Graphical Digital Oscilloscope Multimeter", Price = 1025, ImageUrl = "product9.jpg", Order = 8, CategoryId = 25, BrandId = 2 },
					new Product() { Id = 10, Name = "Cordless Brushless", Price = 1025, ImageUrl = "product10.jpg", Order = 9, CategoryId = 25, BrandId = 3 },
					new Product() { Id = 11, Name = "Smart Laser Engraver DIY", Price = 1025, ImageUrl = "product11.jpg", Order = 10, CategoryId = 25, BrandId = 3 },
					new Product() { Id = 12, Name = "Intelligent Solar Pure Sine Wave Inverter", Price = 1025, ImageUrl = "product12.jpg", Order = 11, CategoryId = 25, BrandId = 3 }
				};
				using var trans = context.Database.BeginTransaction();
				foreach (var product in products)
					context.Products.Add(product);
				context.Database.ExecuteSqlRaw(
					"SET IDENTITY_INSERT [dbo].[Products] ON");
				context.SaveChanges();
				context.Database.ExecuteSqlRaw(
					"SET IDENTITY_INSERT [dbo].[Products] OFF");
				trans.Commit();
			}
		}


		public static void InitializeUsers(
			WebStoreContext context)
		{
			ensureBaseRoles(context);
			ensureBaseUsers(context);
		}


		// privates

		private static void ensureBaseRoles(
			WebStoreContext context)
		{
			var roleStore = new RoleStore<IdentityRole>(context);
			var roleManager = new RoleManager<IdentityRole>(
				roleStore,
				new IRoleValidator<IdentityRole>[] { },
				new UpperInvariantLookupNormalizer(),
				new IdentityErrorDescriber(),
				null);
			if (!roleManager.RoleExistsAsync("Users").Result)
				_ = roleManager.CreateAsync(new IdentityRole("Users")).Result;
			if (!roleManager.RoleExistsAsync("Administrators").Result)
				_ = roleManager.CreateAsync(new IdentityRole("Administrators")).Result;
		}

		private static void ensureBaseUsers(
			WebStoreContext context)
		{
			var userStore = new UserStore<User>(context);
			var userManager = new UserManager<User>(
				userStore,
				new OptionsManager<IdentityOptions>(
					new OptionsFactory<IdentityOptions>(
						new IConfigureOptions<IdentityOptions>[] { },
						new IPostConfigureOptions<IdentityOptions>[] { })),
				new PasswordHasher<User>(),
				new IUserValidator<User>[] { },
				new IPasswordValidator<User>[] { },
				new UpperInvariantLookupNormalizer(),
				new IdentityErrorDescriber(),
				null,
				null);
			if (userStore
				.FindByEmailAsync("admin1@domain.com", CancellationToken.None)
				.Result == null)
			{
				var user = new User()
				{
					UserName = "Admin1",
					Email = "admin1@domain.com"
				};
				var result = userManager.CreateAsync(user, "Pa$$w0rd").Result;
				if (result == IdentityResult.Success)
					_ = userManager
						.AddToRoleAsync(user, "Administrators")
						.Result;
			}
			if (userStore
				.FindByEmailAsync("user1@domain.com", CancellationToken.None)
				.Result == null)
			{
				var user = new User()
				{
					UserName = "User1",
					Email = "user1@domain.com"
				};
				var result = userManager.CreateAsync(user, "Pa$$w0rd").Result;
				if (result == IdentityResult.Success)
					_ = userManager
						.AddToRoleAsync(user, "Users")
						.Result;
			}
		}

	}

}
