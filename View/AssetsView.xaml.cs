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
    /// Lógica de interacción para AssetsView.xaml
    /// </summary>
    public partial class AssetsView : UserControl
    {
        public ObservableCollection<Asset> Assets { get; set; }
        public AssetsView()
        {
            InitializeComponent();

            Assets = new ObservableCollection<Asset>
            {
                new Asset { Id = 1, Name = "Laptop", Description = "Laptop Dell XPS", AssetType = new AssetType { Name = "Electrónico" }, Brand = "Dell" },
                new Asset { Id = 2, Name = "Proyector", Description = "Proyector Epson", AssetType = new AssetType { Name = "Electrónico" }, Brand = "Epson" },
                new Asset { Id = 3, Name = "Silla de oficina", Description = "Silla ergonómica", AssetType = new AssetType { Name = "Mobiliario" }, Brand = "ErgoChair" },
                new Asset { Id = 4, Name = "Servidor", Description = "Servidor HP ProLiant", AssetType = new AssetType { Name = "Electrónico" }, Brand = "HP" }
            };

            // Asignar los datos de prueba al DataContext
            this.DataContext = this;
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            this.Opacity = 0.3;
            FilterAsset window = new FilterAsset();
            window.ShowDialog();

            this.Opacity = 1;
        }

        private void NewAssetButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtén la referencia al MainViewModel
            var mainViewModel = (Application.Current.MainWindow as MainWindow).DataContext as MainViewModel;

            // Ejecuta el comando para cambiar la vista
            if (mainViewModel.ShowCreateEditAssetViewCommand.CanExecute(null))
            {
                mainViewModel.ShowCreateEditAssetViewCommand.Execute(null);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtén la referencia al MainViewModel
            var mainViewModel = (Application.Current.MainWindow as MainWindow).DataContext as MainViewModel;

            // Ejecuta el comando para cambiar la vista
            if (mainViewModel.ShowCreateEditAssetViewCommand.CanExecute(null))
            {
                mainViewModel.ShowCreateEditAssetViewCommand.Execute(null);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Implementar la lógica para eliminar un activo
        }
    }
}
