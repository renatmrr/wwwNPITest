using DB.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<Context>(options => options.UseInMemoryDatabase("DbMemory"));

var app = builder.Build();

Generator(app);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Api",
    pattern: "api/{controller}/{action}/{id}"
);
app.UseDefaultFiles();
app.UseStaticFiles();

/*
app.MapGet("/", () => "Hello World!");
*/
app.Run();

static void Generator(WebApplication app)
{
    var scope = app.Services.CreateScope();

    using var db = scope.ServiceProvider.GetService<Context>() ?? throw new Exception("Service is null");


    Data.Parametrs parametrs = new ()
    {
        CountProject = 50,
        CountDesignObject = 10,
        CountDocumentations = 10,
        MaxLevel = 10
    };

    var cr =  new Data.Generator(db).Start(parametrs);

    Debug.WriteLine($"add record {cr}");

    
}