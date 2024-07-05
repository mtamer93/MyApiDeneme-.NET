using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyApiDeneme.BLL;
using MyApiDeneme.DAL.Concrete;
using MyApiDeneme.DAL.Context;
using MyApiDeneme.DAL.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<NorthwindDbContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });

builder.Services.AddScoped<IProductsDAL, ProductsDAL>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

// Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    // c.RoutePrefix = string.Empty; // SwaggerUI'nin kok URL'de sunulmasi icin
});

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
