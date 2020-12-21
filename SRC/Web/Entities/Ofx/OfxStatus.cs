using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Web.Entities
{
    public class OfxStatus
    {
        [XmlElement("SEVERITY")]
        public string Severity { get; set; }

        [XmlElement("CODE")]
        public string Code { get; set; }
    }
}
