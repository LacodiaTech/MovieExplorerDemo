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

        public async Task<NowPlayingListModel> GetNowPlayingMoviesAsync(string sortBy)
        {
            // Build requestUrl string.
            var typeOfRequest = "top_rated";
            var nowPlayingRequestUrl = string.Format($"{BaseURL}{typeOfRequest}?api_key={APIKey}&sort_by={sortBy}");


            return await this.SendRequestAsync<object, NowPlayingListModel>(HttpMethod.Get, nowPlayingRequestUrl, null);
        }
    }
}
