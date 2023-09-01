using DB.Model;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<Context>(options => options.UseInMemoryDatabase("DbMemory"));

var app = builder.Build();

Generator(app);

app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();
app.Run();

static void Generator(WebApplication app)
{
    var scope = app.Services.CreateScope();

    using var db = scope.ServiceProvider.GetService<Context>() ?? throw new Exception("Service is null");


    Data.Parametrs parametrs = new ()
    {
        CountProject = 50,
        CountDesignObject = 10,
        CountDocumentations = 5,
        MaxLevel = 10
    };

    var cr =  new Data.Generator(db).Start(parametrs);

    Console.WriteLine($"add record {cr}");

    
}