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

namespace ComboBoxYCheckBox_V84
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Capital> listaCap = new List<Capital>();
            listaCap.Add(new Capital() { NombreCapital = "Puebla de Zaragoza" });
            listaCap.Add(new Capital() { NombreCapital = "Mexicali" });
            listaCap.Add(new Capital() { NombreCapital = "Guadalajara" });
            listaCap.Add(new Capital() { NombreCapital = "Monterrey" });
            listaCap.Add(new Capital() { NombreCapital = "Hermosillo" });

            Capitales.ItemsSource = listaCap;
        }

        private void TodasC_Checked(object sender, RoutedEventArgs e)
        {
            Puebla.IsChecked = true;
            Mexicali.IsChecked = true;
            Guadalajara.IsChecked = true;
            Monterrey.IsChecked = true;
            Hermosillo.IsChecked = true;

        }

        private void TodasC_Unchecked(object sender, RoutedEventArgs e)
        {
            Puebla.IsChecked = false;
            Mexicali.IsChecked = false;
            Guadalajara.IsChecked = false;
            Monterrey.IsChecked = false;
            Hermosillo.IsChecked = false;
        }
        private void IndividualChecked(object sender, RoutedEventArgs e)
        {
            if (Puebla.IsChecked == true && Mexicali.IsChecked == true && Guadalajara.IsChecked == true && Monterrey.IsChecked == true && Hermosillo.IsChecked == true)
            {
                TodasC.IsChecked = true;
            }
            else
            {
                TodasC.IsChecked = null;
            }
        }
        private void Individual_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Puebla.IsChecked == false && Mexicali.IsChecked == false && Guadalajara.IsChecked == false && Monterrey.IsChecked == false && Hermosillo.IsChecked == false)
            {
                TodasC.IsChecked = false;
            }
            else
            {
                TodasC.IsChecked = null;
            }
        }
        public class Capital
        {
            public string NombreCapital { get; set; }
        }
    }
}
