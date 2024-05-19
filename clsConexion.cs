using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;

namespace prySvetlizaEtapa7
{
    internal class clsConexion
    {
        private MySqlConnection conexion;
        private string server = "localhost";
        private string database = "juegorol.sql";
        private string user = "root";
        private string password = "";
        private string cadenaConexion;

        public clsConexion()
        {
            /*cadenaConexion = "Server = localhost;" +
                    "Database = juegorol.sql;" +
                    "Uid = root;" +
                    "Pwd = ;";*/
        }

        public MySqlConnection getConexion() 
        {
            if (conexion == null)
            {
                try
                {
                    // Use connection string builder for clarity (optional)
                    var connectionStringBuilder = new MySqlConnectionStringBuilder
                    {
                        Server = server,
                        Database = database,
                        UserID = user,
                        Password = password
                    };

                    cadenaConexion = connectionStringBuilder.ConnectionString;

                    conexion = new MySqlConnection(cadenaConexion);
                    conexion.Open();
                }
                catch (MySqlException ex)
                {
                    // Handle connection errors here
                    MessageBox.Show("Error al conectar: " + ex.Message); // Or display a user-friendly message box
                }
            }
            return conexion;
        }
    }
}
 

