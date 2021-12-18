using Blazored.LocalStorage;
using FunPlanner;
using FunPlannerShared.Controllers;
using Microsoft.AspNetCore.Components.Authorization;
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

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<UserAuthorizationService>();
builder.Services.AddBlazoredLocalStorage();
//builder.Services.AddApiAuthorization();

builder.Services.AddOidcAuthentication(options =>
{
    // Configure your authentication provider options here.
    // For more information, see https://aka.ms/blazor-standalone-auth
    builder.Configuration.Bind("Local", options.ProviderOptions);
});

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
