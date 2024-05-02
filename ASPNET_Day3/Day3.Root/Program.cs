using Day3.Root.Middlewares;
using Day3.Root.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "V1",
        Title = "EcoFarm API",
        Description = "APIs cho EcoFarm project"
    });
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.MapGet("/GetTest", () => "Hello World!");
app.MapGet("/GetTestWithParams", ([AsParameters]GetQueryString query, HttpContext context) =>
{
    return context?.Request.QueryString;
});
app.MapPost("/PostLogin", ([FromBody] LoginRequest request) => "Please check the logging");

app.UseLoggingMiddleware();
app.Run();
