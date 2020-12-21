using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Type { get; set; }
		public DateTime Date { get; set; }
		public decimal Ammount { get; set; }
		public string Memo { get; set; }
	}
}
