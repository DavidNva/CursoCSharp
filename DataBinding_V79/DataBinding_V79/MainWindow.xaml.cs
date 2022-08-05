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

namespace DataBinding_V79
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Data binding es hacer un puente entre una fuente y un objetivo destino
        //por ejemlpo, un control con una base de datos, una tabla con un base de datos, con otro control, con un objeto, etc. 
        //Source = fuente;
        //Target = Objetivo
        //Se debe usar path = value, y para el elementName= nombreDelElemento para hacer un binding
        //hay 4 formas de hacer binding:
        //Imaginemos que tenemos como en este proyecto:
        //un slider(va a ser la fuente(source)) y
        //tenemos un texbox (va a ser el target(objetivo))
        /*
         * Por default es un one way
         * One way : Va desde el source al target
           Ejemplo : Va desde el slider al textbox
         * One way to source: Va desde  el target al source, desde el objetivo a la fuente
                     Ejemplo: Va desde el textBox al slider
         * Two way, va desde las dos fuentes digamos
         * One time: Funciona como el oneway, desde la fuente al destino, pero solo una vez
           Ejemplo : Va desde el slider al textbox SOLO UNA VEZ
         El binding se hace en el textBox que va a reglejar los datos
         */
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
