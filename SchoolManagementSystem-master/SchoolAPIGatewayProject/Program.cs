using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Configure services (equivalent of ConfigureServices in Startup.cs)
builder.Services.AddControllers();
builder.Services.AddOcelot(builder.Configuration);

// Load the Ocelot configuration from the JSON file
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
                     .AddJsonFile("Ocelot.json", optional: false, reloadOnChange: true);

var app = builder.Build();

// Configure middleware (equivalent of Configure in Startup.cs)
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

// Configure Ocelot middleware
await app.UseOcelot();

app.Run();
