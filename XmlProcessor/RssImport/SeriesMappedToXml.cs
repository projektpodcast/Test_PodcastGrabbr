﻿using CommonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace XmlProcessor.RssImport
{
    [XmlRoot("rss")]
    public class SeriesMappedToXml
    {
        [XmlElement("channel")]
        public DeserializedSeries DeserializedSeriesData { get; set; }
        [XmlIgnore]
        public ISeries SeriesDTO { get; set; }
        public class DeserializedSeries
        {
            [XmlElement("managingEditor")]
            public string PublisherName { get; set; }
            [XmlElement("author", Namespace = "http://www.itunes.com/dtds/podcast-1.0.dtd")]
            public string ITunesPublisherName { get; set; }
            [XmlElement("title")]
            public string PodcastTitle { get; set; }
            [XmlElement("keywords", Namespace = "http://www.itunes.com/dtds/podcast-1.0.dtd")]
            public string Keywords { get; set; }
            [XmlElement("category", Namespace = "http://www.itunes.com/dtds/podcast-1.0.dtd")]
            public List<Categories> CategoryList { get; set; }
            [XmlElement("subtitle", Namespace = "http://www.itunes.com/dtds/podcast-1.0.dtd")]
            public string Subtitle { get; set; }
            [XmlElement("language")]
            public string Language { get; set; }
            [XmlElement("description")]
            public string Description { get; set; }
            [XmlElement("pubDate")]
            public string LastUpdated { get; set; }
            [XmlElement("lastBuildDate")]
            public string LastBuildDate { get; set; }
            [XmlElement("image", Namespace = "http://www.itunes.com/dtds/podcast-1.0.dtd")]
            public ImageValue ImageUri { get; set; }
            //[XmlElement("image")]
            //public ImageValue ImageUri2 { get; set; }
        }

        public class Categories
        {
            [XmlAttribute("text")]
            public string CategoryName { get; set; }
        }
        public class ImageValue
        {
            [XmlAttribute("href")]
            public string ImageLink { get; set; }
        }
        
        public ISeries XmlToDeserializedSeries(MemoryStream memoryStreamWithXml)
        {
            DeserializeXmlToMappedPodcastSeries(memoryStreamWithXml);
            SerializedSeriesToDataTransferObject(DeserializedSeriesData);
            return SeriesDTO;
        }

        private void DeserializeXmlToMappedPodcastSeries(MemoryStream memoryStreamWithXml)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(SeriesMappedToXml));

            SeriesMappedToXml serializedSeries = new SeriesMappedToXml();
            serializedSeries = (SeriesMappedToXml)deserializer.Deserialize(memoryStreamWithXml);
            DeserializedSeriesData = serializedSeries.DeserializedSeriesData;
        }

        private void SerializedSeriesToDataTransferObject(DeserializedSeries deserializedSeries)
        {
            SeriesDTO = new Series
            {
                Description = deserializedSeries.Description,
                Language = deserializedSeries.Language,
                PodcastTitle = deserializedSeries.PodcastTitle,
                Keywords = deserializedSeries.Keywords,
                PublisherName = deserializedSeries.PublisherName != null? deserializedSeries.PublisherName : deserializedSeries.ITunesPublisherName,
                Subtitle = deserializedSeries.Subtitle,
                LastUpdated = ConvertDateTime(deserializedSeries.LastUpdated),
                LastBuildDate = ConvertDateTime(deserializedSeries.LastBuildDate),
                Category = IterateCategoriesAndAddToSeries(deserializedSeries),
                ImageUri = deserializedSeries.ImageUri != null ? deserializedSeries.ImageUri.ImageLink : ""
            };
        }

        private DateTime ConvertDateTime(string dateTimeForParsing)
        {
            DateTimeParser dateParser = new DateTimeParser();
            return dateParser.ConvertStringToDateTime(dateTimeForParsing);
        }

        private List<string> IterateCategoriesAndAddToSeries(DeserializedSeries _neueSerie)
        {
            List<string> categoryList = new List<string>();
            foreach (Categories item in _neueSerie.CategoryList)
            {
                categoryList.Add(item.CategoryName);
            }
            return categoryList;
        }

    }
}