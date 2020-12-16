using System.Threading;
using System.Threading.Tasks;
using HappyTravel.RequestAuditLog.Enums;

namespace HappyTravel.RequestAuditLog.Services
{
    public interface IAuditLogService
    {
        Task AddLogEntry<T>(AuditLogTypes type, T logData, CancellationToken token);
    }
}