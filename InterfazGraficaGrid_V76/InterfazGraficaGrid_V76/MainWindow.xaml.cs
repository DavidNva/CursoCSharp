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

namespace InterfazGraficaGrid_V76
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*
             *** Hay tres formas de acomodar un grid: sus columnas y sus filas: ***
             * Por medio de pixeles: 
                A las columnas se les piede dar un ancho Width="125", a las filas se les puede dar un alto Height = "25" 
             * De forma automatica: por medio de la palabra: auto: Esto hará que el ancho  o alto (lo que se especifique)
                de la columan y fila, se adaptaran a lo que tenga dentro, por ejemplo si tiene un boton, se adaptara a ese boton
             * La tercera forma es de manera proporcional usando un *
               Esto para que proporcione el numero de columnas o filas (lo que se especifique) de manera proporcional al tamaño del grid total, o de la ventana
              
             * 
            */
        }
    }
}
