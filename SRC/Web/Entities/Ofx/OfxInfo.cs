using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Web.Entities
{
    [XmlRoot("OFX")]
    public class OfxInfo
    {
        [XmlElement("SIGNONMSGSRSV1")]
        public OfxSignon Signon { get; set; }

        [XmlElement("BANKMSGSRSV1")]
        public OfxBankMessageResponse BankMessageResponse { get; set; }
    }
}
