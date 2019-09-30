using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlProcessor;

namespace TestPresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            /////Subscription Setter

            //EpisodeMappedToXml e = new EpisodeMappedToXml();


            //SeriesMappedToXml s = new SeriesMappedToXml();


            ////s.SeriesCompleted += e.SeriesDeserialized;


            ////s.XmlToSerializedPodcastSeries("http://joeroganexp.joerogan.libsynpro.com/rss");
            //s.XmlToSerializedPodcastSeries("https://www1.wdr.de/radio/podcasts/wdr2/kabarett132.podcast");
            ////s.XmlToSerializedPodcastSeries("https://russianmadeeasy.com/feed/podcast/");

            //EpisodeMappedToXml f = new EpisodeMappedToXml();
            //f.XmlToDeserializedPodcastEpisode("http://joeroganexp.joerogan.libsynpro.com/rss");

            //DeserializingManager deserializing = new DeserializingManager();
            //deserializing.DeserializeRssXml("http://joeroganexp.joerogan.libsynpro.com/rss");

            DeserializingManager deserializer = new DeserializingManager();
            deserializer.DeserializeRssXml("http://joeroganexp.joerogan.libsynpro.com/rss");

        }
    }
}
