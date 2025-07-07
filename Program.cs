using users_api.Services;
using users_api.Database;
using users_api.DAO;
using users_api.Models;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<OracleDbService>();
builder.Services.AddScoped<IUserDao, UserDAO>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<UsersContext, UsersContext>();

//ef connection
builder.Services.AddDbContext<UsersContext>(options => {
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
