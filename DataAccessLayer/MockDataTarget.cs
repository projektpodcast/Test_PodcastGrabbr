using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonTypes;

namespace DataAccessLayer
{
    class MockDataTarget : IDataTarget
    {
        public List<IPodcast> PodcastDb { get; set; }
        public List<IPodcast> Backup { get; set; }
        public MockDataTarget()
        {
            PodcastDb = new List<IPodcast>();
            CreateExampleData();
        }

        public void CreateExampleData()
        {
            string keywords = "talkshow,comedy";
            IPodcastSeries _series = new PodcastSeries("WDR", "Late Night mit uns", "Talk", "Toller Talk zur späten Stunde", "de", "Lassen Sie sich in diesem Produktion fallen. Ein aufregender Talk mit aufregenden Gästen", DateTime.Now, DateTime.Now, "www.google.de");
            IPodcastEpisode _episode1 = new PodcastEpisode("Der Anfang", DateTime.Now, "Gespräch über Gott und die Welt", keywords);
            IPodcastEpisode _episode2 = new PodcastEpisode("Nummero Zwei", DateTime.Now, "Gespräch über Maultaschen und Naschen", keywords);
            List<IPodcastEpisode> _episodeList = new List<IPodcastEpisode>();
            _episodeList.Add(_episode1);
            _episodeList.Add(_episode2);
            IPodcast existingEntry = new Podcast(_series, _episodeList);
            PodcastDb.Add(existingEntry);
            CreateDataBackup(existingEntry);
        }

        public void CreateDataBackup(IPodcast existingEntry)
        {
            Backup = new List<IPodcast>
            {
                existingEntry
            };
        }

        public void SavePodcast(IPodcast podcastToSave)
        {
            PodcastDb.Add(podcastToSave);
        }

    }
}
