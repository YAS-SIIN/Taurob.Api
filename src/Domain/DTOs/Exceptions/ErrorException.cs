using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Taurob.Api.Domain.DTOs.Exceptions;

public class ErrorException : Exception
{
    [DataMember(Name = "error_code")]
    public int ErrorCode { get; set; }
    
    [DataMember(Name = "status_code")]
    public int StatusCode { get; set; }

    [DataMember(Name = "error_description")]
    public string ErrorDescription { get; set; }

    [DataMember(Name = "trace_id")]
    public string TraceId { get; set; }

    [DataMember(Name = "error_detail")]
    public string ErrorDetail { get; set; }

    public ErrorException(int statusCode, int errorCode, string errorDescription, string traceId = "", string errorDetail="")
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
        ErrorDescription = errorDescription;
        ErrorDetail = errorDetail;
        TraceId = traceId;
    }
}
