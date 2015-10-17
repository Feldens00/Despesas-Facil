using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DespesasFacil.Entity;
using DespesasFacil.Repository;

namespace DespesasFacil
{
    public partial class NewExpense : PhoneApplicationPage
    {
        ExpenseRepository ex = new ExpenseRepository();
        public Expense expUpdate { get; set; }
        public NewExpense()
        {
            InitializeComponent();
        }

        private void onClickSave(object sender, EventArgs e)
        {
            
            NavigationService.GoBack();

            if (expUpdate == null)
            {
                Expense expense = new Expense
                {
                    description = txtDescricao.Text,
                    values = decimal.Parse(txtValor.Text)
                };
                ex.Create(expense);
            }
            else
            {
                expUpdate.description = txtDescricao.Text;
                expUpdate.values = decimal.Parse(txtValor.Text);

                ex.Update(expUpdate);
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (expUpdate!=null)
            {
                txtDescricao.Text = expUpdate.description;
                txtValor.Text = expUpdate.values.ToString();
            }
        }
    }
}