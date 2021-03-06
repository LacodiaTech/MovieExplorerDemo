using System.Threading.Tasks;
using System.Reflection;
// <copyright file="MovieDetailsPageViewModelTest.cs">Copyright ©  2017</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieExplorer.ViewModels;

namespace MovieExplorer.ViewModels.Tests
{
    [TestClass]
    [PexClass(typeof(MovieDetailsPageViewModel))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class MovieDetailsPageViewModelTest
    {

        [PexMethod]
        [PexMethodUnderTest("DevideInHalf(Double)")]
        internal double DevideInHalf([PexAssumeUnderTest]MovieDetailsPageViewModel target, double baseTen)
        {
            object[] args = new object[1];
            args[0] = (object)baseTen;
            Type[] parameterTypes = new Type[1];
            parameterTypes[0] = typeof(double);
            double result0 = (double)(((MethodBase)(typeof(MovieDetailsPageViewModel).GetMethod("DevideInHalf",
                                                                                                BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic,
                                                                                                (Binder)null, CallingConventions.HasThis, parameterTypes, (ParameterModifier[])null)))
                                          .Invoke((object)target, args));
            double result = result0;
            return result;
            // TODO: add assertions to method MovieDetailsPageViewModelTest.DevideInHalf(MovieDetailsPageViewModel, Double)
        }

        [PexMethod]
        [PexMethodUnderTest("CheckIfMovieIsFavorite()")]
        internal Task CheckIfMovieIsFavorite([PexAssumeUnderTest]MovieDetailsPageViewModel target)
        {
            object[] args = new object[0];
            Type[] parameterTypes = new Type[0];
            Task result0 = ((MethodBase)(typeof(MovieDetailsPageViewModel).GetMethod("CheckIfMovieIsFavorite",
                                                                                     BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic, (Binder)null,
                                                                                     CallingConventions.HasThis, parameterTypes, (ParameterModifier[])null)))
                               .Invoke((object)target, args) as Task;
            Task result = result0;
            return result;
            // TODO: add assertions to method MovieDetailsPageViewModelTest.CheckIfMovieIsFavorite(MovieDetailsPageViewModel)
        }

        [PexMethod]
        [PexMethodUnderTest("UpdateFavoriteButton()")]
        internal Task UpdateFavoriteButton([PexAssumeUnderTest]MovieDetailsPageViewModel target)
        {
            object[] args = new object[0];
            Type[] parameterTypes = new Type[0];
            Task result0 = ((MethodBase)(typeof(MovieDetailsPageViewModel).GetMethod("UpdateFavoriteButton",
                                                                                     BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic, (Binder)null,
                                                                                     CallingConventions.HasThis, parameterTypes, (ParameterModifier[])null)))
                               .Invoke((object)target, args) as Task;
            Task result = result0;
            return result;
            // TODO: add assertions to method MovieDetailsPageViewModelTest.UpdateFavoriteButton(MovieDetailsPageViewModel)
        }

        [PexMethod]
        [PexMethodUnderTest("SaveFavorites()")]
        internal Task SaveFavorites([PexAssumeUnderTest]MovieDetailsPageViewModel target)
        {
            object[] args = new object[0];
            Type[] parameterTypes = new Type[0];
            Task result0 = ((MethodBase)(typeof(MovieDetailsPageViewModel).GetMethod("SaveFavorites",
                                                                                     BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic, (Binder)null,
                                                                                     CallingConventions.HasThis, parameterTypes, (ParameterModifier[])null)))
                               .Invoke((object)target, args) as Task;
            Task result = result0;
            return result;
            // TODO: add assertions to method MovieDetailsPageViewModelTest.SaveFavorites(MovieDetailsPageViewModel)
        }

        [PexMethod]
        [PexMethodUnderTest("DeleteMovieFromFavorites()")]
        internal Task DeleteMovieFromFavorites([PexAssumeUnderTest]MovieDetailsPageViewModel target)
        {
            object[] args = new object[0];
            Type[] parameterTypes = new Type[0];
            Task result0
               = ((MethodBase)(typeof(MovieDetailsPageViewModel).GetMethod("DeleteMovieFromFavorites",
                                                                           BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic, (Binder)null,
                                                                           CallingConventions.HasThis, parameterTypes, (ParameterModifier[])null)))
                     .Invoke((object)target, args) as Task;
            Task result = result0;
            return result;
            // TODO: add assertions to method MovieDetailsPageViewModelTest.DeleteMovieFromFavorites(MovieDetailsPageViewModel)
        }
    }
}
