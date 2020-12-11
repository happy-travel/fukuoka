using System;

namespace HappyTravel.RequestAuditLog.Models
{
    public record LogEntryRequest
    {
        public string? Url { get; init; }
        public string? RequestHeaders { get; init; }
        public string? ResponseHeaders { get; init; }
        public string? RequestBody { get; init; }
        public string? ResponseBody { get; init; }
        public int? StatusCode { get; init; }
        public string? ReferenceCode { get; init; }
    }
}