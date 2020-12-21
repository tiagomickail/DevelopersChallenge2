using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Web.Entities
{
    public class OfxSignon
    {
        [XmlElement("SONRS")]
        public OfxSignonResponse SignonResponse { get; set; }
    }
}
