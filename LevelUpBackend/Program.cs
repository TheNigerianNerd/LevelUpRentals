using Azure.Identity;
using LevelUpBackend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- PHASE 1: REGISTRATION (The "Architect" Phase) ---

// 1. Connect to Azure Key Vault FIRST so the configuration is available
var vaultUri = new Uri("https://levelup-kv-oce-dev.vault.azure.net/");
builder.Configuration.AddAzureKeyVault(vaultUri, new DefaultAzureCredential());

// 2. Retrieve the connection string from the now-populated configuration
var connectionString = builder.Configuration["DB-CONNECTION-STRING"];

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Could not find 'DB-CONNECTION-STRING' in Azure Key Vault.");
}

// 3. Register the Database Context
builder.Services.AddDbContext<LevelUpRentalsDbContext>(options =>
    options.UseNpgsql(connectionString));

// 4. Register Controllers (needed for your API endpoints to work)
builder.Services.AddControllers();

// --- PHASE 2: BUILD (The "Point of No Return") ---

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi(); // This generates the UI we love

var app = builder.Build();

// --- PHASE 3: CONFIGURATION & RUN (The "Inhabitant" Phase) ---
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Use the 'app' to create a scope and seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<LevelUpRentalsDbContext>();
    DbInitializer.Initialize(context);
}

// Map your controller routes
app.MapControllers();

app.Run();