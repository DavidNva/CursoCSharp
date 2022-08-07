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
using System.Data.SqlClient;
using System.Data;

namespace AppBiblioteca
{

    public partial class MainWindow : Window
    {

        SqlConnection miConexionSQL;

        public MainWindow()
        {
            InitializeComponent();
            //Conextamos la aplicacion con la base de datos
            string miConexion = ConfigurationManager.ConnectionStrings["AppBiblioteca.Properties.Settings.BibliotecaAppConnectionString"].ConnectionString;

            miConexionSQL = new SqlConnection(miConexion);//Para decirle que vamos a usar una conexion con la declarada anteriormente

            muestraUsuarios();
            muestraTodosPedidos();
            muestraCategorias();
        }
        private void listaUsuarios_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            muestraPedidos();  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(listaTodosPrestamos.SelectedValue.ToString());
            if (listaTodosPrestamos.SelectedItem != null)
            {
                eliminarPrestamos();
            }
            else MessageBox.Show("Selecciona primero un prestamo para eliminar", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            muestraTodosPedidos();
        }

        private void btnInsertarCategoria_Click(object sender, RoutedEventArgs e)
        {
            if(txtInsertarCategoria.Text == "")
            {
                MessageBox.Show("Para insertar una categoria, primera ingresa el nombre en la caja de texto","Información",MessageBoxButton.OK,MessageBoxImage.Information);
            }else insertarCategoria();
        }

