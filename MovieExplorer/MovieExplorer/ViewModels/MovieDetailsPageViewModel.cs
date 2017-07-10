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
        /// Interface for saveing and retrieving data.
        /// </summary>
        private readonly IDataManager _iDataManager;

        /// <summary>
        /// Id of the selectd movie for calling Similar Movies.
        /// </summary>
        private int movieId;

        /// <summary>
        /// Check if movie is a favorite.
        /// </summary>
        private bool isFavorite = false;
        #endregion

        #region Public Properties

        /// <summary>
        /// Selected movie details
        /// </summary>
        private MovieDetailsModel movie = new MovieDetailsModel();
        public MovieDetailsModel Movie
        {
            get { return movie; }
            set { SetProperty(ref movie, value); }
        }

        /// <summary>
        /// Larger size movie image.
        /// </summary>
        private string image;
        public string Image
        {
            get { return image; }
            set { SetProperty(ref image, value); }
        }

        /// <summary>
        /// Movie Title.
        /// </summary>
        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        /// <summary>
        /// Movie Release Date.
        /// </summary>
        private string releaseDate;
        public string ReleaseDate
        {
            get { return releaseDate; }
            set { SetProperty(ref releaseDate, value); }
        }

        /// <summary>
        /// Number of votes.
        /// </summary>
        private string voteCount;
        public string VoteCount
        {
            get { return voteCount; }
            set { SetProperty(ref voteCount, value); }
        }

        /// <summary>
        /// Average rating for movie.
        /// </summary>
        private double averageRating;
        public double AverageRating
        {
            get { return averageRating; }
            set { SetProperty(ref averageRating, value); }
        }

        /// <summary>
        /// Description of Movie.
        /// </summary>
        private string overview;
        public string Overview
        {
            get { return overview; }
            set { SetProperty(ref overview, value); }
        }

        /// <summary>
        /// Text for Favorites buttons.
        /// </summary>
        private string favorite = "Save To Favorites";
        public string Favorite
        {
            get { return favorite; }
            set { SetProperty(ref favorite, value); }
        }

        /// <summary>
        /// Check if button is disabled while saving or deleting.
        /// </summary>
        private bool isFavoriteButtonEnabled = true;
        public bool IsFavoriteButtonEnabled
        {
            get { return isFavoriteButtonEnabled; }
            set { SetProperty(ref isFavoriteButtonEnabled, value); }
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
        private ObservableCollection<MovieDetailsModel> similarList = new ObservableCollection<MovieDetailsModel>();
        public ObservableCollection<MovieDetailsModel> SimilarList
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
                    LoadSimilarMovie(selectedMovie);
                    selectedMovie = null;
                }
            }
        }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="navigationService"></param>
        /// <param name="iMovieExplorerAPIService"></param>
        /// <param name="iDataManager"></param>
        public MovieDetailsPageViewModel(INavigationService navigationService, IMovieExplorerAPIService iMovieExplorerAPIService, IDataManager iDataManager)
        {
            _navigationService = navigationService;
            _iMovieExplorerAPIService = iMovieExplorerAPIService;
            _iDataManager = iDataManager;

            CloseCommand = new DelegateCommand(Close);
            SaveToFavoritesCommand = new DelegateCommand(SaveToFavorites);
        }

        #region Navigation
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            Movie = (MovieDetailsModel)parameters["selectedMovie"];

            Image = movie.poster_fullPathw154;
            Title = movie.title;
            ReleaseDate = movie.release_date;
            VoteCount = $"(from {movie.vote_count} votes)";
            Overview = movie.overview;
            movieId = movie.id;

            double arBaseTen = movie.vote_average;
            AverageRating = arBaseTen / 2;

            await GetSimilarMovieListAsync();
            await CheckIfMovieIsFavorite();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }
        #endregion

        #region Commands

        /// <summary>
        /// Command for favoriting movie.
        /// </summary>
        public DelegateCommand SaveToFavoritesCommand { get; set; }
        private async void SaveToFavorites()
        {
            await UpdateFavoriteButton();
        }

        /// <summary>
        /// Navigates back to the Main Movie Page.
        /// </summary>
        public DelegateCommand CloseCommand { get; set; }
        private void Close()
        {
            _navigationService.NavigateAsync("NavigationPage/MainPage", null, true, true);
        }
        #endregion

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
                SimilarList = new ObservableCollection<MovieDetailsModel>(similarMovieList.results);
            }
            return similarMovieList;
        }

        /// <summary>
        /// Check to see if there is a favorited movie saved.
        /// </summary>
        /// <returns></returns>
        private async Task CheckIfMovieIsFavorite()
        {
            var fileName = movieId.ToString();
            MovieDetailsModel returedFile = await _iDataManager.OpenFavoritesFile(fileName);

            if (returedFile != null)
            {
                Movie = returedFile;
                await UpdateFavoriteButton();
            }
        }

        /// <summary>
        /// Update the favorites button with the relevent text.
        /// </summary>
        /// <returns></returns>
        private async Task UpdateFavoriteButton()
        {
            IsFavoriteButtonEnabled = false;
            if (favorite.Contains("Save To Favorites"))
            {                
                Movie.is_favorite = true;

                await SaveFavorites();
                Favorite = "Remove from Favorites";
            }
            else
            {
                Movie.is_favorite = false;

                await DeleteMovieFromFavorites();
                Favorite = "Save To Favorites";
            }
        }

        /// <summary>
        /// Reload the details page with selected similar movie.
        /// </summary>
        /// <param name="selectedMovie"></param>
        private void LoadSimilarMovie(object selectedMovie)
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("selectedMovie", selectedMovie);
            _navigationService.NavigateAsync("MovieDetailsPage", navigationParams, true, true);
        }

        /// <summary>
        /// Save favorited movie to local storage.
        /// </summary>
        /// <returns></returns>
        private async Task SaveFavorites()
        {
            var filename = movieId.ToString();

            await _iDataManager.SaveFavoritesFile(movie, filename);
            IsFavoriteButtonEnabled = true;
        }

        /// <summary>
        /// Remove movie from favorited list.
        /// </summary>
        /// <returns></returns>
        private async Task DeleteMovieFromFavorites()
        {
            var filename = movieId.ToString();

            await _iDataManager.DeleteFavoritesFile(filename);

            IsFavoriteButtonEnabled = true;
        }
        #endregion
    }
}
