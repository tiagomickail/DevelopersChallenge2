using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Web.Extensions;

namespace Web.Entities
{
    public class OfxBalance
    {
		[XmlElement("DTASOF")]
		public string DateString { get; set; }

		[XmlIgnore]
		public DateTime Date { get { return DateString.OfxDateToDateTime(); } }

		[XmlElement("BALAMT")]
		public decimal BalanceAmmount { get; set; }
	}
}
