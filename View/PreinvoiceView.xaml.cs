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
    /// Lógica de interacción para PreinvoiceView.xaml
    /// </summary>
    public partial class PreinvoiceView : UserControl
    {
        public ObservableCollection<Preinvoice> Preinvoices { get; set; }
        public PreinvoiceView()
        {
            InitializeComponent();

            Preinvoices = new ObservableCollection<Preinvoice>
            {
                new Preinvoice { Id = 1, RentalContractId = 101, ChargeDate = new DateTime(2023, 9, 15), AssetsAmount = 5, Total = 1000.50m },
                new Preinvoice { Id = 2, RentalContractId = 102, ChargeDate = new DateTime(2023, 9, 20), AssetsAmount = 3, Total = 750.25m },
                new Preinvoice { Id = 3, RentalContractId = 103, ChargeDate = new DateTime(2023, 9, 25), AssetsAmount = 10, Total = 2000.00m },
                new Preinvoice { Id = 4, RentalContractId = 104, ChargeDate = new DateTime(2023, 9, 30), AssetsAmount = 2, Total = 500.75m },
                new Preinvoice { Id = 5, RentalContractId = 105, ChargeDate = new DateTime(2023, 9, 10), AssetsAmount = 8, Total = 1600.80m }
            };

            DataContext = this;
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            this.Opacity = 0.3;
            FilterAsset window = new FilterAsset();
            window.ShowDialog();

            this.Opacity = 1;
        }

        private void NewPreinvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            var mainViewModel = (Application.Current.MainWindow as MainWindow).DataContext as MainViewModel;


            if (mainViewModel.ShowCreateEditPreinvoiceViewCommand.CanExecute(null))
            {
                mainViewModel.ShowCreateEditPreinvoiceViewCommand.Execute(null);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var mainViewModel = (Application.Current.MainWindow as MainWindow).DataContext as MainViewModel;


            if (mainViewModel.ShowCreateEditPreinvoiceViewCommand.CanExecute(null))
            {
                mainViewModel.ShowCreateEditPreinvoiceViewCommand.Execute(null);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Implement delete logic
        }
    }
}
