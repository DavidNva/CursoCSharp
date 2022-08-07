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
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace AppBiblioteca
{
    /// <summary>
    /// Lógica de interacción para ActualizarUsuario.xaml
    /// </summary>
    public partial class ActualizarUsuario : Window
    {
        SqlConnection miConexionSQL;
        int id;
        public ActualizarUsuario(int id)
        {
            InitializeComponent();
            this.id = id;
            string miConexion = ConfigurationManager.ConnectionStrings["AppBiblioteca.Properties.Settings.BibliotecaAppConnectionString"].ConnectionString;

            miConexionSQL = new SqlConnection(miConexion);
        }
        public ActualizarUsuario() { }

        private void btnActualizaUsuarioV_Click(object sender, RoutedEventArgs e)
        {
            string consulta = "UPDATE Usuario SET Nombre = @NombreP WHERE IDUsuario = " + this.id;

            SqlCommand sqlCommand = new SqlCommand(consulta, miConexionSQL);
            miConexionSQL.Open();
            sqlCommand.Parameters.AddWithValue("@NombreP", txtActualizaUsuarioV.Text);
            sqlCommand.ExecuteNonQuery();
            miConexionSQL.Close();
            MessageBox.Show("El campo Nombre se actualizó correctamente a: " + txtActualizaUsuarioV.Text);
            this.Close();
        }

        private void btnSalirActualizarU_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
    }
}
