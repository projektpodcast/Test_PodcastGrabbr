using CommonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlProcessor.RssImport;
using DataAccessLayer;
using BusinessLayer;

namespace TestPresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            DeserializingManager deserializer = new DeserializingManager();

            //IPodcast a = deserializer.DeserializeRssXml("http://joeroganexp.joerogan.libsynpro.com/rss");

            //IPodcast a = deserializer.DeserializeRssXml("http://podcast.wdr.de/quarks.xml");

            //IPodcast a = deserializer.DeserializeRssXml("http://web.ard.de/radiotatort/rss/podcast.xml");

            //IPodcast a = deserializer.DeserializeRssXml("https://www1.wdr.de/radio/podcasts/wdr2/kabarett132.podcast");

            IPodcast a = deserializer.DeserializeRssXml("http://www1.swr.de/podcast/xml/swr2/forum.xml");

            //FileDataTarget dal = new FileDataTarget();
            //dal.SavePodcast(a);

            SaveObject blSave = new SaveObject();
            blSave.SavePodcastAsXml(a);

            GetObjects blGet = new GetObjects();
            List<ISeries> seriesList = blGet.GetSeriesList();
        }
    }
}
