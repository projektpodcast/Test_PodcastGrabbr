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

            IPodcast a = deserializer.DeserializeRssXml("http://podcast.wdr.de/quarks.xml");


            //FileDataTarget dal = new FileDataTarget();
            //dal.SavePodcast(a);

            BusinessLayer.SaveObject bl = new BusinessLayer.SaveObject();
            bl.SavePodcastAsXml(a);
        }
    }
}
