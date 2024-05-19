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
            // Manejar el evento de selección de TreeView
            trvMonstruos.AfterSelect += new TreeViewEventHandler(trvMonstruos_AfterSelect);
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
                // Limpiar TreeView antes de cargar nuevos datos
                trvMonstruos.Nodes.Clear();
                // Ejecutar consulta
                string consulta = "SELECT * FROM monstruario";
                MySqlCommand mySqlCommand = new MySqlCommand(consulta);
                mySqlCommand.Connection = mConexion.getConexion();

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        // result += mySqlDataReader.GetString(0) + "\n";
                        string tipoMonstruo = mySqlDataReader.GetString(0);
                        string nombreMonstruo = mySqlDataReader.GetString(1);

                        TreeNode parentNode = new TreeNode(tipoMonstruo);  // Crear nodo de tipo
                        trvMonstruos.Nodes.Add(parentNode);

                        TreeNode childNode = new TreeNode(nombreMonstruo);  // Crear nodo de nombre bajo el tipo
                        parentNode.Nodes.Add(childNode);
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
        private void trvMonstruos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 1)  // Check if selected node is a monster name (Level 1)
            {
                string nombreMonstruo = e.Node.Text;

                // Execute query to retrieve monster details for the selected name
                string consulta = "SELECT size, type, alignment, armor_class, hit_points FROM monstruario WHERE name = @nombreMonstruo";
                MySqlCommand mySqlCommand = new MySqlCommand(consulta);
                mySqlCommand.Connection = mConexion.getConexion();
                mySqlCommand.Parameters.AddWithValue("@nombreMonstruo", nombreMonstruo);

                string detalles = "";  // String to store details

                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    if (mySqlDataReader.Read())
                    {
                        detalles = $"Tamaño: {mySqlDataReader.GetString(0)}\n";
                        detalles += $"Tipo: {mySqlDataReader.GetString(1)}\n";
                        detalles += $"Alineación: {mySqlDataReader.GetString(2)}\n";
                        detalles += $"Clase de Armadura: {mySqlDataReader.GetInt32(3)}\n";
                        detalles += $"Puntos de Vida: {mySqlDataReader.GetInt32(4)}\n";
                    }
                    else
                    {
                        detalles = "no se encontraron detalles";
                    }
                }

                if (!string.IsNullOrEmpty(detalles))
                {
                    MessageBox.Show(detalles);
                }
                else
                {
                    MessageBox.Show("No se encontraron detalles para el monstruo seleccionado.");
                }
            }
        }

    }           
}
    

