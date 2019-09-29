using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypes
{
    public class Podcast : IPodcast
    {
        public IPodcastSeries Series { get; set; }
        public List<IPodcastEpisode> EpisodeList { get; set; }
        public Podcast()
        {
        }
        public Podcast(IPodcastSeries _series, List<IPodcastEpisode> _episodeList)
        {
            this.Series = _series;
            this.EpisodeList = _episodeList;
        }
    }
}
