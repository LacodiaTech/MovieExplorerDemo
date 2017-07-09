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

namespace MovieExplorer.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
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
        #endregion

        #region Public Properties

        /// <summary>
        /// Model of Top Rated movies.
        /// </summary>
        private TopRatedListModel topRatedListItems;
        public TopRatedListModel TopRatedListItems
        {
            get { return topRatedListItems; }
            set { SetProperty(ref topRatedListItems, value); }
        }

        /// <summary>
        /// List of Top Rated Movies.
        /// </summary>
        private ObservableCollection<MovieDetails> topRatedList = new ObservableCollection<MovieDetails>();
        public ObservableCollection<MovieDetails> TopRatedList
        {
            get { return topRatedList; }
            set { SetProperty(ref topRatedList, value); }
        }

        /// <summary>
        /// Model of Popular movies.
        /// </summary>
        private PopularListModel popularListItems;
        public PopularListModel PopularListItems
        {
            get { return popularListItems; }
            set { SetProperty(ref popularListItems, value); }
        }

        /// <summary>
        /// List of Popular Movies.
        /// </summary>
        private ObservableCollection<MovieDetails> popularList = new ObservableCollection<MovieDetails>();
        public ObservableCollection<MovieDetails> PopularList
        {
            get { return popularList; }
            set { SetProperty(ref popularList, value); }
        }

        /// <summary>
        /// Model of movies now playing.
        /// </summary>
        private NowPlayingListModel nowPlayingListItems;
        public NowPlayingListModel NowPlayingListItems
        {
            get { return nowPlayingListItems; }
            set { SetProperty(ref nowPlayingListItems, value); }
        }

        /// <summary>
        /// List of Now Playing movies.
        /// </summary>
        private ObservableCollection<MovieDetails> nowPlayingList = new ObservableCollection<MovieDetails>();
        public ObservableCollection<MovieDetails> NowPlayingList
        {
            get { return nowPlayingList; }
            set { SetProperty(ref nowPlayingList, value); }
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

        public MainPageViewModel(INavigationService navigationService, IMovieExplorerAPIService iMovieExplorerAPIService)
        {
            _navigationService = navigationService;
            _iMovieExplorerAPIService = iMovieExplorerAPIService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            await GetTopRatedMovieListAsync();
            await GetPopularMoviesListAsync();
            await GetNowPlayingMovieListAsync();
        }

        #region Methods
        private async Task<TopRatedListModel> GetTopRatedMovieListAsync()
        {
            // TODO: Implement softing and filtering feature.
            var sortBy = "popularity.des";
            var topRatedMovieList = await _iMovieExplorerAPIService.GetTopRatedMoviesAsync(sortBy);

            if (topRatedMovieList.results != null)
            {
                TopRatedList = new ObservableCollection<MovieDetails>(topRatedMovieList.results);
            }
            return topRatedMovieList;
        }

        private async Task<PopularListModel> GetPopularMoviesListAsync()
        {
            // TODO: Implement softing and filtering feature.
            var sortBy = "popularity.des";
            var popularMovieList = await _iMovieExplorerAPIService.GetPopularMoviesAsync(sortBy);

            if (popularMovieList.results != null)
            {
                PopularList = new ObservableCollection<MovieDetails>(popularMovieList.results);
            }
            return popularMovieList;
        }

        /// <summary>
        /// Get the list of the Now Playing Movies.
        /// </summary>
        /// <returns></returns>
        private async Task<NowPlayingListModel> GetNowPlayingMovieListAsync()
        {
            // TODO: Implement softing and filtering feature.
            var sortBy = "popularity.des";
            var nowPlayingMovieList = await _iMovieExplorerAPIService.GetNowPlayingMoviesAsync(sortBy);

            if (nowPlayingMovieList.results != null)
            {
                NowPlayingList = new ObservableCollection<MovieDetails>(nowPlayingMovieList.results);
            }
            return nowPlayingMovieList;
        }

        private void ShowDetails(object selectedMovie)
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("selectedMovie", selectedMovie);
            _navigationService.NavigateAsync("MovieDetailsPage", navigationParams);
        }
        #endregion
    }
}
