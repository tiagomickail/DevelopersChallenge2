using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Web.Entities
{
    public class OfxStatementTrasactionResponse
    {
		[XmlElement("TRNUID")]
		public string TransactionUID { get; set; }

		[XmlElement("STATUS")]
		public OfxStatus Status { get; set; }

		[XmlElement("STMTRS")]
		public OfxStatementResponse StatementResponse { get; set; }
	}
}
