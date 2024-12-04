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
    /// Lógica de interacción para CreateEditRentalContractView.xaml
    /// </summary>
    public partial class CreateEditRentalContractView : UserControl
    {
        public CreateEditRentalContractView()
        {
            InitializeComponent();
        }

        private void SaveAndNewButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Implementar funcionalidad de guardar y nuevo
        }

        private void SaveAndCloseButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Implementar funcionalidad de guardar

            var mainViewModel = (Application.Current.MainWindow as MainWindow).DataContext as MainViewModel;

            if (mainViewModel.ShowRentalContractViewCommand.CanExecute(null))
            {
                mainViewModel.ShowRentalContractViewCommand.Execute(null);
            }
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Implementar funcionalidad de copiar
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Implementar funcionalidad de cancelar
        }

        private void CopyAndCancelButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Implementar funcionalidad de copiar y cancelar
        }

        private void AgregarAtributoButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Implementar funcionalidad de agregar atributo
        }

        private void GenerarFechasButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Implementar funcionalidad de generar fechas
        }
    }

}
