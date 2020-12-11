using System.Threading;
using System.Threading.Tasks;
using HappyTravel.RequestAuditLog.Models;

namespace HappyTravel.RequestAuditLog.Services
{
    public interface IAuditLogService
    {
        Task AddLogEntry(AuditLogTypes type, LogEntryRequest logEntry, CancellationToken token);
    }
}