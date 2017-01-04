using System;
using System.Diagnostics;

namespace Utilities
{
    public static class Diagnostic
    {
        public static void Assert(bool condition, string message = null, string detailMessage = null)
            => Debug.Assert(condition, message ?? string.Empty, detailMessage ?? string.Empty);


        public static void Assert<TException>(bool condition, string message, string detailMessage, TException exception)
            where TException : Exception
        {
            Assert(condition, message, detailMessage);  // for DEBUG
            throw exception;                            // no DEBUG
        }

        public static void Assert<TException>(bool condition, string message, TException exception)
            where TException : Exception
            => Assert<TException>(condition, message, string.Empty, exception);

        public static void Assert<TException>(bool condition, TException exception)
            where TException : Exception
            => Assert<TException>(condition, string.Empty, string.Empty, exception);


        public static void Assert<TException>(bool condition)
            where TException : Exception, new()
        {
            Debug.Assert(condition);
            throw new TException();
        }
    }
}
