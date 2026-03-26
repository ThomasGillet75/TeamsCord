namespace API.Extension;

public static class WebApplicationExtension
{
    public static WebApplication Initialize(this WebApplication app)
    {
        app.UseForwardedHeaders();
        app.UseCors("AllowAll");
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUI(options => { options.SwaggerEndpoint("/openapi/v1.json", "TeamsCord"); });
        }
        app.MapControllers();
        return app;
    }
}