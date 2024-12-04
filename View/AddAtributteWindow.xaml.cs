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
using System.Windows.Shapes;

namespace Microsip_Rentas.View
{
    /// <summary>
    /// Lógica de interacción para AddAtributteWindow.xaml
    /// </summary>
    public partial class AddAtributteWindow : Window
    {
        public AddAtributteWindow()
        {
            InitializeComponent();
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AceptarButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: mandar parametros a typeassetView
            this.Close();
        }
    }
}
