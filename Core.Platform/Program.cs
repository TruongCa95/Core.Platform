using Core.Platform;
using Domain.Repositories;
using Infrastructure.Command;
using Infrastructure.Database;
using Infrastructure.Query;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using TimeSheetManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICommandRunner, Command>();
builder.Services.AddScoped<IQueryRunner, QueryRunner>();
builder.Services.AddMediatRServices();
builder.Services.RegisterServices();

var connectionString = builder.Configuration.GetConnectionString("CorePlatformConnectionString");
var serverVersion = ServerVersion.AutoDetect(connectionString);
builder.Services.AddDbContext<MySqlDBContext>(options =>
    options.UseMySql(connectionString, serverVersion));
var app = builder.Build();

// Configure the HTTP request pipeline.     
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.Run();
