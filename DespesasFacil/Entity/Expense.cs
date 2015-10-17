using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesasFacil.Entity
{

    [Table(Name ="Expenses")]
    public class Expense
    {
        [Column(IsPrimaryKey =true,IsDbGenerated =true)]
        public int id { get; set; }

        [Column(CanBeNull = false)]
        public string description { get; set; }

        [Column]
        public decimal values { get; set; }
        
        [Column(CanBeNull = false)]
        public Classification classifi { get; set; }

    }
}
