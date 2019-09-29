﻿using CommonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace XmlProcessor
{
    [XmlRoot("rss")]
    public class SeriesMappedToXml
    {
        [XmlElement("channel")]
        public DeserializedSeries DeserializedSeriesData { get; set; }
        [XmlIgnore]
        public IPodcastSeries DeserialisedDTOPodcastSeries { get; set; }
        public class DeserializedSeries
        {
            [XmlElement("managingEditor")]
            public string PublisherName { get; set; }
            [XmlElement("title")]
            public string PodcastTitle { get; set; }
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

        public void XmlToSerializedPodcastSeries(string xmlUri)
        {
            DeserializingProcessor deserializingProcessor = new DeserializingProcessor();
            XmlDocument loadedXml = deserializingProcessor.CreateXmlDocument(xmlUri);

            using (MemoryStream memoryStreamWithXml = deserializingProcessor.LoadXmlDocumentIntoMemoryStream(loadedXml))
            {
                DeserializeXmlToMappedPodcastSeries(memoryStreamWithXml);
            }
            SerializedSeriesToDataTransferObject(DeserializedSeriesData);
        }

        public XmlDocument CreateXmlDocument(string xmlUri)
        {
            XmlDocument sourceXml = new XmlDocument();
            sourceXml.Load(xmlUri);
            return sourceXml;
        }

        public MemoryStream LoadXmlDocumentIntoMemoryStream(XmlDocument loadedXml)
        {
            MemoryStream memStream = new MemoryStream();
            loadedXml.Save(memStream);
            memStream.Position = 0;
            return memStream;
        }

        public void DeserializeXmlToMappedPodcastSeries(MemoryStream memoryStreamWithXml)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(SeriesMappedToXml));

            SeriesMappedToXml serializedSeries = new SeriesMappedToXml();
            serializedSeries = (SeriesMappedToXml)deserializer.Deserialize(memoryStreamWithXml);
            DeserializedSeriesData = serializedSeries.DeserializedSeriesData;
        }

        public void SerializedSeriesToDataTransferObject(DeserializedSeries deserializedSeries)
        {
            DeserialisedDTOPodcastSeries = new PodcastSeries
            {
                Description = deserializedSeries.Description,
                Language = deserializedSeries.Language,
                PodcastTitle = deserializedSeries.PodcastTitle,
                PublisherName = deserializedSeries.PublisherName,
                Subtitle = deserializedSeries.Subtitle,
                LastUpdated = ConvertDateTime(deserializedSeries.LastUpdated),
                LastBuildDate = ConvertDateTime(deserializedSeries.LastBuildDate),
                Category = IterateCategoriesAndAddToSeries(deserializedSeries),
                ImageUri = deserializedSeries.ImageUri.ImageLink
            };
        }

        public DateTime ConvertDateTime(string dateTimeForParsing)
        {
            DateTimeParser dateParser = new DateTimeParser();
            return dateParser.ConvertStringToDateTime(dateTimeForParsing);
        }

        public List<string> IterateCategoriesAndAddToSeries(DeserializedSeries _neueSerie)
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