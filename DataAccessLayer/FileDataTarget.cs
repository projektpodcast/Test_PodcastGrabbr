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
            DirectoryInfo filePath = CreateFilePath();
            string fullFilePath = filePath.FullName + fileName;
            CheckIfFileExists(fullFilePath);

            SerializePodcast(podcastToSave, fullFilePath);
        }

        private string CreateFileName(ISeries series)
        {
            string fileExtension = ".xml";
            string fileName = series.PodcastTitle.Split('/').Last() + fileExtension;
            return fileName;
        }

        private DirectoryInfo CreateFilePath()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory;
            string xmlFolderName = "Xml\\";
            string folderPathToCreate = filePath + xmlFolderName;
            DirectoryInfo fileDirectory = Directory.CreateDirectory(folderPathToCreate);
            return fileDirectory;
        }

        private bool CheckIfFileExists(string fullFilePath)
        {
            bool fileExists = false;
            if (File.Exists(fullFilePath))
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
