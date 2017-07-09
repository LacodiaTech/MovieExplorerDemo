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
        /// Gets Now Playing Movies.
        /// </summary>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        Task<NowPlayingListModel> GetNowPlayingMoviesAsync(string sortBy);
    }
}
