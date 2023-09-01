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
        CountProject = 20, //генератор записей в табл Проекты компании
        CountDesignObject = 10,//генератор записей в табл Объекты проектирования 
        CountDocumentations = 5,//генератор записей в табл документы  
        MaxLevel = 10//макс уровень объекта проектирования 
    };

    var cr =  new Data.Generator(db).Start(parametrs);

    Console.WriteLine($"add record {cr}");

    
}