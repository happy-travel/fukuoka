using System;
using HappyTravel.VaultClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace HappyTravel.RequestAuditLog.Infrastructure
{
    public static class ElasticSearchExtension
    {
        public static void AddElasticSearch(this IServiceCollection  services, IConfiguration configuration, IVaultClient vaultClient)
        {
            var options = vaultClient.Get(configuration["elasticsearch:endpoint"]).GetAwaiter().GetResult();
            var settings = new ConnectionSettings(new Uri(options["url"]));
            var client = new ElasticClient(settings);
            services.AddSingleton<IElasticClient>(client);
        }
    }
}