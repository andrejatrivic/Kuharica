using kuharica.Data.Entities;
using kuharica.Data.Repository;
using Kuharica.Data;
using Kuharica.Data.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Repository

builder.Services.AddScoped<IRepository<Category>, Repository<Category>>();
builder.Services.AddScoped<IRepository<ConvertMeasurementUnit>, Repository<ConvertMeasurementUnit>>();
builder.Services.AddScoped<IRepository<Ingredient>, Repository<Ingredient>>();
builder.Services.AddScoped<IRepository<Meal>, Repository<Meal>>();
builder.Services.AddScoped<IRepository<MealIngredient>, Repository<MealIngredient>>();
builder.Services.AddScoped<IRepository<MeasurementUnit>, Repository<MeasurementUnit>>();
builder.Services.AddScoped<IRepository<NutritionalValue>, Repository<NutritionalValue>>();

#endregion

#region Database

builder.Services.AddDbContext<KuharcaDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

#endregion

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
