using System;
using HappyTravel.RequestAuditLog.Enums;

namespace HappyTravel.RequestAuditLog.Models
{
    public record AuditLogEntry<T>
    {
        public AuditLogEntry(T logData, AuditLogTypes auditLogType, DateTime dateTime)
        {
            DateTime = dateTime;
            AuditLogType = auditLogType;
            Data = logData;
        }


        public T Data { get; }
        public AuditLogTypes AuditLogType { get; }
        public DateTime DateTime { get; }
    }
}