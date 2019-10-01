using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypes
{
    public class Episode : IEpisode
    {
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string Summary { get; set; }
        public string Keywords { get; set; }
        public string ImageUri { get; set; }
        public FileInformation FileDetails { get; set; }

        public Episode()
        {
        }
        public Episode(string _title, DateTime _publishDate, string _summary, string _keywords, string _imageUri)
        {
            this.Title = _title;
            this.PublishDate = _publishDate;
            this.Summary = _summary;
            this.Keywords = _keywords;
            this.ImageUri = _imageUri;
        }

    }
}
