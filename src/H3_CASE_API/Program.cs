using AutoMapper;
using H3_CASE_API.DBContext;
using H3_CASE_API.Repository.Interfaces;
using H3_CASE_API.Repository.Repos;
using Infra.CrossCutting.Identity;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Identity.User;
using Services.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers(setupAction =>
//{
//    setupAction.ReturnHttpNotAcceptable = true;

//}).AddXmlDataContractSerializerFormatters();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddScoped<ICustomerRepos, CustomerRepos>();
builder.Services.AddScoped<IProductRepos, ProductRepos>();
builder.Services.AddScoped<IWarehouseRepos, WarehouseRepos>();
builder.Services.AddScoped<IOrdersRepos, OrdersRepos>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<MainDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



// WebAPI Config
builder.Services.AddControllers();


//// ASP.NET Identity Settings & JWT
//builder.Services.AddApiIdentityConfiguration(Configuration);

// Interactive AspNetUser (logged in)
// NetDevPack.Identity dependency
builder.Services.AddAspNetUserConfiguration();


// Swagger Config
builder.Services.AddSwaggerConfiguration();


//// .NET Native DI Abstraction
//builder.Services.AddDependencyInjectionConfiguration();


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())

app.UseSwaggerSetup();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


// Update warehouse
// update customer