﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypes
{
    public interface IPodcast
    {
        List<IPodcastEpisode> EpisodeList { get; set; }
        IPodcastSeries Series { get; set; }
    }
}