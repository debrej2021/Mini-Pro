using ReactDotNetExample;

var builder = WebApplication.CreateBuilder(args);

// Add services to the DI container.
builder.Services.AddControllers();  // Ensures controllers are registered
builder.Services.AddAuthorization(); // Adds the authorization services

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:3000") // React app's URL
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials(); // If your frontend needs to send credentials like cookies or auth headers
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization(); // Make sure this is called after UseRouting() and before UseEndpoints()
app.UseMiddleware<RequestLoggingMiddleware>();
app.MapControllers();

app.Run();