using Microsoft.EntityFrameworkCore;
using VendingMachine.DataAccess.Contexts;
using VendingMachine.DataAccess.Repositories;
using VendingMachine.Domain.Business.IServices;
using VendingMachine.Domain.DataAccess.IRepositories;
using VendingMachine.WebServices.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = new ConfigurationBuilder();
configuration.AddJsonFile("appsettings.json");
var connectionString = configuration.Build().GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ProductContext>(opt => opt.UseNpgsql(connectionString));
builder.Services.AddScoped<IProductRepository, ProductPersistentRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
