using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Entities;

namespace Web.Context
{
    public class TransactionsContext : DbContext
    {
        public DbSet<File> Files { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var splited = AppDomain.CurrentDomain.BaseDirectory.Split("\\");
            var directory = string.Join("\\", splited.Take(splited.Length - 4).ToList());
            optionsBuilder.UseSqlServer(@$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={directory}\App_data\Database.mdf;Integrated Security=True;");
        }
    }
}
