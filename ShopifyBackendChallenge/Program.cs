using AutoMapper;
using Microsoft.EntityFrameworkCore;

using ShopifyBackendChallenge.Models;
using ShopifyBackendChallenge.Repositories;
using ShopifyBackendChallenge.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Initializes service.
builder.Services.AddSingleton<IInventoryService, InventoryService>();

// Initializes repository.
// Read db's connection string from appsettings
var config = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
var dbConnectionString = config.GetSection("ConnectionString").Get<string>();
builder.Services.AddDbContextFactory<InventoryContext>(options => options.UseSqlServer(dbConnectionString));
builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<InventoryItem, InventoryItemStorageEntity>();
    cfg.CreateMap<InventoryItemStorageEntity, InventoryItem>();
    cfg.CreateMap<InventoryItemAddRequest, InventoryItemStorageEntity>();
});
builder.Services.AddSingleton<IMapper>(new Mapper(mapperConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();
