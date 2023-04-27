using Microsoft.EntityFrameworkCore;
using SchoolManagement;
using SchoolManagement.Data.Service;
using Serilog;
using System;

try
{
    Log.Information("Application started");


    var builder = WebApplication.CreateBuilder(args);


string connString = builder.Configuration.GetConnectionString("DefaultConnectionString");

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); 
Log.Logger = new LoggerConfiguration() 
    .ReadFrom.Configuration(configuration)
    .WriteTo.Console() .CreateLogger();





// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<StudentsService>();
builder.Services.AddTransient<ScoresService>();
builder.Services.AddTransient<StandardsService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});

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
}
catch (Exception ex) 
{
    Log.Error(ex, "The application failed");
}
finally
{
    Log.CloseAndFlush();
}
