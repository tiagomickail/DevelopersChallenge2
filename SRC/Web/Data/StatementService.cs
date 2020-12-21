using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web.Context;
using Web.Extensions;
using entity = Web.Entities;

namespace Web.Data
{
    public class StatementService
    {
        private readonly TransactionsContext _context;
        public StatementService (TransactionsContext context)
        {
            _context = context;
        }

        public async Task ImportOfxFiles(Dictionary<string, MemoryStream> files)
        {
            //Convert file to object
            var ofxFiles = files.Select(f => f.Value.MemoryStreamToOfxFile(f.Key)).ToList();

            //Parse to entity object
            var objs = ofxFiles.Select(o => new
            {
                o.FileName,
                o.Info.BankMessageResponse
                                    .StatementTrasactionResponse
                                    .StatementResponse
                                    .BankTransacionList
                                    .Transactions
            }).ToList();

            var entities = objs.Select(o => new entity.File()
            {
                FileName = o.FileName,
                Transactions = o.Transactions.Select(t => new entity.Transaction()
                {
                    Type = t.Type,
                    Date = t.Date,
                    Ammount = t.Ammount,
                    Memo = t.Memo
                }).ToList()
            }).ToList();

            //Save data
            _context.AddRange(entities);
            _context.SaveChanges();
        }

        public async Task<List<entity.File>> GetFiles()
        {
            return _context.Files.ToList();
        }

        public async Task<List<entity.Transaction>> GetConsolidatedTransactions(int[] ids)
        {
            //Use linq to get transactions and remove duplicates
            return _context.Files.Where(f => ids.Contains(f.Id))
                            .SelectMany(f => f.Transactions)
                            .DistinctBy(x => new { x.Ammount, x.Date, x.Memo, x.Type })
                            .OrderBy(o => o.Date)
                            .ToList();
        }
    }
}
