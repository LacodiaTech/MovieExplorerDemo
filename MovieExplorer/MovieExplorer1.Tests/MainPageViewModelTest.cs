using System.Reflection;
// <copyright file="MainPageViewModelTest.cs">Copyright ©  2017</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieExplorer.ViewModels;

namespace MovieExplorer.ViewModels.Tests
{
    [TestClass]
    [PexClass(typeof(MainPageViewModel))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class MainPageViewModelTest
    {

        [PexMethod]
        [PexMethodUnderTest("ShowDetails(Object)")]
        internal void ShowDetails([PexAssumeUnderTest]MainPageViewModel target, object selectedMovie)
        {
            object[] args = new object[1];
            args[0] = selectedMovie;
            Type[] parameterTypes = new Type[1];
            parameterTypes[0] = typeof(object);
            object result = ((MethodBase)(typeof(MainPageViewModel).GetMethod("ShowDetails",
                                                                              BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic, (Binder)null,
                                                                              CallingConventions.HasThis, parameterTypes, (ParameterModifier[])null)))
                                .Invoke((object)target, args);
            // TODO: add assertions to method MainPageViewModelTest.ShowDetails(MainPageViewModel, Object)
        }
    }
}
