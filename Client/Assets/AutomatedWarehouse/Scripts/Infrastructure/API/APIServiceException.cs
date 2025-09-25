using System;

namespace AutomatedWarehouse.Infrastructure.API
{
    public class APIServiceException : Exception
    {
        public long ResponseCode { get; }

        public APIServiceException(string message, long errorCode) : base(message)
        {
            ResponseCode = errorCode;
        }

        public APIServiceException(string message, Exception innerException) : base(message, innerException)
        {
            ResponseCode = -1;
        }
    }
}