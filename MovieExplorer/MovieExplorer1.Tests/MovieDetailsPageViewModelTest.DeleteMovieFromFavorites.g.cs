using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieExplorer.Core.Interfaces;
using Prism.Navigation;
using System.Threading.Tasks;
using MovieExplorer.ViewModels;
using Microsoft.Pex.Framework.Generated;
// <copyright file="MovieDetailsPageViewModelTest.DeleteMovieFromFavorites.g.cs">Copyright ©  2017</copyright>
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace MovieExplorer.ViewModels.Tests
{
    public partial class MovieDetailsPageViewModelTest
    {

[TestMethod]
[PexGeneratedBy(typeof(MovieDetailsPageViewModelTest))]
public void DeleteMovieFromFavorites845()
{
    using (PexDisposableContext disposables = PexDisposableContext.Create())
    {
      MovieDetailsPageViewModel movieDetailsPageViewModel;
      Task task;
      movieDetailsPageViewModel =
        new MovieDetailsPageViewModel((INavigationService)null, 
                                      (IMovieExplorerAPIService)null, (IDataManager)null);
      task = this.DeleteMovieFromFavorites(movieDetailsPageViewModel);
      disposables.Add((IDisposable)task);
      disposables.Dispose();
      Assert.IsNotNull((object)task);
      Assert.AreEqual<TaskStatus>(TaskStatus.Faulted, task.Status);
      Assert.AreEqual<bool>(false, task.IsCanceled);
      Assert.IsNull(task.AsyncState);
      Assert.AreEqual<bool>(true, task.IsFaulted);
      Assert.IsNotNull((object)movieDetailsPageViewModel);
      Assert.IsNotNull(movieDetailsPageViewModel.Movie);
      Assert.AreEqual<int>(0, movieDetailsPageViewModel.Movie.vote_count);
      Assert.AreEqual<int>(0, movieDetailsPageViewModel.Movie.id);
      Assert.AreEqual<bool>(false, movieDetailsPageViewModel.Movie.video);
      Assert.AreEqual<double>(0, movieDetailsPageViewModel.Movie.vote_average);
      Assert.AreEqual<string>((string)null, movieDetailsPageViewModel.Movie.title);
      Assert.AreEqual<double>(0, movieDetailsPageViewModel.Movie.popularity);
      Assert.AreEqual<string>
          ((string)null, movieDetailsPageViewModel.Movie.poster_path);
      Assert.AreEqual<string>
          ((string)null, movieDetailsPageViewModel.Movie.original_language);
      Assert.AreEqual<string>
          ((string)null, movieDetailsPageViewModel.Movie.original_title);
      Assert.IsNull(movieDetailsPageViewModel.Movie.genre_ids);
      Assert.AreEqual<string>
          ((string)null, movieDetailsPageViewModel.Movie.backdrop_path);
      Assert.AreEqual<bool>(false, movieDetailsPageViewModel.Movie.adult);
      Assert.AreEqual<string>
          ((string)null, movieDetailsPageViewModel.Movie.overview);
      Assert.AreEqual<int>(1, movieDetailsPageViewModel.Movie.release_date.Day);
      Assert.AreEqual<DayOfWeek>
          (DayOfWeek.Monday, movieDetailsPageViewModel.Movie.release_date.DayOfWeek);
      Assert.AreEqual<int>
          (1, movieDetailsPageViewModel.Movie.release_date.DayOfYear);
      Assert.AreEqual<int>(0, movieDetailsPageViewModel.Movie.release_date.Hour);
      Assert.AreEqual<DateTimeKind>(DateTimeKind.Unspecified, 
                                    movieDetailsPageViewModel.Movie.release_date.Kind);
      Assert.AreEqual<int>
          (0, movieDetailsPageViewModel.Movie.release_date.Millisecond);
      Assert.AreEqual<int>(0, movieDetailsPageViewModel.Movie.release_date.Minute);
      Assert.AreEqual<int>(1, movieDetailsPageViewModel.Movie.release_date.Month);
      Assert.AreEqual<int>(0, movieDetailsPageViewModel.Movie.release_date.Second);
      Assert.AreEqual<int>(1, movieDetailsPageViewModel.Movie.release_date.Year);
      Assert.AreEqual<bool>(false, movieDetailsPageViewModel.Movie.is_favorite);
      Assert.AreEqual<string>((string)null, movieDetailsPageViewModel.Image);
      Assert.AreEqual<string>((string)null, movieDetailsPageViewModel.Title);
      Assert.AreEqual<string>((string)null, movieDetailsPageViewModel.ReleaseDate);
      Assert.AreEqual<string>((string)null, movieDetailsPageViewModel.VoteCount);
      Assert.AreEqual<double>(0, movieDetailsPageViewModel.AverageRating);
      Assert.AreEqual<string>((string)null, movieDetailsPageViewModel.Overview);
      Assert.AreEqual<string>
          ("Save To Favorites", movieDetailsPageViewModel.Favorite);
      Assert.AreEqual<bool>(true, movieDetailsPageViewModel.IsFavoriteButtonEnabled);
      Assert.IsNull(movieDetailsPageViewModel.SimilarListItems);
      Assert.IsNotNull(movieDetailsPageViewModel.SimilarList);
      Assert.IsNull(movieDetailsPageViewModel.SelectedMovie);
      Assert.IsNotNull(movieDetailsPageViewModel.SaveToFavoritesCommand);
      Assert.AreEqual<bool>
          (false, movieDetailsPageViewModel.SaveToFavoritesCommand.IsActive);
      Assert.IsNotNull(movieDetailsPageViewModel.CloseCommand);
      Assert.AreEqual<bool>(false, movieDetailsPageViewModel.CloseCommand.IsActive);
    }
}
    }
}
