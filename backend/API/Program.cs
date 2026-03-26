using DotNetEnv;
using API.Extension;

Env.Load("./.env");

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddServices(builder.Configuration);
builder.Services.AddUseCase();

WebApplication app = builder.Build();
app.Initialize();
app.Run();

