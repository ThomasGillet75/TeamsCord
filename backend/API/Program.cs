using Application.Interfaces;
using Application.UseCase;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<IEntityFrameworkService, EntityFrameworkService>();
builder.Services.AddScoped<GetProfileUseCase>();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseForwardedHeaders();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => { options.SwaggerEndpoint("/openapi/v1.json", "InstaBook"); });
}

app.UseCors("AllowAll");
app.MapControllers();
app.Run();