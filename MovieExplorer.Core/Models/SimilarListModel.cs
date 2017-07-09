using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Core.Models
{
    public class SimilarListModel
    {
        public int page { get; set; }
        public List<MovieDetails> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
