using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Core.Helpers
{
    public class ExceptionHandling : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Connection { get; set; }

        // Exception.
        public ExceptionHandling(string message, HttpStatusCode statusCode)
            : base(message)
        {
            StatusCode = statusCode;
            Connection = true;
        }

        // Inner Exception Message.
        public ExceptionHandling(string message, bool connection, Exception inner)
            : base(message, inner)
        {
            Connection = connection;
            StatusCode = HttpStatusCode.ServiceUnavailable;
        }
    }

    // Error Message.
    public class ExceptionHandlingError
    {
        public string Message { get; set; }
    }
}
