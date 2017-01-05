using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Utilities
{
    public static class Diagnostic
    {
        public static void NotNull(object value, string paramName = null, string message = null)
        {
            Assert(
                value != null,
                paramName, message,
                new ArgumentNullException(paramName ?? string.Empty, message ?? string.Empty)
            );
        }

        public static void NotEmpty<T>(IEnumerable<T> value, string paramName = null, string message = null)
        {
            Assert(
                value.Any(),
                paramName, message,
                new ArgumentException(message ?? string.Empty, paramName ?? string.Empty)
            );
        }


        //Diagnostic.Assert(false, "message", "detailMessage");
        public static void Assert(bool condition, string message, string detailMessage)
            => Debug.Assert(condition, message ?? string.Empty, detailMessage ?? string.Empty);

        //Diagnostic.Assert(false, "message");
        //Diagnostic.Assert(false);
        public static void Assert(bool condition, string message = null)
            => Debug.Assert(condition, message ?? string.Empty, string.Empty);

        //Diagnostic.Assert(false, "message", "detailMessage", new XException("message", "detailMessage"));
        public static void Assert<TException>(bool condition, string message, string detailMessage, TException exception)
            where TException : Exception
        {
            Assert(condition, message, detailMessage);  // while DEBUG

            if (!condition)                             // reachable when ^Assert=>Debug.Assert does not break/throw
                throw exception;                            
        }

        //Diagnostic.Assert(false, "message", new XException("message"));
        public static void Assert<TException>(bool condition, string message, TException exception)
            where TException : Exception
            => Assert<TException>(condition, message, string.Empty, exception);

        //Diagnostic.Assert(false, new XException());
        public static void Assert<TException>(bool condition, TException exception)
            where TException : Exception
            => Assert<TException>(condition, string.Empty, string.Empty, exception);


        //Diagnostic.Assert<XException>(false);        
        public static void Assert<TException>(bool condition)
            where TException : Exception, new()
        {
            Debug.Assert(condition);
            throw new TException();
        }
    }
}
