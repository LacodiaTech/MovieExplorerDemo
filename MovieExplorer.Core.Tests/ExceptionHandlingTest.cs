// <copyright file="ExceptionHandlingTest.cs">Copyright ©  2014</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieExplorer.Core.Helpers;

namespace MovieExplorer.Core.Helpers.Tests
{
    [TestClass]
    [PexClass(typeof(ExceptionHandling))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ExceptionHandlingTest
    {

        [PexMethod]
        public ExceptionHandling Constructor01(
            string message,
            bool connection,
            Exception inner
        )
        {
            ExceptionHandling target = new ExceptionHandling(message, connection, inner);
            return target;
            // TODO: add assertions to method ExceptionHandlingTest.Constructor01(String, Boolean, Exception)
        }
    }
}
