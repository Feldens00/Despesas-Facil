using DespesasFacil.Entity;
using DespesasFacil.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesasFacil.Repository
{
    public class ExpenseRepository
    {

        public Database GetDataBase()
        {
            Database db = new Database();

            if (!db.DatabaseExists())
                db.CreateDatabase();

            return db;
        }

        public void Create(Expense pExpense)
        {
            Database db = GetDataBase();

            db.Expenses.InsertOnSubmit(pExpense);
            db.SubmitChanges();
        }

        public  List<Expense> Select(string pId)
        {
            Database db= GetDataBase();
            var query = from expenses in db.Expenses orderby expenses.description select expenses;
            // where c.Id.equals(pId) order by  c.Nome select c;
            List<Expense> exp= new List<Expense>(query.AsEnumerable());

            return exp;
        }

        public  void Delete(Expense expense)
        {
            Database db = GetDataBase();
            var query = from exp in db.Expenses where exp.id == exp.id select exp;
            db.Expenses.DeleteOnSubmit(query.ToList()[0]);
        
            db.SubmitChanges();
        }

        public void Update(Expense pExpense)
        {
            Database db = GetDataBase();
            var query = from exp in db.Expenses
                        where exp.id == pExpense.id
                        select exp;
            var expenseDoBanco = query.ToList()[0];
            expenseDoBanco.description = pExpense.description;
        }



        public List<Expense>GetAll()
        {
            Database db = GetDataBase();

            var query = from expense in db.Expenses orderby expense.description select expense;

            var expenses = new List<Expense>(query.AsEnumerable());
            return expenses;
        }

        private Expense GetOne(int pId)
        {
            Database db = GetDataBase();

            var exp = from expense in db.Expenses
                      where expense.id == pId
                      select expense;
            return exp.FirstOrDefault();

        }


    }
}
