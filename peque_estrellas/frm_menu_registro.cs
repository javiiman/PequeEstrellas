using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace peque_estrellas
{
    public partial class frm_alumnos : Form
    {
        public frm_alumnos()
        {
            InitializeComponent();
            cargarGenero();
            cargarSangre();
            CargarPadres();
            CargarAlumnos();
            cargarSeleccion();
            cargarSeleccionPadres();
            cargarPadresHijos();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text != "" & txtApellido.Text != "" & txtCarne.Text != "" & cbxSangre.Text != "" & cbxGenero.Text != "")
            {
                OdbcConnection conexion = LittleStarsDB.connectionnResult();
                string sql = string.Format("INSERT INTO alumno VALUES(null,'{0}','{1}','{2}','{3}',(SELECT idtipo_sangre FROM tipo_sangre WHERE nombre = '{4}'),(SELECT idgenero FROM genero WHERE nombre = '{5}'), 1)", txtCarne.Text, txtNombre.Text, txtApellido.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd"), cbxSangre.Text, cbxGenero.Text);
                OdbcCommand cmd = new OdbcCommand(sql, conexion);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Datos agregados correctamente");
                    txtCarne.Clear();
                    txtNombre.Clear();
                    txtApellido.Clear();
                    cbxSangre.Items.Clear();
                    cbxGenero.Items.Clear();
                }
                else
                {
                    MessageBox.Show("Error al ingresar los datos");
                }
                conexion.Close();
            }
            else
            {
                MessageBox.Show("No tienes acceso a este modulo, por favor verifica los permisos con el administrador");
            }
            
        }

        private void cargarGenero()
        {
            OdbcConnection conexion = LittleStarsDB.connectionnResult();
            string sql = string.Format("SELECT nombre FROM GENERO");
            OdbcCommand cmd = new OdbcCommand(sql, conexion);
            OdbcDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //cbxGenero.Items.Clear();
                cbxGenero.Items.Add(reader.GetString(0));
                cbxGeneroPadre.Items.Add(reader.GetString(0));
                while (reader.Read())
                {
                    cbxGenero.Items.Add(reader.GetString(0));
                    cbxGeneroPadre.Items.Add(reader.GetString(0));
                }
            }
            else
            {
                MessageBox.Show("Error al extraer los datos de Genero");
            }
            conexion.Close();
        }

        private void cargarSangre()
        {
            OdbcConnection conexion = LittleStarsDB.connectionnResult();
            string sql = string.Format("SELECT nombre FROM tipo_sangre");
            OdbcCommand cmd = new OdbcCommand(sql, conexion);
            OdbcDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //cbxGenero.Items.Clear();
                cbxSangre.Items.Add(reader.GetString(0));
                while (reader.Read())
                {
                    cbxSangre.Items.Add(reader.GetString(0));
                }
            }
            else
            {
                MessageBox.Show("Error al extraer los datos de Genero");
            }
            conexion.Close();
        }

        private void CargarPadres()
        {
            OdbcConnection conexion = LittleStarsDB.connectionnResult();
            string sql = string.Format("SELECT nombre FROM padres");
            OdbcCommand cmd = new OdbcCommand(sql, conexion);
            OdbcDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //cbxGenero.Items.Clear();
                cbxSeleccionPadre.Items.Add(reader.GetString(0));
                while (reader.Read())
                {
                    cbxSeleccionPadre.Items.Add(reader.GetString(0));
                }
            }
            else
            {
                MessageBox.Show("Error al extraer los datos de Genero");
            }
            conexion.Close();
        }

        private void CargarAlumnos()
        {
            OdbcConnection conexion = LittleStarsDB.connectionnResult();
            string sql = string.Format("SELECT nombres FROM alumno");
            OdbcCommand cmd = new OdbcCommand(sql, conexion);
            OdbcDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //cbxGenero.Items.Clear();
                cbxSeleccionAlumno.Items.Add(reader.GetString(0));
                while (reader.Read())
                {
                    cbxSeleccionAlumno.Items.Add(reader.GetString(0));
                }
            }
            else
            {
                MessageBox.Show("Error al extraer los datos de Genero");
            }
            conexion.Close();
        }

        private void cbxGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSavePadres_Click(object sender, EventArgs e)
        {
            if (txtNombreP.Text != "" & txtApellidosP.Text != "" & txtTel1.Text != "" & txtTel2.Text != "" & txtCorreoP.Text != "" & cbxGeneroPadre.Text != "")
            {
                OdbcConnection conexion = LittleStarsDB.connectionnResult();
                string sql = string.Format("INSERT INTO padres VALUES(null,'{0}','{1}','{2}','{3}','{4}',(SELECT idgenero FROM genero WHERE nombre = '{5}'))", txtNombreP.Text, txtApellidosP.Text, txtTel1.Text, txtTel2.Text, txtCorreoP.Text ,cbxGeneroPadre.Text);
                OdbcCommand cmd = new OdbcCommand(sql, conexion);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Datos agregados correctamente");
                    txtNombreP.Text = "";
                    txtApellidosP.Text = "";
                    txtTel1.Text = "";
                    txtTel2.Text = "";
                    txtCorreoP.Text = "";
                    cbxGeneroPadre.Items.Clear();
                    cargarGenero();
                }
                else
                {
                    MessageBox.Show("Error al ingresar los datos");
                }
                conexion.Close();
            }
            else
            {
                MessageBox.Show("Por favor, no dejar campos en blanco.");
            }
        }

        private void btbSavePeH_Click(object sender, EventArgs e)
        {
            if ( cbxSeleccionPadre.Text != "" & cbxSeleccionAlumno.Text != "")
            {
                OdbcConnection conexion = LittleStarsDB.connectionnResult();
                string sql = string.Format("INSERT INTO padres_hijos VALUES(null,(SELECT IDALUMNO FROM ALUMNO WHERE NOMBRES = '{0}'),(SELECT IDPADRES FROM PADRES WHERE NOMBRE = '{1}'))", cbxSeleccionAlumno.Text, cbxSeleccionPadre.Text);
                OdbcCommand cmd = new OdbcCommand(sql, conexion);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Datos agregados correctamente");
                    cbxSeleccionAlumno.Items.Clear();
                    cbxSeleccionPadre.Items.Clear();
                }
                else
                {
                    MessageBox.Show("Error al ingresar los datos");
                }
                conexion.Close();
            }
            else
            {
                MessageBox.Show("Por favor, no dejar campos en blanco.");
            }
        }

        private void frm_menu_registro_Load(object sender, EventArgs e)
        {

        }

        private void cargarSeleccion()
        {
            dataGridView1.Rows.Clear();
            OdbcConnection conexion = LittleStarsDB.connectionnResult();
            try
            {
                string sql = string.Format("SELECT * FROM vista_alumnos;");
                OdbcCommand cmd = new OdbcCommand(sql, conexion);
                OdbcDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                    }
                }
                else
                {
                    MessageBox.Show("No existen clientes", "GESTION CLIENTES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FALLO LA CONEXION CON LA BASE DE DATOS!" + "\n" + ex.ToString(), "GESTION CLIENTES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            conexion.Close();
        }

        private void cargarSeleccionPadres()
        {
            dataGridView2.Rows.Clear();
            OdbcConnection conexion = LittleStarsDB.connectionnResult();
            try
            {
                string sql = string.Format("SELECT * FROM vista_padres;");
                OdbcCommand cmd = new OdbcCommand(sql, conexion);
                OdbcDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dataGridView2.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                    while (reader.Read())
                    {
                        dataGridView2.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                    }
                }
                else
                {
                    MessageBox.Show("No existen Padres", "GESTION PADRES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FALLO LA CONEXION CON LA BASE DE DATOS!" + "\n" + ex.ToString(), "GESTION PADRES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            conexion.Close();
        }

        private void cargarPadresHijos()
        {
            dataGridView3.Rows.Clear();
            OdbcConnection conexion = LittleStarsDB.connectionnResult();
            try
            {
                string sql = string.Format("SELECT * FROM vista_padres_hijos;");
                OdbcCommand cmd = new OdbcCommand(sql, conexion);
                OdbcDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dataGridView3.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                    while (reader.Read())
                    {
                        dataGridView3.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                    }
                }
                else
                {
                    MessageBox.Show("No existen Padres", "GESTION PADRES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FALLO LA CONEXION CON LA BASE DE DATOS!" + "\n" + ex.ToString(), "GESTION PADRES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            conexion.Close();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            cargarSeleccion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarPadresHijos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }

}
