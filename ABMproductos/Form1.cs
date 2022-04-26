using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ABMproductos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;
            String nombre = txtNombre.Text;
            String descripcion = txtDescripcion.Text;
            Double precioPublico = double.Parse(txtPrecioPublico.Text);
            int existencia = int.Parse(txtExistencia.Text);
            String id = txtId.Text;
            string sql = "UPDATE Productos SET Codigo='"+codigo+"',Nombre ='"+nombre+"',Descripcion='"+descripcion+"',PrecioPublico='"+precioPublico+"',Existencia='"+existencia+"'WHERE idProductos='"+id+"'";
            MySqlConnection conexionBd = Conexion.conection();
            conexionBd.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBd);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Modificado");
                limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al Mopdificar" + ex.Message);
            }
            finally {
                conexionBd.Close();
            }

        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            MySqlDataReader reader = null;
            string sql = "SELECT idProductos,Codigo,Nombre,Descripcion,PrecioPublico,Existencia FROM  Productos WHERE codigo LIKE'" + codigo + "'LIMIT 1";
            MySqlConnection conexionBd = Conexion.conection();
            conexionBd.Open();
            try {
                MySqlCommand command = new MySqlCommand(sql,conexionBd);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtId.Text = reader.GetString(0);
                        txtCodigo.Text = reader.GetString(0);
                        txtNombre.Text = reader.GetString(2);
                        txtDescripcion.Text = reader.GetString(3);
                        txtPrecioPublico.Text = reader.GetString(4);
                        txtExistencia.Text = reader.GetString(5);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros");
                }
            }
            catch (MySqlException ex) {
                MessageBox.Show("Error al buscar" + ex.Message);
            }
            finally {
                conexionBd.Close();
            }
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;
            String nombre = txtNombre.Text;
            String descripcion = txtDescripcion.Text;
            Double precioPublico = double.Parse(txtPrecioPublico.Text);
            int existencia = int.Parse(txtExistencia.Text);
            String id = txtId.Text;
            string sql = "INSERT INTO Productos(Codigo,Nombre,Descripcion,PrecioPublico,Existencia) VALUES('" + codigo + "','" + nombre + "','" + descripcion + "','" + precioPublico + "','" + existencia + "')";
            MySqlConnection conexionBd = Conexion.conection();
            conexionBd.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBd);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Guardado");
                limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al guardar" + ex.Message);
            }
            finally
            {
                conexionBd.Close();
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            String id = txtId.Text;
            string sql = "DELETE FROM Productos WHERE idProductos='" + id + "'";
            MySqlConnection conexionBd = Conexion.conection();
            conexionBd.Open();
            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBd);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Eliminado");
                limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al Eliminar" + ex.Message);
            }
            finally
            {
                conexionBd.Close();
            }
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void limpiar() {
            txtCodigo.Text = "";
            txtId.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecioPublico.Text = "";
            txtExistencia.Text = "";
        }
    }

}
