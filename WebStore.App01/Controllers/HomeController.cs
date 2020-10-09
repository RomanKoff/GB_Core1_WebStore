using Microsoft.AspNetCore.Mvc;

namespace WebStore.App01.Controllers
{

	public class HomeController
		: Controller
	{

		public HomeController()
		{
		}


		public IActionResult Index()
		{
			return View();
		}


		public IActionResult Blog()
		{
			return View();
		}


		public IActionResult BlogSingle()
		{
			return View();
		}


		public IActionResult Cart()
		{
			return View();
		}


		public IActionResult Checkout()
		{
			return View();
		}


		public IActionResult ContactUs()
		{
			return View();
		}


		public IActionResult Login()
		{
			return View();
		}


		public IActionResult Error404()
		{
			return View();
		}


		public IActionResult ProductDetails()
		{
			return View();
		}


		public IActionResult Shop()
		{
			return View();
		}

	}

}
