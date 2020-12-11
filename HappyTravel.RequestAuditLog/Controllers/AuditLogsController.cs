using System.Threading;
using System.Threading.Tasks;
using HappyTravel.RequestAuditLog.Models;
using HappyTravel.RequestAuditLog.Services;
using Microsoft.AspNetCore.Mvc;

namespace HappyTravel.RequestAuditLog.Controllers
{
    [ApiController, Route("audit-logs")]
    public class AuditLogsController : ControllerBase
    {
        public AuditLogsController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }


        [HttpPost("requests")]
        public async Task<ActionResult> AddEntry(LogEntryRequest request, CancellationToken token)
        {
            await _auditLogService.AddLogEntry(AuditLogTypes.HttpRequest, request, token);
            return Ok();
        }


        private readonly IAuditLogService _auditLogService;
    }
}