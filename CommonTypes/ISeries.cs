using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypes
{
    public interface ISeries
    {
        List<string> Category { get; set; }
        string Description { get; set; }
        string Language { get; set; }
        string PodcastTitle { get; set; }
        string PublisherName { get; set; }
        string Subtitle { get; set; }
        DateTime LastUpdated { get; set; }
    }
}
