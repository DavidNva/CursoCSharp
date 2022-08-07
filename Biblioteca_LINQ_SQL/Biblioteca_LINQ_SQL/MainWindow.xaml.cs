using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows;

namespace Biblioteca_LINQ_SQL
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
            //NombreProyecto C#             //nOM
            string miConexion = ConfigurationManager.ConnectionStrings["Biblioteca_LINQ_SQL.Properties.Settings.BibliotecaLinqSql"].ConnectionString;
            dataContext = new DataLinqToSqlBibliotecaDataContext(miConexion);
            //InsertarSala();
            //NOTA IMPORTANTE
            //Tener cuidado al volver a ejecutar este proyecto
            //Debemos cambiar las inserciones que estamos hacindo, porque si no dara un error de idx, que no permitirá repetir nombres de usuarios
            //como es identity no genera error de ID, pero como en el scrip indicamos un indice unico, alli si daria error
            
            //dataContext.ExecuteCommand("DELETE FROM Usuario where IDUsuario = 16 OR IDUsuario = 17");//Si esto es solo prueba, checamos la base de datos
            //si podemos eliminar los usuarios con id, de esos mismos nombres, lo hacemos, y si no este proyecto solo queda como
            //documentacion de las primeras pruebas con las inserciones para las tablas del proyecto biblioteca
            
            InsertarUsuario();
            //Principal.ItemsSource = dataContext.Usuario;
        }

        public void InsertarSala()
        {
            //dataContext.ExecuteCommand("DELETE FROM Sala");//Esta consulta no se podria ejecutar porqeue hay una foreign key de sala en la tabla libro
            //dataContext.ExecuteCommand("DELETE FROM Sala where IDSala = 'S0003'");//Esto si se puede porque como prueba creamos la sala adultos, pero como aun
            //ningun libro se relacionó con esta sala, pues podemos eliminarla//Pero en este caso el error seria por otra cosa, jaja
            //dataContext.SubmitChanges();

            Sala adultos = new Sala();
            adultos.Sala1 = "ADULTOS2";
            dataContext.Sala.InsertOnSubmit(adultos);

            /*
            Sala adolescentes = new Sala();
            adolescentes.Sala1 = "ADOLESCENTES";
            dataContext.Sala.InsertOnSubmit(adolescentes);
            */
            dataContext.SubmitChanges(); //Actualiza los cambios, como una confirmacion de realizar la insercion
            Principal.ItemsSource = dataContext.Sala;

            /*
            List<Sala> listaSalas = new List<Sala>();
            listaSalas.Add(new Sala { Sala1 = "ADULTOS" });
            dataContext.SubmitChanges();
            listaSalas.Add(new Sala { Sala1 = "ADOLESCENTES" });
            dataContext.Sala.InsertAllOnSubmit(listaSalas);
            dataContext.SubmitChanges();
            Principal.ItemsSource = dataContext.Sala;
            */

            //Haciendo pruebas nos damos cuenta que al estar usando el trigger (de sql) para generar codigos automaticos
            //solo funcionan por una insercion a la vez, si recordamos no tiene la opcion de each row
            //entonces para no tener conflicto y problemas
            //Debemos hacer inserciones uno a uno
            //Por ejemplo, para los que tengan trigger de autogenerar codigo como sala, editorial, categoria, autor, libroautor, etc
            //no podran hacer mas de una insercion a la vez, esto lo comprobamos en este ejemplo, donde nos da errro de PK si queremos hacerlo
            //ni siquiera usando una lista y el metodo InsertAllOnSubmit nos permite hacer eso
            //Entonces para continuar la aplicacion, debemos recordar que no podemos realizar este tipo de accion multiple
            //O en dado caso seria quital el trigger de estas tablas y colocar un identity pero esto seria modelar y cambiar toda la estrucutra de la Base de Datos

            //Las unicas tablas con las que si podemos hacer esto (inserciones multimples) es con las que tienen codigo identity
            //Las unicas de esta base de datos (Biblioteca) serian las tablas:  usuario y  prestamos
            //Tambien se puede hacer insercion multiple en la tabla Libro, ya que como tal el ID debemos ser ingresado por al administrador
            //En dado caso, alli debemos hacer una validacion con un if quizas, para verificar que el id no exista ya
            //Lo comprobamos en el siguiente metodo
        }
        public void InsertarUsuario()
        {
            //Con las dos inserciones en este metodo confirmamos el ultimo comentario anterior
            //Es que para las tablas tipo identity si se pueden realizar inserciones multiples
            //Pero...
            List<Usuario> listaUsuario = new List<Usuario>();
            listaUsuario.Add(new Usuario { Nombre = "MAGDALENA", A_Paterno = "GARCIAA",A_Materno = "GARCIA", Calle="JOSE CLEMENTE OROZCO",
            Edad = 73,Ciudad = "CHIGNAHUAPAN",Telefono="98127364510",/* Observaciones = "NINGUNA", */ID_TipoPersona = 1});
            //Despues de analizar todo decidimos mejor colocar a observaciones para que acepte null, por eso en esta primera insercion no la colocamos
            //En la segunda si indicamos que el usuario a cometido algun error o tiene una observacion como tal, aunque podemos colocar ninguna tambien
            //la idea se explica mejor al final de este metodo

            //Tambien cuando la tabla tenga una foreign key, podemos hacer una instancia de la tabla a referenciar
            //y cuando necesitemos si id, pues referenciamos con dicha instancia. Por ejemplo, para insertar en usuario
            //necesitamos un id de tipo persona, entonces podemos instanciar a tipopersona:
            //First devuelve lo resultado de la busqueda de Lector, em con => es una expresion labda, y equals compara el nombre de dicha TipoPersona
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
                //Observaciones = por defecto es NINGUNA
                //Observaciones = "ENTREGA TARDE",
                //IDPersona = por defecto es 1
                ID_TipoPersona = Lector.IdTipoPersona //D esta forma estamos usando el objeto creado anteriormente para que visualmente en el codigo sepamos
                //a que tipo de persona indicamos para el usuario, con el id
                //Seria lo mismo que hicimos con los dos anteriores, pero esto solo es por comodidad de visualizacion de codigo con las foreign key
                //claro esto aplica para estas tablas que tienen pocos registros, como sala, categoria, tipo persona. 
                //Pero por ejemplo para editorial que son muchas, quizas el creaar muchas objetos no seria muy apropiado. 
                //Ademas en teoria, el script a ejecutar para el proyecto final, ya debe tener los libros creados con sus respectivas referencias y dependencias
                //FechaCreacion = por defecto es GetDate();
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

            //Nos dimos cuenta que esta forma de trabajar no respeta los default de SQL
            //Por ejemplo para ciudad colocamos un default como "ZACATLÁN", sin embargo al insertar nos decia que no permite valores null
            //por es cierto, no permite esos valores, pero en teoria como tiene un default no deberia dar ese error
            //y en SQL si respeta esos defauult, ya sea para observaciones, para tipo persona, para ciudad, etc. 
            //Pero en este caso, no no deja
            //Para comprobar mas, descartando el error de no permitir null, hicimos un default para EscuelaProcedencia (esto con una intruccion en SQL)
            //Se supone que como EscuelaProcedencia admite null, el error que salia antes deberia no salir y asi es no sale ningun error y el programa inserta los demas valores
            //pero tampoco asi se aplico el default que colocamos
            //Entonces como conclusion, para estas consultas en C#, ya sea con Linq o SQL nato
            //no se admiten valores null, ni aun con un default
            //Por lo que no aplica los default

            //aunque algo extraño es que la fechaDeCreacion su defautl era GetDate(); y eso si lo coloco, teniendo en cuenta que el campo
            //fecha de creacion no permite valores null (Quizas fue porque ese default fue con una funcion de sql, de darnos una fecha).

            //LINQ, SQL en C#
            //Hasta ahora sabemos que 
            //las tablas identity podemos hacer insercion multimple
            //No se aplican los valores default
            //El orden en que escribamos cada propiedad no importa, podemos ingresar primero el ultimo valor y viceversa
            //Se estan respetando los indices declarados (como no repetir nombres completos de usuarios o repetir una sala),
            //Tambien se estan respetando las foreign key, las llaves primarias

            //Los triggers si se estan aplicando, como lo de disminuir un valor a ejemplar con cada prestamo o al eliminar prestamo, se aumenta un ejemplar (esto lo comprobamos en proyectos anteriores
            //Pero recordar, que los triggers en SQL solo aplican por una instruccion a la vez (por lo que el trigger para autogenerar codigo
            //de nuestras tablas como sala, categoria, editorial, etc) entonces, solo podemos insertar una a la vez. De lo contrario dará error de duplicacion de llave primaria

            //Despues de esto, decidimos cambiar a aceptar null en observaciones de usuario
            //Sera mas facil identificar que usuarios han hecho algo o tiene observaciones, porque habria algo escrito
            //pero si no, se supone que todo esta bien, y por eso en observaciones estaria en blanco
        }

    }

}
