using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebStore.App01.Models;

namespace WebStore.App01.Controllers
{

	public class BuildsController
		: Controller
	{

		private readonly List<BuildModel> BUILDS = new List<BuildModel>
		{
			new BuildModel
			{
				Keys = new string[] { "bm", "бм", "guap_bm", "гуап_бм" },
				Short = "Б.&nbsp;Морская&nbsp;67",
				Full = "Санкт-Петербург, ул.&nbsp;Большая Морская, д.&nbsp;67",
				Description = "Корпус на&nbsp;Б.&nbsp;Морской&nbsp;67 (главный&nbsp;корпус)",
				Address = "190000, Санкт-Петербург, ул.&nbsp;Большая Морская, д.&nbsp;67",
				Url = "https://guap.ru/sveden/common#bm67",
				MapLink = "https://yandex.ru/maps/-/COgavZ7J"
			},
			new BuildModel
			{
				Keys = new string[] { "jak", "як", "guap_jak", "гуап_як", "pk", "priem" },
				Short = "Якубовича&nbsp;26",
				Full = "Санкт-Петербург, ул.&nbsp;Якубовича, д.&nbsp;26",
				Description = "Приемная комиссия ГУАП",
				Address = "190000, Санкт-Петербург, ул.&nbsp;Якубовича, д.&nbsp;26",
				Url = "https://guap.ru/sveden/common#jak26",
				MapLink = "https://yandex.ru/maps/-/COgaJF6w"
			},
			new BuildModel
			{
				Keys = new string[] { "gast", "гаст", "guap_gast", "гуап_гаст" },
				Short = "Гастелло 15",
				Full = "Санкт-Петербург, ул.&nbsp;Гастелло, д.&nbsp;15",
				Description = "Корпус на&nbsp;Гастелло&nbsp;15 (Чесменский&nbsp;дворец)",
				Address = "196135, Санкт-Петербург, ул.&nbsp;Гастелло, д.&nbsp;15",
				Url = "https://guap.ru/sveden/common#gast15",
				MapLink = "https://yandex.ru/maps/-/COgaiE2h"
			},
			new BuildModel
			{
				Keys = new string[] { "lens", "ленс", "guap_lens", "гуап_ленс" },
				Short = "Ленсовета 14",
				Full = "Санкт-Петербург, ул.&nbsp;Ленсовета, д.&nbsp; 14",
				Description = "Корпус на&nbsp;Ленсовета&nbsp;14",
				Address = "196135, Санкт-Петербург, ул.&nbsp;Ленсовета, д.&nbsp;14",
				Url = "https://guap.ru/sveden/common#address",
				MapLink = "https://yandex.ru/maps/-/COgaYMzA"
			},
			new BuildModel
			{
				Keys = new string[] { "mosk", "моск", "guap_mosk", "гуап_моск" },
				Short = "Московский 149в",
				Full = "Санкт-Петербург, Московский&nbsp;пр., д.&nbsp;149в",
				Description = "Корпус на&nbsp;Московском&nbsp;149в",
				Address = "196128, Санкт-Петербург, Московский&nbsp;пр., д.&nbsp;149в",
				Url = "https://guap.ru/sveden/common#mosk149",
				MapLink = "https://yandex.ru/maps/-/COgauY7k"
			},
			new BuildModel
			{
				Keys = new string[] { "guk", "жук", "guap_guk", "гуап_жук" },
				Short = "Жукова 24",
				Full = "Санкт-Петербург, пр.&nbsp;Маршала&nbsp; Жукова, д.&nbsp;24",
				Description = "Общежитие на&nbsp;Жукова&nbsp;24",
				Address = "198302, Санкт-Петербург, пр.&nbsp;М.&nbsp;Жукова, д.&nbsp;24",
				Url = "https://guap.ru/sveden/common#guk24",
				MapLink = "https://yandex.ru/maps/-/COgaV68P"
			},
			new BuildModel
			{
				Keys = new string[] { "per", "пер", "guap_per", "гуап_пер" },
				Short = "Передовиков 13",
				Full = "Санкт-Петербург, пр.&nbsp;Передовиков, д.&nbsp;13",
				Description = "Общежитие на&nbsp;Передовиков&nbsp;13",
				Address = "195426, Санкт-Петербург, ул.&nbsp;Передовиков, д.&nbsp;13",
				Url = "https://guap.ru/sveden/common#per13",
				MapLink = "https://yandex.ru/maps/-/COgabZPW"
			},
			new BuildModel
			{
				Keys = new string[] { "per2", "пер2", "guap_per2", "гуап_пер2" },
				Short = "Передовиков 13а",
				Full = "Санкт-Петербург, пр.&nbsp;Передовиков, д.&nbsp;13а",
				Description = "Здание на&nbsp;Передовиков&nbsp;13а",
				Address = "195426, Санкт-Петербург, ул.&nbsp;Передовиков, д.&nbsp;13а",
				Url = "https://guap.ru/sveden/common#address",
				MapLink = "https://yandex.ru/maps/-/COgabZPW"
			},
			new BuildModel
			{
				Keys = new string[] { "war", "вар", "guap_war", "гуап_вар" },
				Short = "Варшавская 8",
				Full = "Санкт-Петербург, ул.&nbsp;Варшавская, д.&nbsp;8",
				Description = "Общежитие на&nbsp;Варшавской&nbsp;8",
				Address = "196105, Санкт-Петербург, ул.&nbsp;Варшавская, д.&nbsp;8",
				Url = "https://guap.ru/sveden/common#war8",
				MapLink = "https://yandex.ru/maps/-/COgaj-YG"
			},
			new BuildModel
			{
				Keys = new string[] { "igf", "игф", "guap_igf", "гуап_игф" },
				Short = "Ивангород, Котовского 1",
				Full = "Ивангород, ул.&nbsp;Котовского, д.&nbsp;1",
				Description = "Филиал ГУАП в&nbsp;Ивангороде",
				Address = "188491, Ленинградская&nbsp;обл., г.&nbsp;Ивангород, ул.&nbsp;Котовского, д.&nbsp;1",
				Url = "https://guap.ru/sveden/common#address",
				MapLink = "https://yandex.ru/maps/-/COgeA696"
			}
		};


		public IActionResult Index()
		{
			var model = BUILDS;
			if (model == null)
				return NotFound();
			return View(model);
		}


		public IActionResult Details(
			string id)
		{
			var model = BUILDS.FirstOrDefault(x => x.Keys.Contains(id));
			if (model == null)
				return NotFound();
			return View(model);
		}

	}

}
