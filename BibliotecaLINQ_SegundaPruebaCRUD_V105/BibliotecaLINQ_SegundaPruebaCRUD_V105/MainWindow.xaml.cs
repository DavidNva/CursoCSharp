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
using System.Configuration;

namespace BibliotecaLINQ_SegundaPruebaCRUD_V105
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        DataLinqToSqlBibliotecaDataContext dataContext;
        public MainWindow()
        {
            InitializeComponent();
            string miConexion = ConfigurationManager.ConnectionStrings["BibliotecaLINQ_SegundaPruebaCRUD_V105.Properties.Settings.BibliotecaAppConnectionString"].ConnectionString;
            dataContext = new DataLinqToSqlBibliotecaDataContext(miConexion);
            //InsertarSala();
            //InsertarUsuario();
            Principal.ItemsSource = dataContext.Usuario;
        }

        //TODO
        //Trabajar en esta area con los demas metodos para CRUD








        public void InsertarSala()
        {
            Sala adolescentes = new Sala();
            adolescentes.Sala1 = "ADOLESCENTES2";
            dataContext.Sala.InsertOnSubmit(adolescentes);
            
            dataContext.SubmitChanges(); //Actualiza los cambios, como una confirmacion de realizar la insercion
            Principal.ItemsSource = dataContext.Sala;
        }
        public void InsertarUsuario()
        {
            //Con las cuatro inserciones en este metodo confirmamos el ultimo comentario anterior
            //Es que para las tablas tipo identity si se pueden realizar inserciones multiples
            //Pero...
            List<Usuario> listaUsuario = new List<Usuario>();
            listaUsuario.Add(new Usuario
            {
                Nombre = "MAGDALENA",
                A_Paterno = "GARCIAA",
                A_Materno = "GARCIA",
                Calle = "JOSE CLEMENTE OROZCO",
                Edad = 73,
                Ciudad = "CHIGNAHUAPAN",
                Telefono = "98127364510",/* Observaciones = "NINGUNA", */
                ID_TipoPersona = 1
            });
           
            TipoPersona Lector = dataContext.TipoPersona.First(em => em.Descripcion.Equals("Lector"));
            TipoPersona Empleado = dataContext.TipoPersona.First(em => em.Descripcion.Equals("Empleado"));
            TipoPersona Administrador = dataContext.TipoPersona.First(em => em.Descripcion.Equals("Administrador"));//Solo tenemos tres tipos para biblioteca
            listaUsuario.Add(new Usuario
            {
                //IDUsuario  = Es identity
                Nombre = "MARIA MAGDALENA",
                A_Paterno = "GARCIAA",
                A_Materno = "GARCIA",
                Calle = "JOSE CLEMENTE OROZCO",//Calle es despues de ciuadad, pero lo colocamos antes para compruebar que
                Edad = 73,
                //EscuelaProcedencia puede ser null
                Ciudad = "ZACATLÁN",//Por defecto es ZACATLÁN
                Telefono = "98127364510",
                //Email puede ser null
                //Observaciones = por defecto es NINGUNA
                Observaciones = "ENTREGA TARDE",
                //IDPersona = por defecto es 1
                ID_TipoPersona = 1
                //FechaCreacion = por defecto es GetDate();
            });
            listaUsuario.Add(new Usuario
            {
                //IDUsuario  = Es identity
                Nombre = "OSCAR",
                A_Paterno = "MARCOS",
                A_Materno = "BACILIO",
                Calle = "JOSE CLEMENTE OROZCO",//Calle es despues de ciuadad, pero lo colocamos antes para compruebar que
                Edad = 20,
                //EscuelaProcedencia puede ser null
                Ciudad = "ZACATLÁN",//Por defecto es ZACATLÁN
                Telefono = "0921878743",
                //Email puede ser null
                //Observaciones = por defecto es NINGUNA, pero solo aplica en SQL
                //Observaciones = "ENTREGA TARDE", 
                //IDPersona = por defecto es 1
                ID_TipoPersona = Lector.IdTipoPersona //D esta forma estamos usando el objeto creado anteriormente para que visualmente en el codigo sepamos
                //a que tipo de persona indicamos para el usuario, con el id
                
            });
            listaUsuario.Add(new Usuario
            {
                //IDUsuario  = Es identity
                Nombre = "PEDRO",
                A_Paterno = "BOLAÑOS",
                A_Materno = "JIMENEZ",
                Calle = "01 DEM MAYO",//Calle es despues de ciuadad, pero lo colocamos antes para compruebar que
                Edad = 31,
                //EscuelaProcedencia puede ser null
                Ciudad = "BUENOS AIRES",//Por defecto es ZACATLÁN
                Telefono = "212112348",
                //Email puede ser null
                //Observaciones = por defecto es NINGUNA
                Observaciones = "ENTREGÓ UN LIBRO MALTRATADO",
                //IDPersona = por defecto es 1
                ID_TipoPersona = Empleado.IdTipoPersona
                //FechaCreacion = por defecto es GetDate();
            });
            dataContext.Usuario.InsertAllOnSubmit(listaUsuario);//Permite insertar varios valores a la vez, ya que insertamos todo lo que haya en la lista creada
            dataContext.SubmitChanges();//Actualiza los cambios, como una confirmacion de realizar la insercion
            Principal.ItemsSource = dataContext.Usuario; //Muestra en la aplicacion, para el grid, los datos de usuarios
        }

    }
}
