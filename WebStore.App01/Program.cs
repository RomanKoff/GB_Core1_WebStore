using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using WebStore.DAL;

namespace WebStore.App01
{

	public class Program
	{

		public static void Main(
			string[] args)
		{
			// BuildWebHost(args).Run();
			// // CreateHostBuilder(args).Build().Run();

			var host = CreateHostBuilder(args).Build();
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{
					var context = services.GetRequiredService<WebStoreContext>();
					DbInitializer.Initialize(context);
				}
				catch (Exception ex)
				{
					var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "Oops. Something went wrong at DB initializing...");
				}
			}
			host.Run();
		}


		//public static IWebHost BuildWebHost(
		//	string[] args) =>
		//		WebHost.CreateDefaultBuilder(args)
		//			.UseStartup<Startup>()
		//			.Build();


		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});

	}

}
