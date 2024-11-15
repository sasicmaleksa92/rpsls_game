using Microsoft.EntityFrameworkCore;
using RockPaperScissorsLizardSpock.Application;
using RockPaperScissorsLizardSpock.Infrastructure.Persistance.DbContext;
using RockPaperScissorsLizardSpock.Infrastructure.ServiceExtensions;
using RockPaperScissorsLizardSpock.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureLogging();
builder.ConfigureCorsPolicy();

// DI services
builder.Services.AddInjections(builder.Configuration);
builder.Services.AddInjectionApplication();
builder.Services.AddInjectionInfrastructure(builder.Configuration);

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.EnableAnnotations();
});


var app = builder.Build();


app.UseExceptionHandler();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors("RockPaperScissorsLizardSpock");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Logger.LogInformation("ConnectionStrings: " + app.Configuration["ConnectionStrings:DefaultConnection"]);
//EF Core migrations
using (var serviceScope = app.Services.CreateScope())
{
    var gameDatabase = serviceScope.ServiceProvider.GetRequiredService<GameDbContext>().Database;
    if (gameDatabase.IsRelational())
        gameDatabase.Migrate();
}

//Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(new Swashbuckle.AspNetCore.Swagger.SwaggerOptions()
    {
        RouteTemplate = "api/swagger/{documentName}/swagger.json"
    });
    app.UseSwaggerUI((opts) =>
    {
        opts.RoutePrefix = "api/swagger";
    });
}

app.UseHttpLogging();
app.Run();

public partial class Program { }
