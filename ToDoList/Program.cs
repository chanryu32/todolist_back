using Microsoft.EntityFrameworkCore;
using ToDoList.Models.Database;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
    {
        //for when you're running on localhost
        builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
        .AllowAnyHeader().AllowAnyMethod();

    });
});


builder.Services.AddDbContext<TodoListDbContext>(
  options => options.UseSqlServer(configuration.GetConnectionString("TodoListDbContext")));

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

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
