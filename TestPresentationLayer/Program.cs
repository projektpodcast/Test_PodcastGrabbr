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
            DeserializingManager deserializer = new DeserializingManager();
            deserializer.DeserializeRssXml("http://joeroganexp.joerogan.libsynpro.com/rss");

        }
    }
}
