using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions
{
    [Serializable]
    public class DBTransactionException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public DBTransactionException(string message, System.Net.HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public DBTransactionException(string message) : base(message)
        {
        }

        public DBTransactionException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DBTransactionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public static DBTransactionException FromJson(dynamic json)
        {
            string text = ""; // parse from json here

            return new DBTransactionException(text);
        }
    }
}
