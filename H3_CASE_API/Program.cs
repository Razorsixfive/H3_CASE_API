global using H3_CASE_API.DBContext;
global using Microsoft.EntityFrameworkCore;
global using H3_CASE_API.Repository.Interfaces;
global using H3_CASE_API.Repository.Repos;
global using AutoMapper;
global using Newtonsoft;

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
            
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<MainDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();