using System.Text.Json.Serialization;
using BuildingBlocks.Models;
using BuildingBlocks.Security;
using Core.Platform;
using Core.Platform.Middleware;
using Domain.Repositories;
using Infrastructure.Command;
using Infrastructure.Database;
using Infrastructure.Query;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Modules.Auth.Infrastructure;
using Modules.Classroom.Infrastructure;
using Modules.Course.Infrastructure;
using Modules.Notification.Infrastructure;
using Modules.Payroll.Infrastructure;
using Modules.Student.Infrastructure;
using Modules.Teacher.Infrastructure;
using Modules.Timesheet.Infrastructure;
using TimeSheetManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICommandRunner, Command>();
builder.Services.AddScoped<IQueryRunner, QueryRunner>();
builder.Services.AddMediatRServices();
builder.Services.RegisterServices();

// Multi-Tenant Context
builder.Services.AddScoped<ITenantContext, TenantContext>();

// Permission-Based Authorization
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

// JWT Bearer Authentication (Stateless verification against auth-service JWKS)
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var authority = jwtSettings.GetValue<string>("Authority") ?? "http://localhost:8080";
var audience = jwtSettings.GetValue<string>("Audience") ?? "core-platform-api";
var requireHttps = jwtSettings.GetValue<bool>("RequireHttpsMetadata", false);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = authority;
        options.Audience = audience;
        options.RequireHttpsMetadata = requireHttps;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });

// Register Modules
builder.Services.AddAuthModule()
                .AddStudentModule()
                .AddTeacherModule()
                .AddClassroomModule()
                .AddCourseModule()
                .AddTimesheetModule()
                .AddPayrollModule()
                .AddNotificationModule();

var connectionString = builder.Configuration.GetConnectionString("CorePlatformConnectionString");
var serverVersion = ServerVersion.AutoDetect(connectionString);
builder.Services.AddDbContext<MySqlDBContext>(options =>
    options.UseMySql(connectionString, serverVersion));

var app = builder.Build();

// Global error handling
app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ApiKeyMiddleware>();

app.UseAuthentication();
app.UseMiddleware<TenantMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
