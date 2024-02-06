using Microsoft.EntityFrameworkCore;
using TP2P1.Models.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<SeriesDBContext>(options =>
  options.UseNpgsql(builder.Configuration.GetConnectionString("SeriesDbContextRemote")));

var app = builder.Build();



app.UseCors(policy =>
    policy.WithOrigins("https://localhost:7232;http://localhost:5067").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
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

app.Run();
