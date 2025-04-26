using dotnet_backend.Extensions;

// Builder 

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

const string policyName = "AllowAll";

builder.Services.DependencyInjection();

builder.Services.AddControllers();

builder.Services.AddDbContextConfiguration(connectionString);

builder.Services.AddOpenApi();

builder.Services.AddCorsPolicy(policyName);

// App

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

await app.MigrateAndSeedAsync();

app.UseHttpsRedirection();

app.UseCors(policyName);

app.MapControllers();

app.Run();