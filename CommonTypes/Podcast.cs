using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypes
{
    public class Podcast : IPodcast
    {
        public ISeries Show { get; set; }
        public List<IEpisode> EpisodeList { get; set; }
        public Podcast()
        {
        }
        public Podcast(ISeries _series, List<IEpisode> _episodeList)
        {
            this.Show = _series;
            this.EpisodeList = _episodeList;
        }
    }
}
