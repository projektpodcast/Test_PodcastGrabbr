using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypes
{
    public interface IEpisode
    {
        string Title { get; set; }
        DateTime PublishDate { get; set; }
        string Summary { get; set; }
        string Keywords { get; set; }
        IFileInformation FileDetails { get; set; }
    }
}
