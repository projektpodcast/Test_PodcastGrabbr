using CommonTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataAccessLayer
{
    public class FileDataSource
    {
        public List<ISeries> GetAllSeries()
        {
            FileDataGeneral fileMethods = new FileDataGeneral();
            DirectoryInfo folderPath = fileMethods.GetFilePath();
            FileInfo[] allFiles = GetFileNames(folderPath);

            List<ISeries> allSeries = Deserialize(folderPath, allFiles);

            return allSeries;
        }

        public FileInfo[] GetFileNames(DirectoryInfo folderPath)
        {
            FileInfo[] allFiles = folderPath.GetFiles();
            return allFiles;
        }

        public List<ISeries> Deserialize(DirectoryInfo folderPath, FileInfo[] allFiles)
        {
            //List<SerializablePodcast> podcastList = new List<SerializablePodcast>();


            List<ISeries> seriesList = new List<ISeries>();


            foreach (FileInfo item in allFiles)
            {
                string fileName = item.FullName;
                XmlSerializer serializer = new XmlSerializer(typeof(SerializablePodcast));
                FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                SerializablePodcast podcast = (SerializablePodcast)serializer.Deserialize(fileStream);

                seriesList.Add(podcast.Show);
            }
            return seriesList;
        }
    }
}
