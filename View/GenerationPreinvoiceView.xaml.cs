using Microsip_Rentas.Model;
using Microsip_Rentas.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica de interacción para GenerationPreinvoiceView.xaml
    /// </summary>
    public partial class GenerationPreinvoiceView : UserControl
    {
        public ObservableCollection<Preinvoice> Preinvoices { get; set; }
        
        public GenerationPreinvoiceView()
        {
            InitializeComponent();
            this.DataContext = new GenerationPreinvoiceVM();

            Preinvoices = new ObservableCollection<Preinvoice>
            {
                new Preinvoice { Id = 1, RentalContractId = 201, ChargeDate = new DateTime(2023, 8, 15), AssetsAmount = 4, Total = 1200.50m },
                new Preinvoice { Id = 2, RentalContractId = 202, ChargeDate = new DateTime(2023, 8, 22), AssetsAmount = 6, Total = 1800.75m },
                new Preinvoice { Id = 3, RentalContractId = 203, ChargeDate = new DateTime(2023, 9, 10), AssetsAmount = 3, Total = 900.00m },
                new Preinvoice { Id = 4, RentalContractId = 204, ChargeDate = new DateTime(2023, 9, 18), AssetsAmount = 7, Total = 2100.25m },
                new Preinvoice { Id = 5, RentalContractId = 205, ChargeDate = new DateTime(2023, 9, 25), AssetsAmount = 5, Total = 1500.30m }
            };
            PreinvoicesDataGrid.ItemsSource = Preinvoices;
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //Todo: Implement search logic
        }

        private void CrearPrefacturasButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: crear prefacturas

            var mainViewModel = (Application.Current.MainWindow as MainWindow).DataContext as MainViewModel;

            // Ejecuta el comando para cambiar la vista
            if (mainViewModel.ShowRentalContractViewCommand.CanExecute(null))
            {
                mainViewModel.ShowRentalContractViewCommand.Execute(null);
            }

        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            var mainViewModel = (Application.Current.MainWindow as MainWindow).DataContext as MainViewModel;

            // Ejecuta el comando para cambiar la vista
            if (mainViewModel.ShowRentalContractViewCommand.CanExecute(null))
            {
                mainViewModel.ShowRentalContractViewCommand.Execute(null);
            }
        }
    }
}
