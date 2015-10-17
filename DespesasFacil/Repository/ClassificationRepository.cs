using DespesasFacil.Entity;
using DespesasFacil.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesasFacil.Repository
{
   public class ClassificationRepository
    {
        public Database GetDataBase()
        {
            Database db = new Database();

            if (!db.DatabaseExists())
                db.CreateDatabase();

            return db;
        }

        public void Create(Classification pClassification)
        {
            Database db = GetDataBase();

            db.classificationTB.InsertOnSubmit(pClassification);
            db.SubmitChanges();
        }

        public List<Classification> Select(string pId)
        {
             Database db = GetDataBase();
            var query = from classifications in db.classificationTB orderby classifications.name  select classifications;
            // where c.Id.equals(pId) order by  c.Nome select c;
            List<Classification> clf = new List<Classification>(query.AsEnumerable());

            return clf;
        }

        public void Delete(Classification pClassification)
        {
            Database db = GetDataBase();
            var query = from clf in db.classificationTB where clf.idClassification == clf.idClassification select clf;
            db.classificationTB.DeleteOnSubmit(query.ToList()[0]);

            db.SubmitChanges();
        }

        public void Update(Classification pClassification)
        {
            Database db = GetDataBase();
            var query = from clf in db.classificationTB
                        where clf.idClassification == pClassification.idClassification
                        select clf;
            var clfDoBanco = query.ToList()[0];
            clfDoBanco.name = pClassification.name;
        }



        public List<Classification> GetAll()
        {
            Database db = GetDataBase();

            var query = from clf in db.classificationTB orderby clf.idClassification select clf;

            var clfBanco = new List<Classification>(query.AsEnumerable());
            return clfBanco;
        }

        private Classification GetOne(int pId)
        {
            Database db = GetDataBase();

            var clfBanco = from clf in db.classificationTB
                      where clf.idClassification == pId
                      select clf;
            return clfBanco.FirstOrDefault();

        }

    }
}
