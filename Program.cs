using CQRSExample.Data;
using CQRSExample.Models;
using CustomCQRS.CQRS.Commands;
using CustomCQRS.CQRS.Handlers;
using CustomCQRS.CQRS.Interfaces;
using CustomCQRS.CQRS.Mediator;
using CustomCQRS.CQRS.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddControllers();


builder.Services.AddTransient<IRequestHandler<CreateProductCommand, int>, CreateProductHandler>();
builder.Services.AddTransient<IRequestHandler<GetAllProductsQuery, List<Product>>, GetAllProductsHandler>();

builder.Services.AddScoped<DIMediator>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
