using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DespesasFacil.Repository;

namespace DespesasFacil
{
    public partial class Classification : PhoneApplicationPage
    {
       ClassificationRepository clfRepository = new ClassificationRepository();
        public Classification()
        {
            InitializeComponent();
        }

        private void onClickSave(object sender, EventArgs e)
        {
            Classification  clas = new Classification();
             clas.name = txtNome.Text;
            clfRepository.Create(clas);

            NavigationService.GoBack();
        }
    }
}