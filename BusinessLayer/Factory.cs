using CommonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public static class Factory
    {

        public static SerializablePodcast CreateSerializer(IPodcast podcast)
        {
            return new SerializablePodcast(podcast);
        }

        public static IDataTarget CreateFileTarget()
        {
            return new FileDataTarget();
        }

    }
}
