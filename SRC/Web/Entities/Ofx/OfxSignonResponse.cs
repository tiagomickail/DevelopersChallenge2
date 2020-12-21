using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Web.Extensions;

namespace Web.Entities
{
    public class OfxSignonResponse
    {
		[XmlElement("DTSERVER")]
		public string DateSeverString { get; set; }

		[XmlIgnore]
		public DateTime DateSever { get { return DateSeverString.OfxDateToDateTime(); } }

		[XmlElement("LANGUAGE")]
		public string Language { get; set; }

		[XmlElement("STATUS")]
		public OfxStatus Status { get; set; }
	}
}
