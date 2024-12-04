using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Microsip_Rentas.View
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isMenuVisible = true;

        private ToggleButton ExpanderActivoButton;
        private ToggleButton ExpanderRentaButton;
        private ToggleButton ExpanderDocumentoButton;

        public MainWindow()
        {
            InitializeComponent();
            DateTextBlock.Text = DateTime.Now.ToString("dd MMMM yyyy", new CultureInfo("es-ES"));

            ExpanderActivoButton = FindName("ExpanderActivo") as ToggleButton;
            ExpanderRentaButton = FindName("ExpanderRenta") as ToggleButton;
            ExpanderDocumentoButton = FindName("ExpanderDocumento") as ToggleButton;
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void hamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            if (isMenuVisible)
            {
                HideMenu();
            }
            else
            {
                ShowMenu();
            }
        }

        private void HideMenu()
        {
            var animation = Resources["HideMenuAnimation"] as Storyboard;
            animation.Completed += (sender, args) => { isMenuVisible = false; };
            animation.Begin(MenuLateral);

            //cerrar expanders
            ExpanderActivoButton.IsChecked = false;
            ExpanderContentActivo.Visibility = Visibility.Collapsed;

            ExpanderRentaButton.IsChecked = false;
            ExpanderContentRenta.Visibility = Visibility.Collapsed;

            ExpanderDocumentoButton.IsChecked = false;
            ExpanderContentDocumento.Visibility = Visibility.Collapsed;
        }

        private void ShowMenu()
        {
            var animation = Resources["ShowMenuAnimation"] as Storyboard;
            animation.Completed += (sender, args) => { isMenuVisible = true; };
            animation.Begin(MenuLateral);

        }

        private void ExpanderActivoButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleExpander((ToggleButton)sender, ExpanderContentActivo);
        }

        private void ExpanderRentaButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleExpander((ToggleButton)sender, ExpanderContentRenta);
        }

        private void ExpanderDocumentoButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleExpander((ToggleButton)sender, ExpanderContentDocumento);
        }

        private void ToggleExpander(ToggleButton button, UIElement content)
        {
            CloseAllExpanders(button);

            if (!isMenuVisible)
                ShowMenu();

            content.Visibility = button.IsChecked ?? false ? Visibility.Visible : Visibility.Collapsed;
        }

        private void CloseAllExpanders(ToggleButton currentButton)
        {
            foreach (var button in new[] { ExpanderActivoButton, ExpanderRentaButton, ExpanderDocumentoButton })
            {
                if (button != currentButton && button.IsChecked.HasValue && button.IsChecked.Value)
                {
                    button.IsChecked = false;

                    switch (button.Name)
                    {
                        case "ExpanderActivo":
                            ExpanderContentActivo.Visibility = Visibility.Collapsed;
                            break;
                        case "ExpanderRenta":
                            ExpanderContentRenta.Visibility = Visibility.Collapsed;
                            break;
                        case "ExpanderDocumento":
                            ExpanderContentDocumento.Visibility = Visibility.Collapsed;
                            break;
                    }
                }
            }
        }
    }
}
