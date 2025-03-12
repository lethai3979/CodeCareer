using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Domain.Shared
{
    public sealed record Error
    {
        public string ErrorMessage { get; set; }
        public ErrorType ErrorType { get; }

        private Error(string errorMessage, ErrorType errorCode)
        {
            ErrorMessage = errorMessage;
            ErrorType = errorCode;
        }

        public static readonly Error None = new Error(string.Empty, ErrorType.None);

        public static Error NotFound(string message) => new Error(message, ErrorType.NotFound);
        public static Error InvalidData(string message) => new Error(message, ErrorType.BadRequest);
        public static Error BadRequest(string message) => new Error(message, ErrorType.BadRequest);
        public static Error OperationFailed(string message) => new Error(message, ErrorType.OperationFailed);
        public static Error Conflict(string message) => new Error(message, ErrorType.Conflict);
        public static Error Unauthorized(string message) => new Error(message, ErrorType.Unauthorized);
    }
}
