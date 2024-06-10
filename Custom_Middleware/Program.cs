using Custom_Middleware;
using Microsoft.Extensions.FileProviders;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();
//builder.Services.AddLogging();


////builder.WebHost.ConfigureKestrel(options =>
////{
////    options.ListenLocalhost(5101, listenOptions =>
////    {
////        listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1AndHttp2;
////        listenOptions.UseHttps(); // Ensure HTTPS is configured
////    });
////});
//var app = builder.Build();
//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//// Use the custom middleware
//app.UseMiddleware<CustomMiddleware>();

//app.MapControllerRoute(
//     //name: "default",
//     //pattern: "{controller=Home}/{action=Index}/{id?}",
//     endpoints.MapControllerRoute(
//            name: "default",
//            pattern: "{controller=Home}/{action=Index}/{id?}");
//endpoints.MapFallbackToFile("index.html"););

//app.Run();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddLogging();
builder.Services.AddSingleton<IFileProvider>(
    new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "wwwroot")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Enable serving static files from wwwroot

app.UseRouting();

app.UseAuthorization();

// Use the custom middleware
app.UseMiddleware<CustomMiddleware>();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    // Fallback route for SPA
    endpoints.MapFallbackToFile("index.html");
});

app.Run();
