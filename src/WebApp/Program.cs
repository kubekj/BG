using Application;
using Core;
using Infrastructure;
using Infrastructure.Logging;
using WebApp.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCore();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();

builder.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseInfrastructure();

app.UseUserApi();
app.UseExerciseApi();

app.Run();