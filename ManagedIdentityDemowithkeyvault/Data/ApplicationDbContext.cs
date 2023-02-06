using Azure.Identity;
using ManagedIdentityDemowithkeyvault.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.AlwaysEncrypted.AzureKeyVaultProvider;
using Microsoft.EntityFrameworkCore;

namespace ManagedIdentityDemowithkeyvault.Data
{
    
    public class ApplicationDbContext : DbContext
    {
        private static Boolean isInitialized;
        public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            if (!isInitialized)
            {
                isInitialized = true;
                var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions());

                var azureKeyVaultProvider = new SqlColumnEncryptionAzureKeyVaultProvider(credential);
                var providers = new Dictionary<string, SqlColumnEncryptionKeyStoreProvider>();
                providers.Add(SqlColumnEncryptionAzureKeyVaultProvider.ProviderName, azureKeyVaultProvider);

                SqlConnection.RegisterColumnEncryptionKeyStoreProviders(providers);
            }

        }

        public DbSet<profile> profile { get; set; }
    }
}
