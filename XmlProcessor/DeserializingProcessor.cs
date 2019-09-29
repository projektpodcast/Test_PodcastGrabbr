﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlProcessor
{
    public class DeserializingProcessor
    {
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
    }
}
