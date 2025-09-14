using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PRN232.Lab1.CoffeeStore.Repository;
using PRN232.Lab1.CoffeeStore.Repository.DBContext;
using PRN232.Lab1.CoffeeStore.Repository.Implementation;
using PRN232.Lab1.CoffeeStore.Repository.UnitOfWork;
using PRN232.Lab1.CoffeeStore.Service;
using PRN232.Lab1.CoffeeStore.Service.Implementation;
using PRN232.Lab1.CoffeeStore.Service.Interface;
using PRN232.Lab1.CoffeeStore.Service.Model.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling =
                        ReferenceLoopHandling.Ignore;
                });

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

builder.Services.AddDbContext<CoffeeStoreDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//add scope for service
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IMenuService, MenuService>();

//add scope for repository
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<MenuRepository>();

//add scope for unit of work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
