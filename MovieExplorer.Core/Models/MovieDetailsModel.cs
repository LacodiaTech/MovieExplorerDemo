using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Core.Models
{
    public class MovieDetailsModel
    {
        public int vote_count { get; set; }
        public int id { get; set; }
        public bool video { get; set; }
        public double vote_average { get; set; }
        public string title { get; set; }
        public double popularity { get; set; }
        public string poster_path { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public List<int> genre_ids { get; set; }
        public string backdrop_path { get; set; }
        public bool adult { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public bool is_favorite { get; set; }

        public string poster_fullPathw92
        {
            get
            {
                return "http://image.tmdb.org/t/p/w92" + poster_path;
            }
        }

        public string poster_fullPathw154
        {
            get
            {
                return "http://image.tmdb.org/t/p/w154" + poster_path;
            }
        }

        public string poster_fullPathw185
        {
            get
            {
                return "http://image.tmdb.org/t/p/w185" + poster_path;
            }
        }
    }
}
