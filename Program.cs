using eBooks.Services.DataDB;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using eBooks.Services.Generics;
using eBooks.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Book));

builder.Services.AddTransient<IService, BooksService>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<EBooksContext>(options =>
options.UseSqlServer("Server=localhost, 1434;Initial Catalog=eBooks; user=sa; Password=Tarik123!;TrustServerCertificate=True;"));
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
