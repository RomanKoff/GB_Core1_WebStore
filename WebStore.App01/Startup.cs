using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebStore.App01.Infra;
using WebStore.App01.Models;

namespace WebStore.App01
{

	public class Startup
	{

		public IConfiguration Configuration { get; }


		public Startup(
			IConfiguration configuration)
		{
			Configuration = configuration;
		}


		public void ConfigureServices(
			IServiceCollection services)
		{
			services.AddRazorPages()
				.AddRazorRuntimeCompilation();
			services.AddMvc()
				.AddNewtonsoftJson();
			services.AddSingleton<IRepositoryData<EmployeeModel>, InMemoryEmployeesRepository>();
			services.AddSingleton<IRepositoryData<CurrencyModel>, InMemoryCurrenciesRepository>();
		}


		public void Configure(
			IApplicationBuilder app,
			IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();
			app.UseStaticFiles();
			app.UseRouting();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});
		}

	}

}
