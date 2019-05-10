using Afk4Events.WebClient.ViewModels;
using Blazor.Extensions.Storage;
using Microsoft.AspNetCore.Blazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Afk4Events.WebClient
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<LoginViewModel>();
			services.AddSingleton<IUriHelper>(WebAssemblyUriHelper.Instance);
			services.AddStorage();
		}

		public void Configure(IComponentsApplicationBuilder app)
		{
			app.AddComponent<App>("app");
		}
	}
}
