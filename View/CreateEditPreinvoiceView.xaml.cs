using Microsip_Rentas.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Microsip_Rentas.View
{
    /// <summary>
    /// Lógica de interacción para CreateEditPreinvoiceView.xaml
    /// </summary>
    public partial class CreateEditPreinvoiceView : UserControl
    {
        public CreateEditPreinvoiceView()
        {
            InitializeComponent();
        }

        private void SaveAndNewButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Save and new
        }

        private void SaveAndCloseButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Save

            var mainViewModel = (Application.Current.MainWindow as MainWindow).DataContext as MainViewModel;


            if (mainViewModel.ShowPreinvoicesViewCommand.CanExecute(null))
            {
                mainViewModel.ShowPreinvoicesViewCommand.Execute(null);
            }
        }

        private void GenerarPedidoButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Generar pedido
        }
    }
}
