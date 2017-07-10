using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLStorage;
using MovieExplorer.Core.Models;
using Newtonsoft.Json;
using MovieExplorer.Core.Interfaces;

namespace MovieExplorer.Core.Services
{
    public class DataManager : IDataManager
    {
        //TODO: Abstract out data management system if more file types will be saved.

        IFolder folder = FileSystem.Current.LocalStorage;

        /// <summary>
        /// Writes a Json file to the local storage.
        /// </summary>
        /// <param name="movieDetails"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task SaveFavoritesFile(MovieDetailsModel movieDetails, string fileName)
        {
            IFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            var fileString = JsonConvert.SerializeObject(movieDetails);
            await file.WriteAllTextAsync(fileString);
        }

        /// <summary>
        /// Reads a file from local storage.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<MovieDetailsModel> OpenFavoritesFile(string fileName)
        {
            MovieDetailsModel movieDetails = new MovieDetailsModel();

            if ((await folder.CheckExistsAsync(fileName)) == ExistenceCheckResult.NotFound)
            {
                return null;
            }
            else
            {
                IFile file = await folder.GetFileAsync(fileName);
                var jsonFile = await file.ReadAllTextAsync();

                if (!string.IsNullOrEmpty(jsonFile))
                {
                    movieDetails = JsonConvert.DeserializeObject<MovieDetailsModel>(jsonFile);
                    return movieDetails;
                }
                return null;
            }
        }

        /// <summary>
        /// Deletes Favorited File if exists.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task DeleteFavoritesFile(string fileName)
        {
            if ((await folder.CheckExistsAsync(fileName)) == ExistenceCheckResult.FileExists)
            {
                IFile file = await folder.GetFileAsync(fileName);
                await file.DeleteAsync();
            }
        }

        /// <summary>
        /// Returns a list of files in the local storage.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<IFile>> GetListOfFiles()
        {
            IList<IFile> fileList = await folder.GetFilesAsync();
            return fileList;
        }
    }
}