        private void btnBorrarCategoria_Click(object sender, RoutedEventArgs e)
        {
            if (listaCategorias.SelectedItem != null)
            {
                eliminarCategoria();
            }else MessageBox.Show("Selecciona primero una categoria para eliminar", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        //------------------------------------------------------------------------Metodos ---------------------------------------------------

        private void muestraUsuarios()
        {
            try
            {
                string consulta = "SELECT * FROM Usuario";
                //nECESTITAMOS UN DataTablE PARA Almacenar la informacion de la tabla de la consulta que estamos haciendo
                //para ello, vamos a usar la listBox declarada en XAML 
                //necesitamos hacer una instanciar para adaptar esa tabla a una de nuestra intefaz grafica
                SqlDataAdapter miAdaptador = new SqlDataAdapter(consulta, miConexionSQL);


                using (miAdaptador)//usando este adaptador, me vas a hacer lo siguiente
                {
                    DataTable UsuariosTabla = new DataTable();//Vamos a usar este adaptador sql
                                                              //para rellenar la informacion dentro de la datatable 
                    miAdaptador.Fill(UsuariosTabla);//Con esta instruccion tenemos toda la tabla que genera la consulta
                    listaUsuarios.DisplayMemberPath = "Nombre";//Para especificar que informacion queremos ver en el listBox
                    listaUsuarios.SelectedValuePath = "IDUsuario";//Cuando vamos a seleccionar un elemento y hacer algo con el (actualizar, eliminar, etc)
                    listaUsuarios.ItemsSource = UsuariosTabla.DefaultView;////Para especificar de donde viene la informacion para listBox
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        //Haremos un metodo que pueda ser usado para cualquier consulta de tabla completa  (solo lleg hasta la creacion de la tabla virtual)
        //la parte de que elemento mostrar, que elemento valuea sera tomado y el origen, seria aparte (dependiendo de que estemos usando, si un listBox, una tabla, etc)

        private void muestraPedidos()
        {
            //Esto es una consulta parametrica: El critero va a ser un parametro (la instruccion where) con un usuario por parametro
            //Necesitamos una instruccion que utilice como critero el parametro de un usuario seleccionado
            //Hacemos una seleccion normal: Pero hacemos un INNER JOIN con las tablas involucradas, o a relacionar
            //Crearemos dos variables, una para cada tabla, en este caso
            //P es la variable para prestamo: Como si crearamos un objeto de tipo pedido
            //y U es la variable para usuario: Un objeto de tipo usuario
            //De aqui sigue usar esas variable para validar el INNER JOIN igualando los valores (como en una consulta SQL)
            //IDUsuario pertenece a usuario y ID_Usuario pertenece a prestamo, Siendo una foreign key (Por eso se puede hacer el INNER JOIN): El campo comun es IDUsuario
            try
            {
                string consulta = "SELECT * FROM Prestamo P INNER JOIN Usuario U ON U.IDUsuario = P.ID_Usuario " +
                  "WHERE U.IDUsuario = @IDUsuarioP";//Los parametros se declaran con un arroba @ como en SQL
                                                    //en este caso estamos diciendo que seleccione de la tabla prestamo los usuarios con el IDUsuario que se indique por parametro
                                                    //ese parametro lo tomara del valor de la lista que el usuario seleccione.
                string consulta2 = "SELECT * FROM Prestamo P WHERE P.ID_Usuario = @IDUsuarioP2";//Aunque toda la consulta anterior podemos hacerlo de esta forma
                                                                                                //porque al ya estar relacionado con usuario, podemos usar la foreign para identificar los usurios y sus prestamos, funcionaria de igual forma

                //Debemos instanciar un SQLCommand para poder usar su propiedad y metodo: Parameters.AddWithValue, donde indicaremos el parametro que creamos
                //y de donde lo tomara(en este caso de la listaUsuario donde el  usuario haga clic
                SqlCommand sqlComando = new SqlCommand(consulta, miConexionSQL);//Antes de usar el adaptador, debemos crear esta SqlComand
                SqlDataAdapter miAdaptador = new SqlDataAdapter(sqlComando);//el adaptador toma como parametro la instancia tipo SQLComand

                //Para una consulta parametrica, tenemos que usar:
                //La clase SqlComando
                //Declarar un parametro (dar nombre con un arroba @) y usar un parámetro
                //Pasamos al adaptadorSQL (SqlDataAdapter) la instancia de SqlComand
                //Luego utilizando el metodo AddWithValue: Especificar que valor es el que metemos dentro del parametro

                using (miAdaptador)//usando este adaptador, me vas a hacer lo siguiente Prestamo(Con la consulta dada)
                {
                    //Aqui usamos el metodo mencionado: AddWithValue
                    //Indicando el parametro que creamos y de donde tomara ese valor ( de donde viene ese dato que se debe almacenar en el parametro (por eso es del valor seleccionado de la lista de clientes)
                    sqlComando.Parameters.AddWithValue("@IDUsuarioP", listaUsuarios.SelectedValue);//Antes de usar el data table, hacemos uso de este metodo AddWithValue
                    DataTable PedidosTabla = new DataTable();//Vamos a usar este adaptador sql--esto aplica como el metodo anterior
                                                             //para rellenar la informacion dentro de la datatable 
                    miAdaptador.Fill(PedidosTabla);//Con esta instruccion tenemos toda la tabla que genera la consulta
                                                   //Con esto ya tenemos una tabla virtual en memoria cargada con la informacion de la tabla 
                    prestamoUsuarios.DisplayMemberPath = "FechaPrestamo";//Para especificar que informacion queremos ver en el listBox
                                                                         //La siguiente linea: cual es el campo clave del registro
                    prestamoUsuarios.SelectedValuePath = "IDPrestamo";//Cuando vamos a seleccionar un elemento y hacer algo con el (actualizar, eliminar, etc)
                    prestamoUsuarios.ItemsSource = PedidosTabla.DefaultView;////Para especificar de donde viene la informacion para el segundo listBox
                                                                            //Esta ultima linea es decir de donde viene el origen de esos datos para la consulta
                                                                            //en este caso, viene de la tabla virtual que hemos creado con dicha consulta
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void muestraTodosPedidos()
        {
            //Consulta de campo nuevo calculado (del lenguaje SQL)
            //sE TRATA DE DAR UN ALIS y hacer una concatenacion
            //AGREGAMOS UN * para seleccionar tambien todos los campos (aunque no lo utilicemos aun, ***esto es como prueba para el delete
            //Agregando ese *, se supone que la consulta esta devolviendo todos los datos, ademas del alias (ya nosotros elegimos que campos mostrar o usar)
            try
            {
                string consulta = "SELECT *,Concat(ID_Usuario,'      ',FechaPrestamo, '      ', Devuelto, '      ', Observaciones ) AS infoPrestamo FROM Prestamo";
                SqlDataAdapter miAdaptador = new SqlDataAdapter(consulta, miConexionSQL);//Si deseamos mostrar datos, siempre usaremos el adaptador
                using (miAdaptador)
                {
                    DataTable todosPrestamosTabla = new DataTable();//Con esto ya tenemos una tabla virtual en memoria cargada con la informacion de la tabla 
                    miAdaptador.Fill(todosPrestamosTabla);//Con esta instruccion tenemos toda la tabla que genera la consulta
                                                          //Con esto ya tenemos una tabla virtual en memoria cargada con la informacion de la tabla 
                    listaTodosPrestamos.DisplayMemberPath = "infoPrestamo";
                    listaTodosPrestamos.SelectedValuePath = "IDPrestamo";//Para otras consultas de tipo delete o update (donde necesitaremos el valor del ID)
                    listaTodosPrestamos.ItemsSource = todosPrestamosTabla.DefaultView;//De donde proviene la informacion (de la tabla virtual creada)
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void eliminarPrestamos()
        {
            try
            {
                string consulta = "DELETE FROM Prestamo WHERE IDPrestamo = @IDPrestamoP";
                SqlCommand miSqlComand = new SqlCommand(consulta, miConexionSQL);
                miConexionSQL.Open();
                miSqlComand.Parameters.AddWithValue("@IDPrestamoP", listaTodosPrestamos.SelectedValue);//Por eso cuando mostramos pedidos, le dijimos que su Valor a seleccionar seria el ID (De alli la importancia de esa linea)
                MessageBoxResult respuesta = MessageBox.Show("¿Estás seguro que deseas eliminar el registro seleccionado?", "Eliminacion de Préstamo", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);

                if (respuesta == MessageBoxResult.Yes)
                {
                    miSqlComand.ExecuteNonQuery();
                    miConexionSQL.Close();
                }
                else miConexionSQL.Close();
                muestraTodosPedidos();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

       
        private void muestraCategorias()
        {

            /*try
            {
                string consulta = "Select * From Categoria";
                SqlDataAdapter miAdaptador = new SqlDataAdapter();
                DataTable categoriasTabla = new DataTable();
                Select(consulta, miConexionSQL, miAdaptador, categoriasTabla);
                listaCategorias.DisplayMemberPath = "Categoria";
                listaCategorias.SelectedValuePath = "IDCategoria";//Para otras consultas de tipo delete o update (donde necesitaremos el valor del ID)
                listaCategorias.ItemsSource = categoriasTabla.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }*/
            try
            {
                string consulta = "Select * From Categoria";
                SqlDataAdapter miAdaptador = new SqlDataAdapter(consulta, miConexionSQL);
                using (miAdaptador)
                {
                    DataTable categoriasTabla = new DataTable();
                    miAdaptador.Fill(categoriasTabla);
                    listaCategorias.DisplayMemberPath = "Categoria";
                    listaCategorias.SelectedValuePath = "IDCategoria";//Para otras consultas de tipo delete o update (donde necesitaremos el valor del ID)
                    listaCategorias.ItemsSource = categoriasTabla.DefaultView;

                }
            /*
              Los using son para que 
              luego de ejecutar el codigo que esta dentro del using, ese objeto se elimine de la memoria
              en este caso el objeto sera la ventanaPrestamos llamando a un metodo
              Dispose que lo que hace es eliminar toda referencia de la memoria (es una buena practica y si no lo hacemos
              el IDE nos va a advertir que no estamos haciendo la llamada al metodo Dispose();
            */

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void insertarCategoria()
        {
            string consulta = "INSERT INTO Categoria (Categoria) VALUES (@CategoriaP)";
            //string consulta = "UPDATE Categoria SET Categoria = @CategoriaTextP WHERE IDCategoria = @IDCategoriaP (ACTUALIZCION POSIBLE EJEMPLO)
            SqlCommand sqlCommand = new SqlCommand(consulta, miConexionSQL);
            miConexionSQL.Open();
            sqlCommand.Parameters.AddWithValue("@CategoriaP", txtInsertarCategoria.Text);
            //podriasmo mostrar messagebox que diga que va a insertar, si acepta o cancela
            sqlCommand.ExecuteNonQuery();
            miConexionSQL.Close();
            muestraCategorias();//para actualizar la lista de nuevo y ahora mostrar el dato insertado
            txtInsertarCategoria.Text = "";//Hecho eso, se limpiar la caja de texto
        }
        private void eliminarCategoria()
        {
            try
            {
                string consulta = "DELETE FROM Categoria WHERE IDCategoria = @IDCategoriaP";
                SqlCommand miSqlComand = new SqlCommand(consulta, miConexionSQL);
                miConexionSQL.Open();
                miSqlComand.Parameters.AddWithValue("@IDCategoriaP", listaCategorias.SelectedValue);//Por eso cuando mostramos pedidos, le dijimos que su Valor a seleccionar seria el ID (De alli la importancia de esa linea)
                
                MessageBoxResult respuesta = MessageBox.Show("¿Estás seguro que deseas eliminar el registro seleccionado?", "Eliminacion de Categoria", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
                if (respuesta == MessageBoxResult.Yes){
                    miSqlComand.ExecuteNonQuery();
                    miConexionSQL.Close();
                }else miConexionSQL.Close();
                muestraCategorias();
               
                

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void btnActualizaUsuario_Click(object sender, RoutedEventArgs e)
        {

           
            if (listaUsuarios.SelectedItem != null)
            {
                //Cuando se crea la ventana, cuando se instancia, se lleva el valor del ID de Usuarios  de esta clase y de esta forma
                //ya lo podremos usar en la consulta de actualizacion de dicha ventana
                ActualizarUsuario ventanaActualizarU = new ActualizarUsuario((int)listaUsuarios.SelectedValue);
                

                try //estas lineas son para mostrar en el cuadro de teto del segundo formulario el nombre que hemos seleccionado para actualizar
                    //Como cuestion de interface y entendimiento con el usuario
                {
                    string consulta = "SELECT Nombre FROM Usuario WHERE IDUsuario = @IDUsuarioP";
                    SqlCommand sqlCommand = new SqlCommand(consulta, miConexionSQL);//La conexion para realizar la consulta
                    SqlDataAdapter miAdaptador = new SqlDataAdapter(sqlCommand);
                    using (miAdaptador)
                    {
                        sqlCommand.Parameters.AddWithValue("@IDUsuarioP", listaUsuarios.SelectedValue);
                        DataTable miTablaAU = new DataTable();
                        miAdaptador.Fill(miTablaAU);//Rellena la tabla virtual
                        ventanaActualizarU.txtActualizaUsuarioV.Text = miTablaAU.Rows[0]["Nombre"].ToString();//La consulta solo devuelve un registro, la del usuario seleccionado
                                                                                                              //osea la primera fila de la tabla virtual que rellemos con el adaptador.Fill
                    }
                }
                catch (Exception e2)
                {
                    MessageBox.Show(e2.ToString());
                }
                ventanaActualizarU.ShowDialog();//Se queda en ejecucion de esta linea (nos lleva a lo que hay en esta ventana y ejecuta todo ello, lo de actualizar)
                //La diferencia con el metodo Show normal es que 
                //ShowDialog es Modal, es decir no permite acceder a otras ventanas, solo a ese dialogo, y la ejecucion del programa se detiene alli
                //hasta que cerramos dicha ventana    
                /*
                 * Los formularios modales permiten alternar el foco entre dos formularios sin necesidad de cerrar el formulario inicial. 
                 * El usuario puede continuar trabajando en otro lugar, en cualquier aplicación, mientras se muestra el formulario.
                 */
                //Las diferencias a nivel tecnico: 
                //Show normal, por ejemplo nos abre dos hilos diferentes(por eso podemos regresar a la ventana)
                //Dos hilos donde vamos a poner cada uno de los formularios
                //en cambio el showDialog(); solo nos permite un hilo, en realidad utiliza el mismo hilo del proceso para mostrar ambos formularios
                //y por eso uno queda bloqueado hasta que se cierre dicho dialogo
                //thread = hilo de un proceso       
     
                muestraUsuarios();//Cuando se cierra pasa a la siguiente linea, y en esta mostramos de nuevo los usuarios, para ver reflejada la actualizacion (segunda forma de hacerlo)
            }
            else {MessageBox.Show("Selecciona primero un usuario para actualizar","Información",MessageBoxButton.OK,MessageBoxImage.Information); }
        }

        //Hasta Ahora conocemos dos formas de ver reflejada la informacion nuevamente al actualizar
        //Una es por ejemplo, con el evento Activated de la ventana principal (o a la qu queramos ver su actualizacion)
        //En este evento pues simplemente llamamos al metodo mostrar y asi mostraria los datos actualizados
        private void Windows_Activated(object sender, EventArgs e)
        {
            muestraUsuarios();
            //Podemos pensar por ejemplo, en tener todos los metodos de visualizacion de datos en este evento, para que cada vez que demos clic aqui o estemos en esta ventana
            //pues se refleje cualquier actualizacion realizada, aunque como lo dicho esto es menos personalizado
            //quiza en algunos casos sea mejor tener primero el show dialog de cierta actualizacion, insercion o eliminacion, y cuando salgamos pues se observe lo que se ha actualizado
        }

        //otra forma es con un showDialog(); Ya que cuando se hace esto, a la unica ventana que podemos acceder es a la de ese showDialog
        //alli se detiene la ejecucion de codigo (en teoria pasa a ejecutar lo que haya en esa nueva ventana) y una vez que cierre continua el flujo de ejecucion
        //Esto podemos usarlo a favor, indicando el metodo de mostrar, despues del show dialog, de esta forma seria mas personalizado que queremos ver acutalizado
        //indicandole que lo muestre en la interface una vez que se cierre ese show dialog//Justo como lo estamos hacindo en este proyecto
        //(ir a ver codigo de la ventana actualizar usuarios)


    }
}
/*
 * SqlDataAdapter simpre se va usar cuando deseemos mostrar datos (en una tabla, en un listbos, etc)
 * DataTable es para crear una tabla virtual, que despues se llenara asigando al adaptador (para despues indicarlo como ItemSource del elemento donde lo queramos mostrar
 * SqlComand se usa cuando hacemos consultas parametricas, osea igual usaremos un adapter, pero con esta instancia
 * 
 * Con respecto al listBox:
 * .DisplayMemberPath: Es para decir que informacion se va a mostrar
 * .SelectedValuePath: Se usa cuando hacemos otro tipo de consultas, como update, delete, donde necesitamos un id para identificar
 *  por eso el select value, nos dara un valor, y ese valor sera el id (por eso especificamos id en su = )
 * .ItemSource: Es para decirle al elemento de donde proviene la informacion que tendra
*/