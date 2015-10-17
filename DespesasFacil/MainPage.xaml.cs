using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DespesasFacil.Resources;
using DespesasFacil.Entity;
using DespesasFacil.Repository;

namespace DespesasFacil
{
    public partial class MainPage : PhoneApplicationPage
    {
        ExpenseRepository expenseRepository = new ExpenseRepository();
        Expense expense;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            RefreshList();
            


        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (expense!=null)
            {
                NewExpense page = e.Content as NewExpense;
                page.expUpdate = expense;
            }
        }

        private void RefreshList()
        {
            var expenses = expenseRepository.GetAll();
            lstExpenses.ItemsSource = expenses;
        }

        private void onClickNew(object sender, EventArgs e)
        {
            expense = null;
            NavigationService.Navigate(new Uri("/NewExpense.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {

        }

        private void onClickDelete(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete" + expense.description + "?", "Atenção", MessageBoxButton.OKCancel) == MessageBoxResult.OK) 
            {
                expenseRepository.Delete(expense);
                RefreshList();
            }
            
        }

        private void onClickEdit(object sender, EventArgs e)
        {

        }

        private void onSelectedChanged(object sender, SelectionChangedEventArgs e)
        {
            expense = (sender as ListBox).SelectedItem as Expense;        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}