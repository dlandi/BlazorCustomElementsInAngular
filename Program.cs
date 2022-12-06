using BlazorCustomElements;
using Microsoft.AspNetCore.Components.Web;
using AlertMeter01.Views.Components;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddServerSideBlazor(options =>
{
    options.RootComponents.RegisterCustomElement<Counter>("blazor-counter");
    options.RootComponents.RegisterCustomElement<Counter>("blazor-counter2");
    //options.RootComponents.RegisterCustomElement<AlertMeterControl>("alert-meter");
    options.RootComponents.RegisterCustomElement<AlertMeterWrapper>("alert-meter");
});

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddSingleton<AlertMeter.Viewmodels.AnimationViewmodel>();


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

app.MapBlazorHub();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");




app.Run();
