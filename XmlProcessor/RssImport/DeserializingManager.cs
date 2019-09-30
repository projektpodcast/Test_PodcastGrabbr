using CommonTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlProcessor.RssImport
{
    public class DeserializingManager
    {
        public IPodcast DeserializeRssXml(string xmlUri)
        {

            XmlLoader deserializingProcessor = new XmlLoader();
            XmlDocument loadedXml = deserializingProcessor.CreateXmlDocument(xmlUri);

            using (MemoryStream memoryStreamWithXml = deserializingProcessor.LoadXmlDocumentIntoMemoryStream(loadedXml))
            {
                ISeries series = CreateSeriesObject(memoryStreamWithXml);
                deserializingProcessor.SetMemoryStreamPositionToStart(memoryStreamWithXml);
                List<IEpisode> episodeList = CreateEpisodeListObject(memoryStreamWithXml);

                IPodcast newPodcast = CreatePodcast(series, episodeList);
                return newPodcast;
            }
        }

        public IPodcast CreatePodcast(ISeries series, List<IEpisode> episodeList)
        {
            IPodcast newPodcast = new Podcast
            {
                Series = series,
                EpisodeList = episodeList
            };
            return newPodcast;
        }

        public ISeries CreateSeriesObject(MemoryStream memStream)
        {
            SeriesMappedToXml seriesDeserializer = new SeriesMappedToXml();
            ISeries deserializedSeries = seriesDeserializer.XmlToDeserializedSeries(memStream);
            return deserializedSeries;
        }

        public List<IEpisode> CreateEpisodeListObject(MemoryStream memoryStream)
        {
            EpisodeMappedToXml episodeDeserializer = new EpisodeMappedToXml();
            List<IEpisode> deserializedEpisodeList = episodeDeserializer.XmlToDeserializedEpisode(memoryStream);
            return deserializedEpisodeList;
        }
    }
}
