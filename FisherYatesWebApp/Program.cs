using FisherYates.Services;
using FisherYates.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddControllersWithViews();

// Switched to singleton since the service is stateless and Random is using ThreadLocal to prevent the Concurrency Deadlocks. 
builder.Services.AddSingleton<IRandomNumberGenerator, RandomNumberGenerator>();
builder.Services.AddSingleton<IFisherYatesShuffleService, FisherYatesShuffleService>();

var app = builder.Build();
app.UseRouting();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}");
app.Run();