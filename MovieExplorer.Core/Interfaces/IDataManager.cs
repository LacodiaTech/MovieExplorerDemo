using MovieExplorer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Core.Interfaces
{
    public interface IDataManager
    {
        /// <summary>
        /// Saves Favorited movie to file.
        /// </summary>
        /// <param name="movieDetails"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        Task SaveFavoritesFile(MovieDetails movieDetails, string fileName);

        /// <summary>
        /// Opens Favorited movie file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        Task<MovieDetails> OpenFavoritesFile(string fileName);

        /// <summary>
        /// Deletes favorited file if exists.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        Task DeleteFavoritesFile(string fileName);
    }
}
