using System;
using System.Diagnostics;
using Xunit;

namespace Utilities.test
{
    public class DiagnosticTest
    {
        private class DiagnosticTestException : Exception {}


        /// <summary>
        /// #if DEBUG
        ///   Assert(false) #if DEBUG -> : if(Debugger.IsAttached) then Debugger.Break() else throw new DebugAssertException ()
        ///   Assert(true) -> nothing
        /// #else
        ///   Assert(false/true) -> nothing
        /// </summary>
        /// 
        private static void VerifyAssertFalse(Exception e)
        {
#if DEBUG
            if (Debugger.IsAttached)
                Assert.Null(e);
            else
                Assert.NotNull(e);
#else
            Assert.Null(e);
#endif              
        }

        private static void VerifyAssertExceptionFalse(Exception e, Exception t)
        {
            Debug.Assert(t != null, "Exception t", "CAN NOT BE NULL for Unit testing");

            Assert.NotNull(e);
#if DEBUG
            // DebugAssertException but unaccessible
#else
            Assert.True(e.GetType() == t.GetType());
#endif              
        }



        private static void VerifyAssertTrue(Exception e)
            => Assert.Null(e);


        [Fact]
        public void AssertFalseMessageMessage()
        {
            // Arrange

            // Act
            var e = Record.Exception(() => Diagnostic.Assert(false, "message", "detailMessage"));

            //Assert
            VerifyAssertFalse(e);
        }

        [Fact]
        public void AssertTrueMessageMessage()
        {
            // Arrange

            // Act
            var e = Record.Exception(() => Diagnostic.Assert(true, "message", "detailMessage"));

            //Assert
            VerifyAssertTrue(e);
        }

        [Fact]
        public void AssertFalseMessage()
        {
            // Arrange

            // Act
            var e = Record.Exception(() => Diagnostic.Assert(false, "message"));

            //Assert
            VerifyAssertFalse(e);
        }

        [Fact]
        public void AssertTrueMessage()
        {
            // Arrange

            // Act
            var e = Record.Exception(() => Diagnostic.Assert(true, "message"));

            //Assert
            VerifyAssertTrue(e);
        }

        [Fact]
        public void AssertFalse()
        {
            // Arrange

            // Act
            var e = Record.Exception(() => Diagnostic.Assert(false));

            //Assert
            VerifyAssertFalse(e);
        }

        [Fact]
        public void AssertTrue()
        {
            // Arrange

            // Act
            var e = Record.Exception(() => Diagnostic.Assert(true));

            //Assert
            VerifyAssertTrue(e);
        }


        [Fact]
        public void AssertFalseMessageMessageException()
        {
            // Arrange
            var t = new DiagnosticTestException();

            // Act
            var e = Record.Exception(() => Diagnostic.Assert(false, "message", "detailMessage", t));

            //Assert
            VerifyAssertExceptionFalse(e, t);
        }

        [Fact]
        public void AssertTrueMessageMessageException()
        {
            // Arrange
            var t = new DiagnosticTestException();

            // Act
            var e = Record.Exception(() => Diagnostic.Assert(true, "message", "detailMessage", t));

            //Assert
            VerifyAssertTrue(e);
        }

        [Fact]
        public void AssertFalseMessageException()
        {
            // Arrange
            var t = new DiagnosticTestException();

            // Act
            var e = Record.Exception(() => Diagnostic.Assert(false, "message", t));

            //Assert
            VerifyAssertExceptionFalse(e, t);
        }

        [Fact]
        public void AssertTrueMessageException()
        {
            // Arrange
            var t = new DiagnosticTestException();

            // Act
            var e = Record.Exception(() => Diagnostic.Assert(true, "message", t));

            //Assert
            VerifyAssertTrue(e);
        }

        [Fact]
        public void AssertFalseException()
        {
            // Arrange
            var t = new DiagnosticTestException();

            // Act
            var e = Record.Exception(() => Diagnostic.Assert(false, t));

            //Assert
            VerifyAssertExceptionFalse(e, t);
        }

        [Fact]
        public void AssertTrueException()
        {
            // Arrange
            var t = new DiagnosticTestException();

            // Act
            var e = Record.Exception(() => Diagnostic.Assert(true, t));

            //Assert
            VerifyAssertTrue(e);
        }

        [Fact]
        public void AssertExceptionFalse()
        {
            // Arrange
            var t = new DiagnosticTestException();

            // Act
            var e = Record.Exception(() => Diagnostic.Assert<DiagnosticTestException>(false));

            //Assert
            VerifyAssertExceptionFalse(e, t);
        }

        [Fact]
        public void AssertExceptionTrue()
        {
            // Arrange

            // Act
            var e = Record.Exception(() => Diagnostic.Assert<DiagnosticTestException>(true));

            //Assert
            VerifyAssertTrue(e);
        }

        // TODO
        ////public static void NotNull(object value, string paramName = null, string message = null)
        
    }
}
