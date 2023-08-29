using HelpDeskAPI.Models;
using Microsoft.EntityFrameworkCore;
using HelpDeskAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// NEW LINES OF CODE FOR EF
IConfigurationBuilder buildConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
IConfiguration configuration = buildConfig.Build();
builder.Services.AddDbContext <HelpDeskDbContext> (options => options.UseSqlServer(configuration.GetConnectionString("HelpDeskDB"))); // Make sure to use the right name
// END OF NEW LINES

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
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

app.UseCors();

//app.MapTicketEndpoints();

app.Run();
