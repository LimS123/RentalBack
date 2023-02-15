using Arenda.BusinessLogic.Infrastructure;
using Arenda.DataAccess.Infrastructure;
using Arenda.WebAPI.Infrastructure;
using Arenda.WebAPI.Infrastructure.Configurations;
using Arenda.WebAPI.Infrastructure.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder
    .AddAppSettings(configuration);

builder
    .Services
    .AddDatabaseContext(options =>
    {
        options.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
    })
    .AddDataAccess()
    .AddBusinessLogic()
    .AddWebApi(configuration)
    .AddControllers();

var app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

namespace Arenda.WebAPI
{
    public partial class Program { }
}

