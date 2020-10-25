
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebStore.App01.ViewModels;
using WebStore.Domain.Entities;

namespace WebStore.App01.Controllers
{
	public class AccountController
		: Controller
	{

		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;


		public AccountController(
			UserManager<User> userManager,
			SignInManager<User> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}


		[HttpGet]
		public IActionResult Login()
		{
			return View(new LoginViewModel());
		}


		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(
			LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var res = await _signInManager.PasswordSignInAsync(
					model.UserName,
					model.Password,
					model.RememberMe,
					lockoutOnFailure: false);
				if (res.Succeeded)
				{
					if (Url.IsLocalUrl(model.ReturnUrl))
						return Redirect(model.ReturnUrl);
					return RedirectToAction("Index", "Home");
				}
			}
			ModelState.AddModelError("", "Вход невозможен");
			return View(model);
		}


		[HttpGet]
		public IActionResult Register()
		{
			return View(new RegisterUserViewModel());
		}


		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(
			RegisterUserViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);
			var user = new User
			{
				UserName = model.UserName,
				Email = model.Email
			};
			var createResult = await _userManager
				.CreateAsync(user, model.Password);
			if (createResult.Succeeded)
			{
				await _signInManager.SignInAsync(user, false);
				return RedirectToAction("Index", "Home");
			}
			foreach (var identityError in createResult.Errors)
				ModelState.AddModelError("", identityError.Description);
			return View(model);
		}


		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}

	}

}
