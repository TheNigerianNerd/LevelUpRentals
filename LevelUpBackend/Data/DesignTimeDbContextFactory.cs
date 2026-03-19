using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace LevelUpBackend.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LevelUpRentalsDbContext>
    {
        public LevelUpRentalsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LevelUpRentalsDbContext>();

            // 1. Fetch the secret manually for the CLI
            // Since this is local dev, DefaultAzureCredential will use your 'az login'
            var vaultUri = new Uri("https://levelup-kv-oce-dev.vault.azure.net/");
            var client = new SecretClient(vaultUri, new DefaultAzureCredential());
            var secret = client.GetSecret("DB-CONNECTION-STRING");

            optionsBuilder.UseNpgsql(secret.Value.Value);

            return new LevelUpRentalsDbContext(optionsBuilder.Options);
        }
    }
}