using MovieExplorer.Core.Interfaces;
using MovieExplorer.Core.Models;
using PCLStorage;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MovieExplorer.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        // TODO: Authentication.
        // TODO: Error Handling.
        // TODO: Searching.
        // TODO: Sorting and Filtering.

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
        #endregion

        #region Public Properties

        /// <summary>
        /// List of Top Rated Movies.
        /// </summary>
        private ObservableCollection<MovieDetailsModel> topRatedList = new ObservableCollection<MovieDetailsModel>();
        public ObservableCollection<MovieDetailsModel> TopRatedList
        {
            get { return topRatedList; }
            set { SetProperty(ref topRatedList, value); }
        }

        /// <summary>
        /// List of Popular Movies.
        /// </summary>
        private ObservableCollection<MovieDetailsModel> popularList = new ObservableCollection<MovieDetailsModel>();
        public ObservableCollection<MovieDetailsModel> PopularList
        {
            get { return popularList; }
            set { SetProperty(ref popularList, value); }
        }

        /// <summary>
        /// List of Now Playing movies.
        /// </summary>
        private ObservableCollection<MovieDetailsModel> nowPlayingList = new ObservableCollection<MovieDetailsModel>();
        public ObservableCollection<MovieDetailsModel> NowPlayingList
        {
            get { return nowPlayingList; }
            set { SetProperty(ref nowPlayingList, value); }
        }

        /// <summary>
        /// List of Favorite movies.
        /// </summary>
        private ObservableCollection<MovieDetailsModel> favoriteList = new ObservableCollection<MovieDetailsModel>();
        public ObservableCollection<MovieDetailsModel> FavoriteList
        {
            get { return favoriteList; }
            set { SetProperty(ref favoriteList, value); }
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

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="navigationService"></param>
        /// <param name="iMovieExplorerAPIService"></param>
        /// <param name="iDataManager"></param>
        public MainPageViewModel(INavigationService navigationService, IMovieExplorerAPIService iMovieExplorerAPIService, IDataManager iDataManager)
        {
            _navigationService = navigationService;
            _iMovieExplorerAPIService = iMovieExplorerAPIService;
            _iDataManager = iDataManager;
        }

        #region Navigation
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            await GetTopRatedMovieListAsync();
            await GetPopularMoviesListAsync();
            await GetNowPlayingMovieListAsync();
            await GetFavoritedMovieListAsync();
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {

        }
        #endregion

        #region Methods

        /// <summary>
        /// Refresh content when user pulls to refresh.
        /// </summary>
        /// <returns></returns>
        public async Task PullToRefreshAsync()
        {
            await GetTopRatedMovieListAsync();
            await GetPopularMoviesListAsync();
            await GetNowPlayingMovieListAsync();
            await GetFavoritedMovieListAsync();
        }

        /// <summary>
        /// Gets Top Rated Movie List.
        /// </summary>
        /// <returns></returns>
        private async Task<TopRatedListModel> GetTopRatedMovieListAsync()
        {
            var sortBy = "popularity.des";
            var topRatedMovieList = await _iMovieExplorerAPIService.GetTopRatedMoviesAsync(sortBy);

            if (topRatedMovieList.results != null)
            {
                TopRatedList = new ObservableCollection<MovieDetailsModel>(topRatedMovieList.results);
            }
            return topRatedMovieList;
        }

        /// <summary>
        /// Get Popular Movie List.
        /// </summary>
        /// <returns></returns>
        private async Task<PopularListModel> GetPopularMoviesListAsync()
        {
            var sortBy = "popularity.des";
            var popularMovieList = await _iMovieExplorerAPIService.GetPopularMoviesAsync(sortBy);

            if (popularMovieList.results != null)
            {
                PopularList = new ObservableCollection<MovieDetailsModel>(popularMovieList.results);
            }
            return popularMovieList;
        }

        /// <summary>
        /// Get the list of the Now Playing Movies.
        /// </summary>
        /// <returns></returns>
        private async Task<NowPlayingListModel> GetNowPlayingMovieListAsync()
        {
            var sortBy = "popularity.des";
            var nowPlayingMovieList = await _iMovieExplorerAPIService.GetNowPlayingMoviesAsync(sortBy);

            if (nowPlayingMovieList.results != null)
            {
                NowPlayingList = new ObservableCollection<MovieDetailsModel>(nowPlayingMovieList.results);
            }
            return nowPlayingMovieList;
        }

        /// <summary>
        /// Search for favorited movies and gets movie details.
        /// </summary>
        /// <returns></returns>
        private async Task GetFavoritedMovieListAsync()
        {
            IList<IFile> listOfFileNames = await _iDataManager.GetListOfFiles();

            foreach (var item in listOfFileNames)
            {
                var fileName = item.Name;
                MovieDetailsModel movieDetail = await _iDataManager.OpenFavoritesFile(fileName);

                var favoriteMovie = await _iMovieExplorerAPIService.GetMovieByIdAsync(movieDetail.id);

                FavoriteList.Add(favoriteMovie);
            }
        }

        /// <summary>
        /// Navigate to the Movie Details page, passing in the selected movie model.
        /// </summary>
        /// <param name="selectedMovie"></param>
        private void ShowDetails(object selectedMovie)
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("selectedMovie", selectedMovie);
            _navigationService.NavigateAsync("MovieDetailsPage", navigationParams, true, true);
        }
        #endregion
    }
}
