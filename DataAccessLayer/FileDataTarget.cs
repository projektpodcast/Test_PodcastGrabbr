using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using CommonTypes;


namespace DataAccessLayer
{
    public class FileDataTarget : IDataTarget
    {
        public void SavePodcast(IPodcast podcastToSave)
        {
            string fileName = CreateFileName(podcastToSave.Show);
            string filePath = CreateFilePath();
            CheckIfFileExists(fileName, filePath);
            SerializePodcast(podcastToSave, filePath + fileName);
        }

        private string CreateFileName(ISeries series)
        {
            string fileExtension = ".xml";
            string fileName = series.PodcastTitle.Split('/').Last() + fileExtension;
            return fileName;
        }

        private string CreateFilePath()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory;
            return filePath;
        }

        private bool CheckIfFileExists(string fileName, string filePath)
        {
            bool fileExists = false;
            string fileToLookFor = filePath + fileName;
            if (File.Exists(fileToLookFor))
            {
                fileExists = true;
            }
            return fileExists;
        }

        private void SerializePodcast(IPodcast podcast, string filePath)
        {
            SerializablePodcast transformedPodcast = new SerializablePodcast(podcast);

            XmlSerializer serializer = new XmlSerializer(typeof(SerializablePodcast));

            FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
            serializer.Serialize(fileStream, transformedPodcast);
            fileStream.Close();
        }


    }
}
