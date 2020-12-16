using System.Collections.Generic;

namespace HappyTravel.RequestAuditLog.Models
{
    public record HttpRequestAuditLogEntry
    {
        /// <summary>
        ///     Http request url
        /// </summary>
        public string Url { get; init; }

        /// <summary>
        ///     Http request headers
        /// </summary>
        public Dictionary<string, string>? RequestHeaders { get; init; }

        /// <summary>
        ///     Http request response headers
        /// </summary>
        public Dictionary<string, string>? ResponseHeaders { get; init; }

        /// <summary>
        ///     Http request body
        /// </summary>
        public string? RequestBody { get; init; }

        /// <summary>
        ///     Http request response body
        /// </summary>
        public string? ResponseBody { get; init; }

        /// <summary>
        ///     Http request response status code
        /// </summary>
        public int StatusCode { get; init; }

        /// <summary>
        ///     Booking reference code
        /// </summary>
        public string? ReferenceCode { get; init; }
    }
}