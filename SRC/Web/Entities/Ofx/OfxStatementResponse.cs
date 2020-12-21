using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Web.Entities
{
    public class OfxStatementResponse
    {
		[XmlElement("CURDEF")]
		public string CURDEF { get; set; }

		[XmlElement("BANKACCTFROM")]
		public OfxBankAccount BankAccount { get; set; }

		[XmlElement("LEDGERBAL")]
		public OfxBalance Balance { get; set; }

		[XmlElement("BANKTRANLIST")]
		public OfxBankTransacionList BankTransacionList { get; set; }
	}
}
