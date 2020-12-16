using System;
using System.Threading;
using System.Threading.Tasks;
using HappyTravel.RequestAuditLog.Enums;
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


        public Task AddLogEntry<T>(AuditLogTypes type, T logData, CancellationToken token)
        {
            var datetime = DateTime.UtcNow;
            var logEntry = new AuditLogEntry<T>(logData, type, datetime);
            return _client.IndexAsync(new IndexRequest<AuditLogEntry<T>>(
                logEntry, BuildIndexName(datetime)), token);
        }


        private static string BuildIndexName(DateTime dateTime)
            => $"audit-log-{dateTime:MM.dd.yyyy}";


        private readonly IElasticClient _client;
    }
}