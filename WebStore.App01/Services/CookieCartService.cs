using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.App01.Services.Interfaces;
using WebStore.App01.ViewModels;
using WebStore.Domain.Entities;

namespace WebStore.Infrastructure.Services
{

	public class CookieCartService
		: ICartService
	{

		private readonly IProductService _productService;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly string _cartName;

		private HttpContext _context => _httpContextAccessor.HttpContext;
		private HttpRequest _request => _context.Request;
		private HttpResponse _response => _context.Response;

		private Cart _cart
		{
			get
			{
				var cookie = _request.Cookies[_cartName];
				string json = string.Empty;
				Cart cart = null;
				if (cookie == null)
				{
					cart = new Cart { Items = new List<CartItem>() };
					json = JsonConvert.SerializeObject(cart);
					_response.Cookies.Append(
						_cartName, json, new CookieOptions
						{
							Expires = DateTime.Now.AddDays(1)
						});
					return cart;
				}
				json = cookie;
				cart = JsonConvert.DeserializeObject<Cart>(json);
				_response.Cookies.Delete(_cartName);
				_response.Cookies.Append(
					_cartName, json, new CookieOptions()
					{
						Expires = DateTime.Now.AddDays(1)
					});
				return cart;
			}
			set
			{
				var json = JsonConvert.SerializeObject(value);
				_response.Cookies.Delete(_cartName);
				_response.Cookies.Append(
					_cartName, json, new CookieOptions()
					{
						Expires = DateTime.Now.AddDays(1)
					});
			}
		}


		public CookieCartService(
			IProductService productService,
			IHttpContextAccessor httpContextAccessor)
		{
			_productService = productService;
			_httpContextAccessor = httpContextAccessor;
			_cartName = "cart_"
				+ ((_context.User.Identity.IsAuthenticated)
					? _context.User.Identity.Name
					: "");
		}


		public void AddToCart(
			int id)
		{
			var cart = _cart;
			var item = cart.Items.FirstOrDefault(
				x => x.ProductId == id);
			if (item != null)
				item.Quantity++;
			else
				cart.Items.Add(new CartItem
				{
					ProductId = id,
					Quantity = 1
				});
			_cart = cart;
		}


		public void DecrementFromCart(
			int id)
		{
			var cart = _cart;
			var item = cart.Items.FirstOrDefault(
				x => x.ProductId == id);
			if (item == null)
				return;
			if (item.Quantity > 0)
				item.Quantity--;
			if (item.Quantity == 0)
				cart.Items.Remove(item);
			_cart = cart;
		}


		public void RemoveFromCart(
			int id)
		{
			var cart = _cart;
			var item = cart.Items.FirstOrDefault(
				x => x.ProductId == id);
			if (item == null)
				return;
			cart.Items.Remove(item);
			_cart = cart;
		}


		public void RemoveAll()
		{
			_cart.Items.Clear();
		}


		public CartViewModel TransformCart()
		{
			var products = _productService.GetProducts(
				new ProductFilter
				{
					Ids = _cart.Items.Select(i => i.ProductId).ToList()
				}).Select(p => new ProductViewModel()
				{
					Id = p.Id,
					ImageUrl = p.ImageUrl,
					Name = p.Name,
					Order = p.Order,
					Price = p.Price,
					Brand = p.Brand != null ? p.Brand.Name : string.Empty
				}).ToList();
			return new CartViewModel
			{
				Items = _cart.Items.ToDictionary(
					x => products.First(y => y.Id == x.ProductId),
					x => x.Quantity)
			};
		}

	}

}