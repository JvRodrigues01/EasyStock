using EasyStock.Api.Configuration;
using EasyStock.Api.Middlewares;
using EasyStock.Application;
using EasyStock.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

builder.Services
    .AddMediator()
    .AddApplication()
    .AddInfra(configuration)
    .AddPresentation()
    .AddAuthorizationAndAuthentication(configuration)
    .AddMiddlewares()
    .ConfigureCors();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAnyOrigin");

app.UseAuthentication();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.Run();
