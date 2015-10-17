using DespesasFacil.Entity;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesasFacil.Storage
{
    public class Database : DataContext
    {

        private static string StringConnection = "Data Source='isostore:expenseDb.sdf'";

        public Database()
            :base(StringConnection)
        {}

        public Table<Expense>Expenses
        {
            get { return this.GetTable<Expense>(); }
        }

        public Table<Classification> classificationTB
        {
            get { return this.GetTable<Classification>(); }
        }


    }
}
