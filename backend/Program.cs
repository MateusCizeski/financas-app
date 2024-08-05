using backend.Application.Users;
using backend.Application.Users.Mapper;
using backend.Data;
using backend.Repositories.Users;
using backend.Services.Users;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ReceivesContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    .EnableSensitiveDataLogging()
    .LogTo(Console.WriteLine, LogLevel.Information));

builder.Services.AddTransient<IRepUsers, RepUsers>();
builder.Services.AddScoped<IServUsers, ServUsers>();
builder.Services.AddScoped<IAplicUsers, AplicUsers>();
builder.Services.AddScoped<IMapperUsers, MapperUsers>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
