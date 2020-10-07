using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using WebStore.App01.Models;

namespace WebStore.App01.Controllers
{

	public class HomeController
		: Controller
	{

		public IEnumerable<TeacherModel> Teachers { get; private set; }


		public HomeController()
		{
			string json;
			using (var client = new WebClient())
			{
				json = client.DownloadString(
					"http://download.guap.ru/sveden/_pps/pps.json");
			}
			this.Teachers = JsonConvert.DeserializeObject<IEnumerable<TeacherModel>>(json);
		}


		public IActionResult Index()
		{
			return View();
		}


		public IActionResult ListTeachers()
		{
			var model = Teachers;
			if (model == null)
				return NotFound();
			return View(model);
		}


		public IActionResult TeacherDetails(
			string id)
		{
			var model = Teachers.FirstOrDefault(x => x.ProId == id);
			if (model == null)
				return NotFound();
			return View(model);
		}

	}

}
