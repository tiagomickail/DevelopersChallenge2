using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Web.Entities
{
    public class OfxBankAccount
    {
		[XmlElement("BANKID")]
		public string BankId { get; set; }

		[XmlElement("ACCTID")]
		public string AccountId { get; set; }

		[XmlElement("ACCTTYPE")]
		public string AccountType { get; set; }
	}
}
