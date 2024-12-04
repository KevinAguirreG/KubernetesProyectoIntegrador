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
    /// Lógica de interacción para CreateEditTypeAssetView.xaml
    /// </summary>
    public partial class CreateEditTypeAssetView : UserControl
    {

        public CreateEditTypeAssetView()
        {
            InitializeComponent();

            

            CreateEditTypeAssetVM vm = new CreateEditTypeAssetVM();
            //DataContext = vm;
            //Trace.WriteLine(vm.AssetTypeRecord.Name);

            Trace.WriteLine("entro la vista");
            List<ArticleAsset> articleAssets = vm.getArticles2();
            articuloAtivoCombo.ItemsSource = articleAssets;

            //Determinar si es una creación nueva o un edit

        }

        private void AgregarAtributoButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Add attribute
            this.Opacity = 0.3;

            AddAtributteWindow addAtributteWindow = new AddAtributteWindow();
            addAtributteWindow.ShowDialog();

            this.Opacity = 1;
        }

        private void SaveAndCloseButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Save


            var mainViewModel = (Application.Current.MainWindow as MainWindow).DataContext as MainViewModel;


            if (mainViewModel.ShowAssetTypeViewCommand.CanExecute(null))
            {
                mainViewModel.ShowAssetTypeViewCommand.Execute(null);
            }
        }

        private void SaveAndNewButton_Click(object sender, RoutedEventArgs e)
        {
            

        }
    }
}
