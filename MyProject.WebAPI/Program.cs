using Microsoft.EntityFrameworkCore;
using MyProject.Context;
using MyProject.Repositories.Interfaces;
using MyProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(opt => opt.AddPolicy("PolicyName", policy =>
{
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));
builder.Services.AddControllers();

builder.Services.AddDbContext<IContext, MyDbContext>(options => options.UseSqlServer("name=ConnectionStrings:MyProjectDB"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors("PolicyName");

app.UseAuthorization();

app.MapControllers();

app.Run();
