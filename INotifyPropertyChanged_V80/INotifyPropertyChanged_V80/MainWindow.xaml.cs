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

namespace INotifyPropertyChanged_V80
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
         * Las INotefyPropertyChanged son una forma de notificar que una propiedad ha cambiado
         *sin necesidad de crear un evento para cada uno
         *Porque como tal, vamos a implementar una interfaz, lo cual nos hara crar un metodo de tipo evento
         *ese metodo es el que servira pra notificar o desencadenar al go (como un evento) para cada propiedad que tengamos
         *Es muy util cuando tenemos muchas propieades que constanemente estan cmbiando, entonces, en lugar de usar un evento, podemos
         *implementar estas notifyproperty
         *En este ejemplo, se muestra que cuando cambia la propiedad nombre y apellid(que creamos) esto se refleja en el tercer cuadro de texto
         cambiando tmabien su texto (lo de nombre completo) de esta forma, sin la necesidad de un evento, estamos notificando al tercer cuadr de texto que
         los dos valores con los que tienen un data binding han cambiado, por lo tanto el tambien deve cambiar su valor
        
         de hecho los que implementan el metodo son las propias propiedades, y por parametro se pasa la propiedad a la cual se le notificara
        o a la cual desencadenara algo
        en este caso los evento se aplican para la propiedad nombre y apellido, donde por parametro del eveno se le indica la propiedad: "NombreCompleto"
        que es a la cual se notificara y el hara un cambia en su texto tambien, porque le estamos igualando con la concatenacion de los dos anteriores
         */
        
        public MainWindow()
        {
            InitializeComponent();
            JuntaNombre David = new JuntaNombre {Nombre = "David", Apellido="Nava" };
            this.DataContext = David;
    }
    }
}
