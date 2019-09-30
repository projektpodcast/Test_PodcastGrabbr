using CommonTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlProcessor
{
    public class DeserializingManager
    {
        public IPodcast DeserializeRssXml(string xmlUri)
        {

            DeserializingProcessor deserializingProcessor = new DeserializingProcessor();
            XmlDocument loadedXml = deserializingProcessor.CreateXmlDocument(xmlUri);

            using (MemoryStream memoryStreamWithXml = deserializingProcessor.LoadXmlDocumentIntoMemoryStream(loadedXml))
            {
                IPodcastSeries series = CreateSeriesObject(memoryStreamWithXml);
                deserializingProcessor.SetMemoryStreamPositionToStart(memoryStreamWithXml);
                List<IPodcastEpisode> episodeList = CreateEpisodeListObject(memoryStreamWithXml);

                IPodcast newPodcast = CreatePodcast(series, episodeList);
                return newPodcast;
            }
        }

        public IPodcast CreatePodcast(IPodcastSeries series, List<IPodcastEpisode> episodeList)
        {
            IPodcast newPodcast = new Podcast
            {
                Series = series,
                EpisodeList = episodeList
            };
            return newPodcast;
        }

        public IPodcastSeries CreateSeriesObject(MemoryStream memStream)
        {
            SeriesMappedToXml seriesDeserializer = new SeriesMappedToXml();
            IPodcastSeries deserializedSeries = seriesDeserializer.XmlToSerializedPodcastSeries(memStream);
            return deserializedSeries;
        }

        public List<IPodcastEpisode> CreateEpisodeListObject(MemoryStream memoryStream)
        {
            EpisodeMappedToXml episodeDeserializer = new EpisodeMappedToXml();
            List<IPodcastEpisode> deserializedEpisodeList = episodeDeserializer.XmlToDeserializedPodcastEpisode(memoryStream);
            return deserializedEpisodeList;
        }
    }
}
