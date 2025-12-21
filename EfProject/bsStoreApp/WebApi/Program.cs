using Microsoft.EntityFrameworkCore;
using NLog;
using Repositoires.EFCore;
using Services.Contracts;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile(Path.Combine(Directory.GetCurrentDirectory(), "nlog.config"));
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.AddControllers().AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly).AddNewtonsoftJson();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();
var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsProduction())
{
    app.UseHsts();
      
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
