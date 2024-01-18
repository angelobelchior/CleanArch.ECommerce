using ECommerce.Application;
using ECommerce.Infrastructure;
using ECommerce.WebAPI.Endpoints;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseVitrineEndpoints();
//app.UseCarrinhoEndpoints();
//app.UseCheckoutEndpoints();


app.Run();
