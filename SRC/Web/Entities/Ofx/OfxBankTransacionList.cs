using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Web.Extensions;

namespace Web.Entities
{
    public class OfxBankTransacionList
    {
		[XmlElement("DTSTART")]
		public string DateStartString { get; set; }

		[XmlIgnore]
		public DateTime DateStart { get { return DateStartString.OfxDateToDateTime(); } }

		[XmlElement("DTEND")]
		public string DateEndString { get; set; }

		[XmlIgnore]
		public DateTime DateEnd { get { return DateEndString.OfxDateToDateTime(); } }

		[XmlElement("STMTTRN")]
		public List<OfxTransaction> Transactions { get; set; }
	}
}
