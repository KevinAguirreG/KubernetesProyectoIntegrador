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
    /// Lógica de interacción para RentalContractView.xaml
    /// </summary>
    public partial class RentalContractView : UserControl
    {
        public ObservableCollection<RentalContract> RentalContracts { get; set; }

        public RentalContractView()
        {
            InitializeComponent();

            RentalContracts = new ObservableCollection<RentalContract>
            {
                new RentalContract { Id = 1, CustomerId = 101, RentalDate = new DateTime(2023, 9, 1), DueDate = new DateTime(2023, 9, 10), ReturnDate = new DateTime(2023, 9, 9), RentalStatusId = 1, NumberRentalPeriod = 10, RentalPeriodId = 1 },
                new RentalContract { Id = 2, CustomerId = 102, RentalDate = new DateTime(2023, 8, 20), DueDate = new DateTime(2023, 8, 30), ReturnDate = new DateTime(2023, 8, 29), RentalStatusId = 2, NumberRentalPeriod = 10, RentalPeriodId = 1 },
                new RentalContract { Id = 3, CustomerId = 103, RentalDate = new DateTime(2023, 7, 15), DueDate = new DateTime(2023, 7, 25), ReturnDate = new DateTime(2023, 7, 24), RentalStatusId = 1, NumberRentalPeriod = 10, RentalPeriodId = 1 },
                new RentalContract { Id = 4, CustomerId = 104, RentalDate = new DateTime(2023, 9, 5), DueDate = new DateTime(2023, 9, 15), ReturnDate = new DateTime(2023, 9, 14), RentalStatusId = 3, NumberRentalPeriod = 10, RentalPeriodId = 1 },
                new RentalContract { Id = 5, CustomerId = 105, RentalDate = new DateTime(2023, 9, 10), DueDate = new DateTime(2023, 9, 20), ReturnDate = new DateTime(2023, 9, 19), RentalStatusId = 1, NumberRentalPeriod = 10, RentalPeriodId = 1 }
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

        private void GenerationPreinvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtén la referencia al MainViewModel
            var mainViewModel = (Application.Current.MainWindow as MainWindow).DataContext as MainViewModel;

            // Ejecuta el comando para cambiar la vista
            if (mainViewModel.ShowGenerationPreinvoiceViewCommand.CanExecute(null))
            {
                mainViewModel.ShowGenerationPreinvoiceViewCommand.Execute(null);
            }
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtén la referencia al MainViewModel
            var mainViewModel = (Application.Current.MainWindow as MainWindow).DataContext as MainViewModel;

            // Ejecuta el comando para cambiar la vista
            if (mainViewModel.ShowCreateEditRentalContractViewCommand.CanExecute(null))
            {
                mainViewModel.ShowCreateEditRentalContractViewCommand.Execute(null);
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Implementar la lógica para eliminar un contrato de renta
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtén la referencia al MainViewModel
            var mainViewModel = (Application.Current.MainWindow as MainWindow).DataContext as MainViewModel;

            // Ejecuta el comando para cambiar la vista
            if (mainViewModel.ShowCreateEditRentalContractViewCommand.CanExecute(null))
            {
                mainViewModel.ShowCreateEditRentalContractViewCommand.Execute(null);
            }
        }
    }
}
