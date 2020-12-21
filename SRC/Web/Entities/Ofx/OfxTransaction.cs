using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Web.Extensions;

namespace Web.Entities
{
    public class OfxTransaction
    {
		[XmlElement("TRNTYPE")]
		public string Type { get; set; }

		[XmlElement("DTPOSTED")]
		public string DateString { get; set; }

		[XmlIgnore]
		public DateTime Date { get { return DateString.OfxDateToDateTime(); } }

		[XmlElement("TRNAMT")]
		public decimal Ammount { get; set; }

		[XmlElement("MEMO")]
		public string Memo { get; set; }
	}
}
