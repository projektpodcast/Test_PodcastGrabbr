﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using CommonTypes;

namespace XmlProcessor.RssImport
{
    [XmlRoot("rss")]
    public class EpisodeMappedToXml
    {
        [XmlIgnore]
        public List<DeserializedEpisode> AllDeserializedEpisodes { get; set; }
        [XmlIgnore]
        public List<IEpisode> EpisodeListDTO { get; set; }
        [XmlElement("channel")]
        public ChannelNode Channel { get; set; }

        public class ChannelNode
        {
            [XmlElement("item")]
            public List<DeserializedEpisode> DeserializedEpisodeList { get; set; }
        }
        public class DeserializedEpisode
        {
            [XmlElement("title")]
            public string Title { get; set; }
            [XmlElement("pubDate")]
            public string PublishingDate { get; set; }
            [XmlElement("keywords", Namespace = "http://www.itunes.com/dtds/podcast-1.0.dtd")]
            public string Keywords { get; set; }
            [XmlElement("description")]
            public string Summary { get; set; }
            [XmlElement("image", Namespace = "http://www.itunes.com/dtds/podcast-1.0.dtd")]
            public ImageLink LinkToImage{ get; set; }
            [XmlElement("enclosure")]
            public FileData FileInfo { get; set; }
        }

        public class ImageLink
        {
            [XmlAttribute("href")]
            public string Link { get; set; }
        }

        public class FileData
        {
            [XmlAttribute("url")]
            public string PodcastUri { get; set; }
            [XmlAttribute("length")]
            public int Length { get; set; }
            [XmlAttribute("type")]
            public string Type { get; set; }
        }

        public List<IEpisode> XmlToDeserializedEpisode(MemoryStream xmlStream)
        {
            XmlLoader deserializingProcessor = new XmlLoader();

            DeserializeXmlToMappedPodcastEpisode(xmlStream);

            SerializedSeriesToDataTransferObject(AllDeserializedEpisodes);
            return EpisodeListDTO;
        }

        private void DeserializeXmlToMappedPodcastEpisode(MemoryStream memoryStreamWithXml)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(EpisodeMappedToXml));
            DeserializedEpisode serializedSeries = new DeserializedEpisode();

            EpisodeMappedToXml episodesCollection = new EpisodeMappedToXml();
            episodesCollection = (EpisodeMappedToXml)deserializer.Deserialize(memoryStreamWithXml);

            AllDeserializedEpisodes = episodesCollection.Channel.DeserializedEpisodeList;
        }

        private void SerializedSeriesToDataTransferObject(List<DeserializedEpisode> deserializedSeriesList)
        {
            EpisodeListDTO = new List<IEpisode>();
            foreach (DeserializedEpisode item in deserializedSeriesList)
            {
                Episode newEpisode = new Episode
                {
                    Title = item.Title,
                    PublishDate = ConvertDateTime(item.PublishingDate),
                    Keywords = item.Keywords,
                    Summary = item.Summary,
                    ImageUri = item.LinkToImage != null ? item.LinkToImage.Link : "",
                    FileDetails = new FileInformation(item.FileInfo.PodcastUri, item.FileInfo.Length, item.FileInfo.Type)
                };
                EpisodeListDTO.Add(newEpisode);
            }
            AllDeserializedEpisodes = null;
        }

        private DateTime ConvertDateTime(string dateTimeForParsing)
        {
            DateTimeParser dateParser = new DateTimeParser();
            return dateParser.ConvertStringToDateTime(dateTimeForParsing);
        }

    }
}