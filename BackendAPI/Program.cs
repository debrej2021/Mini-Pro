//using BackendAPI;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//app.UseMiddleware<RequestLoggingMiddleware>();
////app.MapGet("/", () => "Hello World!");
////app.MapGet("/Microservices", () => "Hello from Microservice!");
//// Configure the HTTP request pipeline.


//app.MapGet("/", async (IHttpClientFactory httpClientFactory) =>
//{
//    var client = httpClientFactory.CreateClient();
//    var response = await client.GetStringAsync("http://localhost:5001/microservice");
//    return $"Hello World! {response}";
//});
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();


using BackendAPI;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add HTTP client
builder.Services.AddHttpClient();

var app = builder.Build();

app.UseMiddleware<RequestLoggingMiddleware>();

app.MapGet("/", async (IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient();
    var response = await client.GetStringAsync("http://localhost:5001/microservice");
    return $"Hello World! {response}";
});

app.Run();


