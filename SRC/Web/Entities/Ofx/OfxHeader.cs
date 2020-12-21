using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Entities
{
    public class OfxHeader
    {
		public string Header { get; set; }
		public string Data { get; set; }
		public string Version { get; set; }
		public string Security { get; set; }
		public string Encoding { get; set; }
		public string Charset { get; set; }
		public string Compression { get; set; }
		public string OldFileUID { get; set; }
		public string NewFileUID { get; set; }
	}
}
