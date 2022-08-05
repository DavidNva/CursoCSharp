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

namespace ListBox_V81
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Poblaciones> listPob = new List<Poblaciones>();

            listPob.Add(new Poblaciones() { Poblacion1 = "México",Temperatura1=17,Poblacion2="Puebla",Temperatura2=15, DiferenciaTemp = 2});
            listPob.Add(new Poblaciones() { Poblacion1 = "Zacatlán", Temperatura1 = 13, Poblacion2 = "Buenos Aires", Temperatura2 = 21, DiferenciaTemp = 8 });
            listPob.Add(new Poblaciones() { Poblacion1 = "Ahuacatlán", Temperatura1 = 20, Poblacion2 = "Huauchinango", Temperatura2 = 25, DiferenciaTemp = 5 });
            listPob.Add(new Poblaciones() { Poblacion1 = "Veracruz", Temperatura1 = 25, Poblacion2 = "Tlaxcala", Temperatura2 = 11, DiferenciaTemp = 14 });
            listaPoblaciones.ItemsSource = listPob;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show(
                (listaPoblaciones.SelectedItem as Poblaciones).Poblacion1 + " " +
                (listaPoblaciones.SelectedItem as Poblaciones).Temperatura1 + " ºC, " +
                (listaPoblaciones.SelectedItem as Poblaciones).Poblacion2 + " " +
                (listaPoblaciones.SelectedItem as Poblaciones).Temperatura2 + " ºC " + 
                "\nDiferencia de Temperatura = " + (listaPoblaciones.SelectedItem as Poblaciones).DiferenciaTemp);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Selecciona primero un elemento","Error");
            }
            //  Otra forma de hacerlo seria con un condicional
            /*
            if(listaPoblaciones.SelectedItem != null) {//Aqui iria lo que colocamos en l primera MessegeBox
            }
            else { //Aqui iria lo que colocamos en el segundo MessegeBox
            }
            */
            
        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (listaPoblaciones.SelectedItem != null)
            {
                MessageBox.Show(
                (listaPoblaciones.SelectedItem as Poblaciones).Poblacion1 + " " +
                (listaPoblaciones.SelectedItem as Poblaciones).Temperatura1 + " ºC, " +
                (listaPoblaciones.SelectedItem as Poblaciones).Poblacion2 + " " +
                (listaPoblaciones.SelectedItem as Poblaciones).Temperatura2 + " ºC " +
                "\nDiferencia de Temperatura = " + (listaPoblaciones.SelectedItem as Poblaciones).DiferenciaTemp);
            }
        }
    }
    public class Poblaciones
    {
        //Las temperaturas se compararan entre ciudades
        public string Poblacion1 { get; set; }
        public int Temperatura1 { get; set; }
        public string Poblacion2 { get; set; }
        public int Temperatura2 { get; set; }
        public int DiferenciaTemp { get; set; }
    }
}
