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

namespace InterfazGrafica_V74
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("¡Le has dado al segundo boton!","Felicidades");
            //El primer parametro imprime el mensaje, el segundo da titulo a la ventana emergente
            Console.WriteLine("Felicidades le has dado al boton 2!");
        }
        /*
        private void Panel_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Le has dado al Panel");//Esto evento seria de tipo burbuja
            //Los eventos burbuja (bubbling) se efectuan hacia arriba
            //En este caso, la estructura es Window-Stack-Button-TextBlock
            //Por lo que al ser de tipo burbuja, al hacer clic en boton2, primero se ejecutra el evento de ese boton
            //y segundo seria el panel 
        }*/

        //Ahora el siguiente metodo es de tipo tunneling (los eventos se efectua hacia abajo)
        //Estos eventos se reconocen por la palabra preview
        private void Panel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Le has dado al panel (Tipo tunneling)");//Ahora como es tipo tunneling, primero se 
            //ejecutará el evento del panel y despues se ejecutra el evento del boton(lo contrario a bubbling)
        }
    }
}
