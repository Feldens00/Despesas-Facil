using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesasFacil.Entity
{
    [Table (Name ="Classifications")]
   public class Classification
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int idClassification { get; set; }

        [Column(CanBeNull = false)]
        public string name { get; set; }
    }
}
