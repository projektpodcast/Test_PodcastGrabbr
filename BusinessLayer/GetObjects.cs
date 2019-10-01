using CommonTypes;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class GetObjects
    {
        public List<ISeries> GetSeriesList()
        {
            FileDataSource fileSource = Factory.CreateFileSource();
            List<ISeries> allSeriesList = fileSource.GetAllSeries();
            return allSeriesList;
        }
    }
}
