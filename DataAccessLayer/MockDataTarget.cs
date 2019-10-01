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
            ISeries _series = new Series("WDR", "Late Night mit uns", "Talk", "Toller Talk zur späten Stunde", "de", "Lassen Sie sich in diesem Produktion fallen. Ein aufregender Talk mit aufregenden Gästen", DateTime.Now, DateTime.Now, "www.google.de");
            IEpisode _episode1 = new Episode("Der Anfang", DateTime.Now, "Gespräch über Gott und die Welt", keywords, "https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png");
            IEpisode _episode2 = new Episode("Nummero Zwei", DateTime.Now, "Gespräch über Maultaschen und Naschen", keywords, "https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png");
            List<IEpisode> _episodeList = new List<IEpisode>();
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
