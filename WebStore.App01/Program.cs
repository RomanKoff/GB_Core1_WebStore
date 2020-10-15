using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebStore.App01
{

	public class Program
	{

		public static void Main(
			string[] args)
		{
			BuildWebHost(args).Run();
			//CreateHostBuilder(args).Build().Run();
		}


		public static IWebHost BuildWebHost(
			string[] args) =>
				WebHost.CreateDefaultBuilder(args)
					.UseStartup<Startup>()
					.Build();


		//public static IHostBuilder CreateHostBuilder(string[] args) =>
		//	Host.CreateDefaultBuilder(args)
		//		.ConfigureWebHostDefaults(webBuilder =>
		//		{
		//			webBuilder.UseStartup<Startup>();
		//		});

	}

}
