using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonTypes;
using DataAccessLayer;

namespace BusinessLayer
{
    public class SaveObject
    {
        public void SavePodcastAsXml(IPodcast podcast)
        {
            IDataTarget fileTarget = Factory.CreateFileTarget();
            fileTarget.SavePodcast(podcast);
        }
    }
}
