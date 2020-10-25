using Microsoft.AspNetCore.Mvc;

namespace WebStore.App01.ViewComponents
{

	public class AuthViewComponent
		: ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}

}
