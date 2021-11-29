using FunPlanner;
using FunPlannerShared.Controllers;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMudServices();

builder.Services
    .AddRefitClient<IWeatherForecastController>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7063"));

builder.Services
    .AddRefitClient<IPersonController>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7063"));

builder.Services
    .AddRefitClient<IEventController>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7063"));

await builder.Build().RunAsync();
