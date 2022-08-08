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
    //Un ORM es un modelo de programación que permite mapear las estructuras de una base de datos relacional (SQL Server, Oracle, MySQL, etc.)
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
            //InsertaLibro();
            //insertarAutor();
            //InsertaAutorLibro();
            //Principal.ItemsSource = dataContext.Usuario;
            //UpdateAutor();
            DeleteAutor();
        }
       
        //TODO
        //Trabajar en esta area con los demas metodos para CRUD
        public void InsertaLibro()
        {
            //Podemos ingresar por cada valor con el metodo InsertOnSubmite
            //Podemos instanciar directmente desde el propio metodo y agregar o
            //Pues realizar primero la instnacia y despues agregarlo e insertarlo con el metodo

            //POdemos ingresar por medio de listas, y con el metodo InserAllOnSubmit (como libro no tiene trigger de autogenerar codigo, si no que como administrador se lo agregamos
            //por eso podemos realizar una insercion multiple

            List<Libro> listaLibros = new List<Libro>();
            listaLibros.Add(new Libro { IDLibro = "L06", Titulo = "EL PRINCIPITO", Ubicacion = "200-299", NumEdicion = "SEGUNDA EDICION",AñoEdicion = "2002",Volumen = 2, NumPaginas = 71,Observaciones = "EN PERFECTO ESTADO",ID_Sala = "S0002",ID_Categoria = "C0003",ID_Editorial = "ED0002" });
            listaLibros.Add(new Libro { IDLibro = "L07", Titulo = "HARRY POTTER Y LA PIEDRA FILOSOFAL", Ubicacion = "300-299", NumEdicion = "PRIMERA EDICION", AñoEdicion = "2004", Volumen = 1, NumPaginas = 325, Observaciones = "EN PERFECTO ESTADO", ID_Sala = "S0001", ID_Categoria = "C0002", ID_Editorial = "ED0001" });
            listaLibros.Add(new Libro { IDLibro = "L08", Titulo = "HARRY POTTER Y LAS RELIQUIAS DE LA MUERTE I", Ubicacion = "300-299", NumEdicion = "SEGUNDA EDICION", AñoEdicion = "2007", Volumen = 4, NumPaginas = 402, Observaciones = "EN BUEN ESTADO", ID_Sala = "S0001", ID_Categoria = "C0002", ID_Editorial = "ED0001" });
            dataContext.Libro.InsertAllOnSubmit(listaLibros);
            dataContext.SubmitChanges();
            Principal.ItemsSource = dataContext.Libro;
        }
        public void InsertaAutorLibro()
        {
            //Tambie podemos hacer esto en las tablas de relacion con foreign key
            //Almacenar en una variable de tipo libro //Si recordamos cuando las agregamos a la lista, solo las inicializamos directamente, sin colocarle un nombre, por eso ahora que las vamos a ocupar, indicamos un nombre de instancia)
            //Por ejemplo, para el principito (para poder almacenar alli esos datos, de ese registro)
            //First para indicar que el primer libro que se encuentre con el nombre "EL PRINCIPITO"
            //Lo guarde en esta variable tipo objeto, tipo libro
            //Se usa una expresion lamba (como si fuera un metodo)
            //Usando la variable lib, podemos usar los campos de la tabla libro, para realizar la comparacion con Equals
            Libro Principito = dataContext.Libro.First(lib => lib.Titulo.Equals("EL PRINCIPITO"));
            Libro HarryPotterI = dataContext.Libro.First(lib => lib.Titulo.Equals("HARRY POTTER Y LA PIEDRA FILOSOFAL"));

            Autor alberto = dataContext.Autor.First(aut => aut.Nombre.Equals("ALBERTO"));
            Autor daniel = dataContext.Autor.First(aut => aut.Nombre.Equals("DANIEL"));

            LibroAutor libroAutor = new LibroAutor();
            libroAutor.Libro = Principito;//Podemos acceder a libro desde libroautor, porque existe una relacion entre estos
            //Al igual que podemos acceder a Autor desde esta tabla por lo mismo de la relacion
            //En este caso al igualarlo con la instancia principito, esta tomando los valores de dicha instancia, en particulas si id

            //libroAutor.ID_Libro = Principito.IDLibro;//Para no confundirnos, lo anterior es como si hubieramos hecho esto
            libroAutor.ID_Autor = alberto.IDAutor;//El id de relacion con autor, sera el valor de idautor de la instancia alberto
            dataContext.SubmitChanges();//Subimos los cambios
            Principal.ItemsSource = dataContext.LibroAutor;



        }


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
        public void insertarAutor()
        {
            dataContext.Autor.InsertOnSubmit(new Autor { Nombre = "DAVID", Apellidos = "NAVA" });
            dataContext.SubmitChanges();
            Principal.ItemsSource = dataContext.Autor;
        }
        //-----------------Metodos de actualizaion y eliminacion ----------------------------------------------
        //Ejemplo de actualizacion de autor
        public void UpdateAutor()
        {//Primero buscamos el valor, en este caso por el nombre (como ejemplo, ya que no se estan repitiendo los nombres, pero claro seria mejor trabajar con los ID)
            Autor David = dataContext.Autor.First(em => em.Nombre.Equals("DAVID"));
            David.Nombre = "DEIV";//Asi de simple se actualiza
            dataContext.SubmitChanges();//Sube los cambios
            Principal.ItemsSource = dataContext.Autor;//Muestra en la interfaz
        }
        //Ejemplo para eliminar un Autor (En teoria esta opcion no deberia existir porque no tiene sentido eliminar un autor, ademas de que si esta relacionada
        //con la tabla libroautor, no se podrá eliminar ese registro
        //pero supongamos que el registro no tiene ninguna relacion, como el autor que actualizamos anteriormente. Pues en ese caso podria eliminarse
        //teniendo en cuenta que esta opcion solo seria para un administrador, informandole que para eliminar a un autor, este no debe estar relacionado con 
        //ninguna de ls tablas, en este caso con libroautor (especificamente hablando de dicho registro)
        public void DeleteAutor()
        {
            //Esto es como cuando haciamos inserciones, en este caso se usa el metodo deleteOnSubmit
            //Para buscar podemos escribirlo en mayuscula o minuscula, mientras este bien escrito lo va a encontrar
            //aunque seria mas recomendable que si usamos mayusculas, pues lo describamos asi, o viceversa, escribirlo tal cual: DEIV
            //en esta prueba, mezclamos mayusculas y minuscula, y aun asi encontro el registro y lo eliminó
            Autor David = dataContext.Autor.First(em => em.Nombre.Equals("Deiv"));//Busca el valor a eliminar
            dataContext.Autor.DeleteOnSubmit(David);//Lo elimina
            dataContext.SubmitChanges();//Sube los cambios
            Principal.ItemsSource = dataContext.Autor;//Muestra en la interfaz
        }
    }
}
