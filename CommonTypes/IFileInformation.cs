using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypes
{
    public interface IFileInformation
    {
        string SourceUri { get; set; }
        int Length { get; set; }
        string FileType { get; set; }
    }
}
