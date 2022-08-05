using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotifyPropertyChanged_V80
{
    public class JuntaNombre: INotifyPropertyChanged
    {
        private string nombre, apellido, nombrecompleto;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        //Creacion de propiedades
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value;
                OnPropertyChanged(NombreCompleto);
            }
            
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value;
                OnPropertyChanged(NombreCompleto);
            }
        }
        public string NombreCompleto
        {
            get {
                string NombreCompleto = Nombre + " " + Apellido; 
                return NombreCompleto; }
            set { nombrecompleto = value;
               
            }
        }
    }
}
