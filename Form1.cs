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
                       
                        string tipoMonstruo = mySqlDataReader.GetString(0);
                        string nombreMonstruo = mySqlDataReader.GetString(1);

                        TreeNode parentNode = new TreeNode(tipoMonstruo);  // Crear nodo de tipo
                        trvMonstruos.Nodes.Add(parentNode);

                        TreeNode childNode = new TreeNode(nombreMonstruo);  // Crear nodo de nombre bajo el tipo
                        parentNode.Nodes.Add(childNode);
                    }
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
            if (e.Node.Level == 1)  // verifica el nodo esta en el nivel 1
            {
                string nombreMonstruo = e.Node.Text;

                // hace la consulta y se establece la conexion
                string consulta = "SELECT size, type, alignment, armor_class, hit_points FROM monstruario WHERE name = @nombreMonstruo";
                MySqlCommand mySqlCommand = new MySqlCommand(consulta);
                mySqlCommand.Connection = mConexion.getConexion();
                mySqlCommand.Parameters.AddWithValue("@nombreMonstruo", nombreMonstruo);

                
                //using asegura que el datareader se cierre despues del uso 
                using (MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader())
                {
                    if (mySqlDataReader.Read())
                    {
                        // crea el nodo hijo para cada detalle
                        TreeNode sizeNode = new TreeNode($"Tamaño: {mySqlDataReader.GetString(0)}");
                        e.Node.Nodes.Add(sizeNode);

                        TreeNode typeNode = new TreeNode($"Tipo: {mySqlDataReader.GetString(1)}");
                        e.Node.Nodes.Add(typeNode);

                        TreeNode alignmentNode = new TreeNode($"Alineación: {mySqlDataReader.GetString(2)}");
                        e.Node.Nodes.Add(alignmentNode);

                        TreeNode armorClassNode = new TreeNode($"Clase de Armadura: {mySqlDataReader.GetInt32(3)}");
                        e.Node.Nodes.Add(armorClassNode);

                        TreeNode hitPointsNode = new TreeNode($"Puntos de Vida: {mySqlDataReader.GetInt32(4)}");
                        e.Node.Nodes.Add(hitPointsNode);
                    }
                    else
                    {
                        // mensaje para cuando no se crea
                        TreeNode NodoSinDetalle = new TreeNode("No se encontraron detalles");
                        e.Node.Nodes.Add(NodoSinDetalle);
                    }
                }
                // se expande el tree para mostrar los detalles
                e.Node.Expand();

            }
        }

    }           
}
    

