using System;
using System.Security.Cryptography.X509Certificates;
using HappyTravel.VaultClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace HappyTravel.RequestAuditLog.Infrastructure
{
    public static class ElasticSearchExtensions
    {
        public static void AddElasticSearch(this IServiceCollection  services, IConfiguration configuration, IVaultClient vaultClient)
        {
            var options = vaultClient.Get(configuration["elasticsearch:endpoint"]).GetAwaiter().GetResult();
            var settings = new ConnectionSettings(new Uri(options["endpoint"]))
                .BasicAuthentication(options["username"], options["password"])
                .ServerCertificateValidationCallback((o, certificate, chain, errors) => true)
                .ClientCertificate(new X509Certificate2(Convert.FromBase64String(options["certificate"])));
            var client = new ElasticClient(settings);
            services.AddSingleton<IElasticClient>(client);
        }
    }
}