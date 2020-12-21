using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Entities
{
    public class OfxFile
    {
        public string FileName { get; set; }
        public OfxHeader Header { get; set; }
        public OfxInfo Info { get; set; }
    }
}
