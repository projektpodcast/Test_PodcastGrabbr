using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypes
{
    public class SerializablePodcast
    {
        public Series Show { get; set; }
        public List<Episode> EpisodeList { get; set; }

        public SerializablePodcast()
        {
        }
        public SerializablePodcast(IPodcast _podcast)
        {
            this.Show = (Series)_podcast.Show;
            this.EpisodeList = _podcast.EpisodeList.ConvertAll(obj => (Episode)obj);
        }

    }
}
