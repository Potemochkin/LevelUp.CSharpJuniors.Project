using StoreProject.Api.DAL;
using StoreProject.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var dbConnString = builder.Configuration.GetConnectionString("Products");

//Dependencies
// хотим получить доступ к БД. БД контекст это объект, который отображает содержимое БД. С ним работает слой работы с данными (10 урок тайм:59 минут)
builder.Services.AddDbContext<ProductsDbContext>(options => options.UseSqlServer(dbConnString));

builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IUsersService, UsersService>();


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
