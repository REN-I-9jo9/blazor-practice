using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorPractice;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<BlazorPractice.Components.App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddBlazorBootstrap();

await builder.Build().RunAsync();
