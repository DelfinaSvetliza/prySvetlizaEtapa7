using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql;

namespace prySvetlizaEtapa7
{
    public partial class Form1 : Form
    {
        private clsConexion mConexion;
        public Form1()
        {
            InitializeComponent();
            mConexion = new clsConexion();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnConexion_Click(object sender, EventArgs e)
        {
            string result = "";
            try
            {
                // Verificar conexión
                if (mConexion.getConexion() == null)
                {
                    MessageBox.Show("Error al conectar a la base de datos.");
                    return;
                }

                // Ejecutar consulta
                string consulta = "SELECT * FROM monstruario";
                MySqlCommand mySqlCommand = new MySqlCommand(consulta);
                mySqlCommand.Connection = mConexion.getConexion();

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        result += mySqlDataReader.GetString(0) + "\n";
                    }
                }

                if (!string.IsNullOrEmpty(result))
                {
                    MessageBox.Show(result);
                }
                else
                {
                    MessageBox.Show("No se encontraron resultados.");
                }
            }
            catch (Exception ex)
            {
                // Manejar errores durante la ejecución de la consulta
                MessageBox.Show("Error durante la consulta: " + ex.Message); 
            }
        }
    }

}
    

