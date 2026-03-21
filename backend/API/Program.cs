using API.Configuration;
using Application.Interfaces;
using Application.UseCase;
using DotNetEnv;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
Env.Load("./.env");
EnvironmentSettings environmentSettings = new EnvironmentSettings();

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<IEntityFrameworkService, EntityFrameworkService>();
builder.Services.AddScoped<ITokenService, TokenService>(_ => new TokenService(environmentSettings.Jwt.Secret,environmentSettings.Jwt.Issuer,environmentSettings.Jwt.Audience ));
builder.Services.AddScoped<AuthUseCase>();
builder.Services.AddScoped<SignUpUseCase>();
builder.Services.AddScoped<SignInUseCase>();
builder.Services.AddScoped<GetProfileUseCase>();

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

WebApplication app = builder.Build();

app.UseForwardedHeaders();
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => { options.SwaggerEndpoint("/openapi/v1.json", "TeamsCord"); });
}

app.MapControllers();
app.Run();

