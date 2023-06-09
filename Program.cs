using eBooks.Services;
using eBooks.Services.DataDB;
using eBooks.Services.Orders;
using eBooks.Services.Users;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Book));

builder.Services.AddTransient<IOrdersService, OrdersService>();
builder.Services.AddTransient<IUserService, UserService>();

//Add IOrdersService and OrdersService

builder.Services.AddAutoMapper(typeof(MappingProfile));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EBooksContext>(options =>
options.UseSqlServer("Server=localhost,1434;Database=eBooks;User=sa;Password=Tarik123!;TrustServerCertificate=true;"));
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
