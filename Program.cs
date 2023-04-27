using Microsoft.AspNetCore.SpaServices.AngularCli;
using MintPlayer.AspNetCore.SpaServices.Prerendering;
using MintPlayer.AspNetCore.SpaServices.Routing;
using test;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();


builder.Services.AddSpaStaticFiles(config =>
{
    config.RootPath = "ClientApp/dist";
});
builder.Services.AddSpaPrerenderingService<SpaPrerenderingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                spa.UseSpaPrerendering(options =>
                {
                    options.BootModuleBuilder = app.Environment.IsDevelopment() ? new AngularCliBuilder(npmScript: "build:ssr") : null;
                    options.BootModulePath = $"{spa.Options.SourcePath}/dist/server/main.js";
                    options.ExcludeUrls = new[] { "/sockjs-node" };
                });

                if (app.Environment.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
