using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PRN232.Lab1.CoffeeStore.Repository.DBContext;
using PRN232.Lab1.CoffeeStore.Repository.Implementation;
using PRN232.Lab1.CoffeeStore.Repository.Interface;
using PRN232.Lab1.CoffeeStore.Repository.UnitOfWork;
using PRN232.Lab1.CoffeeStore.Service;
using PRN232.Lab1.CoffeeStore.Service.Implementation;
using PRN232.Lab1.CoffeeStore.Service.Interface;
using PRN232.Lab1.CoffeeStore.Service.Model.Mapper;
using PRN232.Lab1.CoffeeStore.Service.ServiceProviders;

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

//Dbcontext
builder.Services.AddDbContext<CoffeeStoreDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//add scope for service
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IProductInMenuService, ProductInMenuService>();

//add scope for repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IProductInMenuRepository, ProductInMenuRepository>();

//add scope for unit of work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//add scope for service provider
builder.Services.AddScoped<IServiceProviders, ServiceProviders>();

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
