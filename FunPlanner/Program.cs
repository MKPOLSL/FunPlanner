using Blazored.LocalStorage;
using FunPlanner;
using FunPlannerShared.Controllers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<UserAuthorizationService>();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Local", options.ProviderOptions);
});

builder.Services.AddMudServices();

var refitUrl = new Uri("https://localhost:7063");

builder.Services
    .AddRefitClient<IPersonController>()
    .ConfigureHttpClient(c => c.BaseAddress = refitUrl);

builder.Services
    .AddRefitClient<IEventController>()
    .ConfigureHttpClient(c => c.BaseAddress = refitUrl);

builder.Services
    .AddRefitClient<INoteController>()
    .ConfigureHttpClient(c => c.BaseAddress = refitUrl);

builder.Services
    .AddRefitClient<IAwardController>()
    .ConfigureHttpClient(c => c.BaseAddress = refitUrl);

builder.Services
    .AddRefitClient<IAuthorizationController>()
    .ConfigureHttpClient(c => c.BaseAddress = refitUrl);

await builder.Build().RunAsync();
