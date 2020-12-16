using System;
using HappyTravel.VaultClient;
using Microsoft.Extensions.Configuration;

namespace HappyTravel.RequestAuditLog.Infrastructure
{
    public static class VaultClientFactory
    {
        public static IVaultClient CreateVaultClient(IConfiguration configuration)
        {
            var vaultOptions = new VaultOptions
            {
                BaseUrl = new Uri(configuration[configuration["Vault:Endpoint"]]),
                Engine = configuration["Vault:Engine"],
                Role = configuration["Vault:Role"]
            };

            return new VaultClient.VaultClient(vaultOptions);
        }
    }
}