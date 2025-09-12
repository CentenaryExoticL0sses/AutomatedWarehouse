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
    }
}