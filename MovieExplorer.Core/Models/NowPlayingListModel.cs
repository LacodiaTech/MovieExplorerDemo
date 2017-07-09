using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExplorer.Core.Models
{
    public class NowPlayingListModel
    {
        public List<NowPlayingModel> results { get; set; }
        public int page { get; set; }
        public int total_results { get; set; }
        public NowPlayingDateModel dates { get; set; }
        public int total_pages { get; set; }
    }
}
