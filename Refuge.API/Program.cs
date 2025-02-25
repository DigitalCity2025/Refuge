using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Refuge.Application.Abstractions.Repositories;
using Refuge.Application.Abstractions.Services;
using Refuge.Application.Services;
using Refuge.DAL;
using Refuge.DAL.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(o =>
    // sérialiser les enums en string 
    o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<RefugeContext>(b => 
    b.UseSqlServer(builder.Configuration.GetConnectionString("Main"))
);

builder.Services.AddScoped<ICatService, CatService>();
builder.Services.AddScoped<ICatRepository, CatRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
