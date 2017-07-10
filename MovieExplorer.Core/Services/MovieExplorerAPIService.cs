using MovieExplorer.Core.Interfaces;
using MovieExplorer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Core.Services
{
    public class MovieExplorerAPIService: BaseProvider, IMovieExplorerAPIService
    {
        private const string APIKey = "ab41356b33d100ec61e6c098ecc92140";

        /// <summary>
        /// Gets Top Rated Movies.
        /// </summary>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public async Task<TopRatedListModel> GetTopRatedMoviesAsync(string sortBy)
        {
            // Build requestUrl string.
            var typeOfRequest = "top_rated";
            var topPlayingRequestUrl = string.Format($"{BaseURL}{typeOfRequest}?api_key={APIKey}&sort_by={sortBy}");

            return await this.SendRequestAsync<object, TopRatedListModel>(HttpMethod.Get, topPlayingRequestUrl, null);
        }

        /// <summary>
        /// Gets Popular Movies.
        /// </summary>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public async Task<PopularListModel> GetPopularMoviesAsync(string sortBy)
        {
            // Build requestUrl string.
            var typeOfRequest = "popular";
            var popularRequestUrl = string.Format($"{BaseURL}{typeOfRequest}?api_key={APIKey}&sort_by={sortBy}");

            return await this.SendRequestAsync<object, PopularListModel>(HttpMethod.Get, popularRequestUrl, null);
        }

        /// <summary>
        /// Gets Now Playing Movies.
        /// </summary>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public async Task<NowPlayingListModel> GetNowPlayingMoviesAsync(string sortBy)
        {
            // Build requestUrl string.
            var typeOfRequest = "now_playing";
            var nowPlayingRequestUrl = string.Format($"{BaseURL}{typeOfRequest}?api_key={APIKey}&sort_by={sortBy}");

            return await this.SendRequestAsync<object, NowPlayingListModel>(HttpMethod.Get, nowPlayingRequestUrl, null);
        }

        /// <summary>
        /// Gets Similar Movies.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        public async Task<SimilarListModel> GetSimilarMoviesAsync(int movieId)
        {
            var typeOfRequest = $"{movieId}/similar";
            var nowPlayingRequestUrl = string.Format($"{BaseURL}{typeOfRequest}?api_key={APIKey}");

            return await this.SendRequestAsync<object, SimilarListModel>(HttpMethod.Get, nowPlayingRequestUrl, null);
        }

        /// <summary>
        /// Gets movie details by id.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        public async Task<MovieDetailsModel> GetMovieByIdAsync(int movieId)
        {

            //   https://api.themoviedb.org/3/movie/{movie_id}?api_key=<<api_key>>&language=en-US

            var typeOfRequest = $"{movieId}";
            var favoritesRequestUrl = string.Format($"{BaseURL}{typeOfRequest}?api_key={APIKey}&language=en-US");

            return await this.SendRequestAsync<object, MovieDetailsModel>(HttpMethod.Get, favoritesRequestUrl, null);
        }
    }
}
