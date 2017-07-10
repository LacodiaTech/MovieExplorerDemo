using MovieExplorer.Core.Models;
using PCLStorage;
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
        Task SaveFavoritesFile(MovieDetailsModel movieDetails, string fileName);

        /// <summary>
        /// Opens Favorited movie file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        Task<MovieDetailsModel> OpenFavoritesFile(string fileName);

        /// <summary>
        /// Deletes favorited file if exists.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        Task DeleteFavoritesFile(string fileName);

        /// <summary>
        /// Returns a list files from the local storage.
        /// </summary>
        /// <returns></returns>
        Task<IList<IFile>> GetListOfFiles();
    }
}
