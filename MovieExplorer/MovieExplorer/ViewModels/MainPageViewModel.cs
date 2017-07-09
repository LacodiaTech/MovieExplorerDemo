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
        private ObservableCollection<NowPlayingModel> nowPlayingList = new ObservableCollection<NowPlayingModel>();
        public ObservableCollection<NowPlayingModel> NowPlayingList
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
                ShowDetails(selectedMovie);
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
            await GetNowPlayingMovieListAsync();
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
                NowPlayingList = new ObservableCollection<NowPlayingModel>(nowPlayingMovieList.results);
            }
            return nowPlayingMovieList;
        }

        private void ShowDetails(object selectedMovie)
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("selectedMovie", selectedMovie);
            _navigationService.NavigateAsync("MovieDetailsPage", navigationParams);
        }
    }
}
