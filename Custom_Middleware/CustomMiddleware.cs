using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.Threading.Tasks;

public class CustomMiddleware
{
    //private readonly RequestDelegate _next;

    //public CustomMiddleware(RequestDelegate next)
    //{
    //    _next = next;
    //}

    //public async Task InvokeAsync(HttpContext context)
    //{
    //    // Ensure we don't disrupt the response stream
    //    var originalResponseBody = context.Response.Body;   

    //    try
    //    {
    //        using (var responseBody = new MemoryStream())
    //        {
    //            context.Response.Body = responseBody;

    //          await  context.Response.WriteAsync("I am great\n\r");
    //            // Do something before the next middleware
    //            await context.Response.WriteAsync("Before custom middleware\n");

    //            // Call the next middleware in the pipeline
    //            await _next(context);

    //            // Do something after the next middleware
    //            await context.Response.WriteAsync("After custom middleware\n");

    //            // Copy the content of the modified response body to the original response body
    //            responseBody.Seek(0, SeekOrigin.Begin);
    //            await responseBody.CopyToAsync(originalResponseBody);
    //        }
    //    }
    //    finally
    //    {
    //        context.Response.Body = originalResponseBody;
    //    }
    //}

    private readonly RequestDelegate _next;
    private readonly IFileProvider _fileProvider;

    public CustomMiddleware(RequestDelegate next, IFileProvider fileProvider)
    {
        _next = next;
        _fileProvider = fileProvider;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Do something before the next middleware
        await context.Response.WriteAsync("Before custom middleware\n");

        // Check if the request path matches specific criteria
        if (IsReactRoute(context.Request.Path))
        {
            // Serve the index.html file
            await ServeIndexHtml(context);
        }
        else
        {
            // Call the next middleware in the pipeline
            await _next(context);
        }

        // Do something after the next middleware
        await context.Response.WriteAsync("After custom middleware\n");
    }

    private bool IsReactRoute(PathString path)
    {
        // Define criteria for React routes (e.g., all routes except API and static files)
        return !path.Value.StartsWith("/api") && !Path.HasExtension(path.Value);
    }

    private async Task ServeIndexHtml(HttpContext context)
    {
        var file = _fileProvider.GetFileInfo("index.html");

        if (file.Exists)
        {
            context.Response.ContentType = "text/html";
            await context.Response.SendFileAsync(file);
        }
        else
        {
            context.Response.StatusCode = 404;
        }
    }
}


