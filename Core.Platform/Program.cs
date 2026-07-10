using System.Text.Json.Serialization;
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

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Serialize/accept enums by name (e.g. "APlus") instead of numeric values,
        // so reordering KiEnums/LevelEnums does not silently change the API contract.
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
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

// Global error handling must wrap the entire pipeline, so it has to be the
// first middleware registered - otherwise exceptions thrown by the endpoints
// (including FluentValidation ValidationException) are never caught here.
app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Optional API-key gate. Enforced only when "ApiKey" is configured in
// appsettings; left empty it is a no-op so local/dev calls keep working.
app.UseMiddleware<ApiKeyMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
