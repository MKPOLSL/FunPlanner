using FunPlanner;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//MudBlazor
//builder.Services.AddScoped<IDialogService, DialogService>();
//builder.Services.AddScoped<Snackbar>();
//builder.Services.AddScoped<MudDialogProvider>();
//builder.Services.AddScoped<MudPopoverProvider>();
//builder.Services.AddScoped<MudPopoverService>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
