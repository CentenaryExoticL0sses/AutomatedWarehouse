using System;

namespace AutomatedWarehouse.Infrastructure.API
{
    public class APIServiceException : Exception
    {
        public long ErrorCode { get; }

        public APIServiceException(string message, long errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }

        public APIServiceException(string message, Exception innerException) : base(message, innerException)
        {
            ErrorCode = -1;
        }
    }
}