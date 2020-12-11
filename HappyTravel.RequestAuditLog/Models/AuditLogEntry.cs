using System;

namespace HappyTravel.RequestAuditLog.Models
{
    public record AuditLogEntry
    {
        public AuditLogEntry(LogEntryRequest request, DateTime dateTime)
        {
            Url = request.Url;
            RequestHeaders = request.RequestHeaders;
            ResponseHeaders = request.ResponseHeaders;
            RequestBody = request.RequestBody;
            ResponseBody = request.ResponseBody;
            StatusCode = request.StatusCode;
            ReferenceCode = request.ReferenceCode;
            DateTime = dateTime;
        }


        public string? Url { get; }
        public string? RequestHeaders { get; }
        public string? ResponseHeaders { get; }
        public string? RequestBody { get; }
        public string? ResponseBody { get; }
        public int? StatusCode { get; }
        public string? ReferenceCode { get; }
        public DateTime DateTime { get; }
    }
}