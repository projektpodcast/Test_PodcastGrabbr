using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypes
{
    public interface IPodcast
    {
        ISeries Show { get; set; }
        List<IEpisode> EpisodeList { get; set; }
    }
}
