using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Entities
{
    public class File
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
