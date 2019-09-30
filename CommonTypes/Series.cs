using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypes
{
    public class Series : ISeries, IDisplayableImage
    {
        public string PublisherName { get; set; }
        public string PodcastTitle { get; set; }
        public List<string> Category { get; set; }
        public string Subtitle { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }

        public DateTime LastUpdated { get; set; }
        public DateTime LastBuildDate { get; set; }
        public string ImageUri { get; set; }

        public Series()
        {
        }
        public Series(string _publisherName, string _podcastTitle, string _category, string _subtitle, string _language, string _description, DateTime _lastUpdated, DateTime _lastBuildDate, string _imageUri)
        {
            this.PublisherName = _publisherName;
            this.PodcastTitle = _podcastTitle;
            this.Subtitle = _subtitle;
            this.Language = _language;
            this.Description = _description;
            this.LastUpdated = _lastUpdated;
            this.LastBuildDate = _lastBuildDate;
            this.Category = new List<string>
            {
                _category
            };
            this.ImageUri = _imageUri;
        }
    }
}
