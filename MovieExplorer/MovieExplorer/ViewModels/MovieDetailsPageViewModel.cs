using MovieExplorer.Core.Interfaces;
using MovieExplorer.Core.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MovieExplorer.ViewModels
{
    public class MovieDetailsPageViewModel : BindableBase, INavigationAware
    {
        #region Private Properties
        /// <summary>
        /// Interface for Prism's Navigation Service.
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Interface for Movie Explorer API Service.
        /// </summary>
        private readonly IMovieExplorerAPIService _iMovieExplorerAPIService;

        /// <summary>
        /// Id of the selectd movie for calling Similar Movies.
        /// </summary>
        private int movieId;
        #endregion

        #region Public Properties

        private ImageSource image;
        public ImageSource Image
        {
            get { return image; }
            set { SetProperty(ref image, value); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string releaseDate;
        public string ReleaseDate
        {
            get { return releaseDate; }
            set { SetProperty(ref releaseDate, value); }
        }
        private string voteCount;
        public string VoteCount
        {
            get { return voteCount; }
            set { SetProperty(ref voteCount, value); }
        }

        private string overview;
        public string Overview
        {
            get { return overview; }
            set { SetProperty(ref overview, value); }
        }

        /// <summary>
        /// Model of Similar movies.
        /// </summary>
        private SimilarListModel similarListItems;
        public SimilarListModel SimilarListItems
        {
            get { return similarListItems; }
            set { SetProperty(ref similarListItems, value); }
        }

        /// <summary>
        /// List of Similar Movies.
        /// </summary>
        private ObservableCollection<MovieDetails> similarList = new ObservableCollection<MovieDetails>();
        public ObservableCollection<MovieDetails> SimilarList
        {
            get { return similarList; }
            set { SetProperty(ref similarList, value); }
        }

        /// <summary>
        /// Selected Movie.
        /// </summary>
        private object selectedMovie;
        public object SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                SetProperty(ref selectedMovie, value);
                if (selectedMovie != null)
                {
                    ShowDetails(selectedMovie);
                    selectedMovie = null;
                }
            }
        }
        #endregion

        public MovieDetailsPageViewModel(INavigationService navigationService, IMovieExplorerAPIService iMovieExplorerAPIService)
        {
            _navigationService = navigationService;
            _iMovieExplorerAPIService = iMovieExplorerAPIService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }

        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            var selectedMovie = (MovieDetails)parameters["selectedMovie"];
            Image = selectedMovie.poster_fullPath;
            Title = selectedMovie.title;
            ReleaseDate = selectedMovie.release_date;
            VoteCount = $"(from {selectedMovie.vote_count} votes)";
            Overview = selectedMovie.overview;
            movieId = selectedMovie.id;

            await GetSimilarMovieListAsync();
        }

        #region Methods

        /// <summary>
        /// Get the list of the Similar Movies.
        /// </summary>
        /// <returns></returns>
        private async Task<SimilarListModel> GetSimilarMovieListAsync()
        {
            var similarMovieList = await _iMovieExplorerAPIService.GetSimilarMoviesAsync(movieId);

            if (similarMovieList.results != null)
            {
                SimilarList = new ObservableCollection<MovieDetails>(similarMovieList.results);
            }
            return similarMovieList;
        }

        private void ShowDetails(object selectedMovie)
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("selectedMovie", selectedMovie);
            //_navigationService.NavigateAsync("MovieDetailsPage", navigationParams);
        }
        #endregion
    }
}
