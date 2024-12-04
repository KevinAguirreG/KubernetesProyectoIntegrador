using Microsip_Rentas.Model;
using Microsip_Rentas.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    /// Lógica de interacción para AssetTypesView.xaml
    /// </summary>
    public partial class AssetTypesView : UserControl
    {
        public AssetTypesView()
        {
            InitializeComponent();

            // Asignar el datacontext 
            AssetTypesVM vm = new AssetTypesVM();
            DataContext = vm;
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            this.Opacity = 0.3;
            FilterAsset window = new FilterAsset();
            window.ShowDialog();

            this.Opacity = 1;
        }

        private void NewTypeAsset_Click(object sender, RoutedEventArgs e)
        {
            var mainViewModel = (Application.Current.MainWindow as MainWindow).DataContext as MainViewModel;


            if (mainViewModel.ShowCreateEditTypeAssetViewCommand.CanExecute(null))
            {
                mainViewModel.ShowCreateEditTypeAssetViewCommand.Execute(null);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var mainViewModel = (Application.Current.MainWindow as MainWindow).DataContext as MainViewModel;
            var button = sender as Button;
            var assetId = button?.CommandParameter as int?;

            if (mainViewModel.ShowCreateEditTypeAssetViewCommand.CanExecute(assetId))
            {
                mainViewModel.ShowCreateEditTypeAssetViewCommand.Execute(assetId);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Implementar la eliminación de un tipo de activo
        }
    }
}
