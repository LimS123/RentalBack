using Arenda.DataAccess.Contracts;
using Arenda.DataAccess.Entities;
using Arenda.DataAccess.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder
    .Services
    .AddDatabaseContext(options =>
    {
        options.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
    })
    .AddDataAccess();

var app = builder.Build();
using var scope = app.Services.CreateScope();

var dataContext = scope.ServiceProvider.GetService<IDataContext>();
var roles = scope.ServiceProvider.GetService<DbSet<Role>>();

var user = new Role()
{
    Id = Guid.NewGuid(),
    Type = RoleType.User
};
var landlord = new Role()
{
    Id = Guid.NewGuid(),
    Type = RoleType.Landlord
};
var administrator = new Role()
{
    Id = Guid.NewGuid(),
    Type = RoleType.Administrator
};

roles.AddRange(new Role[]
{
    user, landlord, administrator
});

var users = scope.ServiceProvider.GetService<DbSet<User>>();
var admin = new User()
{
    Id = Guid.NewGuid(),
    FirstName = "Admin",
    LastName = "Admin",
    Email = "admin@gmail.com",
    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Adddm1n!")
};

admin.UserRoles.Add(new UserRole()
{
    Role = administrator
});
users.Add(admin);

dataContext.SaveChanges(CancellationToken.None);

app.Run();
