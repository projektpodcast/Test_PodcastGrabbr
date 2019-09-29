using CommonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    interface IDataTarget
    {
        void SavePodcast(IPodcast podcastToSave);

        ///weitere operations wie update, create, insert, select(suchparameter), ...
    }
}
