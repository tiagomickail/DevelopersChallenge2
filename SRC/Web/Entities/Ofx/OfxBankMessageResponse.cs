using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Web.Entities
{
    public class OfxBankMessageResponse
    {
        [XmlElement("STMTTRNRS")]
        public OfxStatementTrasactionResponse StatementTrasactionResponse { get; set; }
    }
}
