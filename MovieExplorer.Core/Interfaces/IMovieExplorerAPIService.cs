using MovieExplorer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Core.Interfaces
{
    public interface IMovieExplorerAPIService
    {
        /// <summary>
        /// Gets Top Rated Movies.
        /// </summary>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        Task<TopRatedListModel> GetTopRatedMoviesAsync(string sortBy);

        /// <summary>
        /// Gets Popular Movies.
        /// </summary>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        Task<PopularListModel> GetPopularMoviesAsync(string sortBy);

        /// <summary>
        /// Gets Now Playing Movies.
        /// </summary>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        Task<NowPlayingListModel> GetNowPlayingMoviesAsync(string sortBy);

        /// <summary>
        /// Gets Similar Movies.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        Task<SimilarListModel> GetSimilarMoviesAsync(int movieId);

        /// <summary>
        /// Gets movie details by id.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        Task<MovieDetailsModel> GetMovieByIdAsync(int movieId);
    }
}
