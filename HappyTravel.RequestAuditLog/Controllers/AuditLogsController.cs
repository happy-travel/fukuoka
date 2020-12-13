using System.Net;
using System.Threading;
using System.Threading.Tasks;
using HappyTravel.RequestAuditLog.Enums;
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


        /// <summary>
        /// Adds http request logs to audit logs repository
        /// </summary>
        /// <param name="request">Log data</param>
        /// <returns></returns>
        [HttpPost("requests")]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        public async Task<ActionResult> AddEntry(HttpRequestAuditLogEntry request, CancellationToken token)
        {
            await _auditLogService.AddLogEntry(AuditLogTypes.HttpRequest, request, token);
            return Ok();
        }


        private readonly IAuditLogService _auditLogService;
    }
}