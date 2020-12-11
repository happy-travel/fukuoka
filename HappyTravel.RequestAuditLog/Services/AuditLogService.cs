using System;
using System.Threading;
using System.Threading.Tasks;
using HappyTravel.RequestAuditLog.Models;
using Nest;

namespace HappyTravel.RequestAuditLog.Services
{
    public class AuditLogService : IAuditLogService
    {
        public AuditLogService(IElasticClient client)
        {
            _client = client;
        }


        public Task AddLogEntry(AuditLogTypes type, LogEntryRequest request, CancellationToken token)
        {
            return type switch
            {
                AuditLogTypes.HttpRequest => AddHttpRequestLog(request, token),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }


        private Task AddHttpRequestLog(LogEntryRequest request, CancellationToken token)
        {
            var datetime = DateTime.UtcNow;
            var logEntry = new AuditLogEntry(request, datetime);
            return _client.IndexAsync(new IndexRequest<AuditLogEntry>(logEntry, BuildIndexName("http-requests", datetime)), token);
        }


        private static string BuildIndexName(string indexName, DateTime dateTime)
            => $"audit-log-{indexName}-{dateTime:MM.dd.yyyy}";


        private readonly IElasticClient _client;
    }
}