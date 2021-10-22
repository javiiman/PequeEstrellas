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
    public partial class frm_gestion_de_personal : Form
    {
        public frm_gestion_de_personal()
        {
            InitializeComponent();
            CargarPuestos();
            CargarGenero();
            CargarPersonas();
            cargarTrabajadores();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSavePadres_Click(object sender, EventArgs e)
        {
            if (txtNombreE.Text != "" & txtApellidosE.Text != "" & txtDpiE.Text != "" & txtTelE.Text != "" & txtCorreoE.Text != "" & cbxGeneroE.Text != "" & cbxPuestoE.Text != "" & cbxGeneroE.Text != "")
            {
                OdbcConnection conexion = LittleStarsDB.connectionnResult();
                string sql = string.Format("INSERT INTO PERSONA VALUES(null,'{0}','{1}','{2}','{3}','{4}','{5}',(SELECT idpuesto FROM puesto WHERE nombre = '{6}'), (SELECT idgenero FROM GENERO WHERE nombre = '{7}'))", txtNombreE.Text, txtApellidosE.Text, txtDpiE.Text, dtpFechaE.Value.ToString("yyyy-MM-dd"), txtTelE.Text, txtCorreoE.Text, cbxPuestoE.Text, cbxGeneroE.Text);
                OdbcCommand cmd = new OdbcCommand(sql, conexion);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Datos agregados correctamente");

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

        private void frm_gestion_de_personal_Load(object sender, EventArgs e)
        {

        }
        
        private void CargarGenero()
        {
            OdbcConnection conexion = LittleStarsDB.connectionnResult();
            string sql = string.Format("SELECT nombre FROM GENERO");
            OdbcCommand cmd = new OdbcCommand(sql, conexion);
            OdbcDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //cbxGenero.Items.Clear();
                cbxGeneroE.Items.Add(reader.GetString(0));
                while (reader.Read())
                {
                    cbxGeneroE.Items.Add(reader.GetString(0));
                }
            }
            else
            {
                MessageBox.Show("Error al extraer los datos de Genero");
            }
            conexion.Close();
        }
        private void CargarPuestos()
        {
            OdbcConnection conexion = LittleStarsDB.connectionnResult();
            string sql = string.Format("SELECT nombre FROM puesto");
            OdbcCommand cmd = new OdbcCommand(sql, conexion);
            OdbcDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //cbxGenero.Items.Clear();
                cbxPuestoE.Items.Add(reader.GetString(0));
                while (reader.Read())
                {
                    cbxPuestoE.Items.Add(reader.GetString(0));
                }
            }
            else
            {
                MessageBox.Show("Error al extraer los datos de Genero");
            }
            conexion.Close();
        }
        private void CargarPersonas()
        {
            OdbcConnection conexion = LittleStarsDB.connectionnResult();
            string sql = string.Format("SELECT nombre FROM persona");
            OdbcCommand cmd = new OdbcCommand(sql, conexion);
            OdbcDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //cbxGenero.Items.Clear();
                cbxPersona.Items.Add(reader.GetString(0));
                while (reader.Read())
                {
                    cbxPersona.Items.Add(reader.GetString(0));
                }
            }
            else
            {
                MessageBox.Show("Error al extraer los datos de Genero");
            }
            conexion.Close();
        }

        private void btnSaveUsuario_Click(object sender, EventArgs e)
        {
            if (cbxPersona.Text != "" & txtUser.Text != "" & txtPsw.Text != "")
            {
                OdbcConnection conexion = LittleStarsDB.connectionnResult();
                string sql = string.Format("INSERT INTO usuario VALUES(null,(SELECT idpersona FROM persona WHERE nombre = '{0}'),'{1}','{2}')", cbxPersona.Text, txtUser.Text,txtPsw.Text);
                OdbcCommand cmd = new OdbcCommand(sql, conexion);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Datos agregados correctamente");

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPuesto.Text != "" & txtSalario.Text != "")
            {
                OdbcConnection conexion = LittleStarsDB.connectionnResult();
                string sql = string.Format("INSERT INTO puesto VALUES(null,'{0}','{1}')", txtPuesto.Text, txtSalario.Text);
                OdbcCommand cmd = new OdbcCommand(sql, conexion);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Datos agregados correctamente");
                    txtPuesto.Clear();
                    txtSalario.Clear();
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

        private void cargarTrabajadores()
        {
            dataGridView1.Rows.Clear();
            OdbcConnection conexion = LittleStarsDB.connectionnResult();
            try
            {
                string sql = string.Format("SELECT * FROM vista_trabajadores;");
                OdbcCommand cmd = new OdbcCommand(sql, conexion);
                OdbcDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7));
                    }
                }
                else
                {
                    MessageBox.Show("No existen Padres", "GESTION Trabajadores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FALLO LA CONEXION CON LA BASE DE DATOS!" + "\n" + ex.ToString(), "GESTION PADRES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            conexion.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
