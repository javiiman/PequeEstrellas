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
    public partial class frm_gestion_escolar : Form
    {
        public frm_gestion_escolar()
        {
            InitializeComponent();
            CargarSecciones();
            CargarGrados();
            CargarCiclos();
            CargarMaterias();
        }

        private void btnSaveSeccion_Click(object sender, EventArgs e)
        {
            if (txtSeccion.Text != "")
            {
                OdbcConnection conexion = LittleStarsDB.connectionnResult();
                string sql = string.Format("INSERT INTO secciones VALUES(null,'{0}')", txtSeccion.Text);
                OdbcCommand cmd = new OdbcCommand(sql, conexion);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Datos agregados correctamente");
                    txtSeccion.Clear();
                    CargarSecciones();
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
        

        private void btnSaveGrados_Click(object sender, EventArgs e)
        {
            if (txtGrados.Text != "")
            {
                OdbcConnection conexion = LittleStarsDB.connectionnResult();
                string sql = string.Format("INSERT INTO grados VALUES(null,'{0}')", txtGrados.Text);
                OdbcCommand cmd = new OdbcCommand(sql, conexion);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Datos agregados correctamente");
                    txtSeccion.Clear();
                    CargarGrados();
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

        private void bntSaveCiclos_Click(object sender, EventArgs e)
        {
            if (txtCiclos.Text != "")
            {
                OdbcConnection conexion = LittleStarsDB.connectionnResult();
                string sql = string.Format("INSERT INTO ciclo VALUES(null,'{0}','{1}','{2}')", txtCiclos.Text, dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                OdbcCommand cmd = new OdbcCommand(sql, conexion);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Datos agregados correctamente");
                    txtSeccion.Clear();
                    CargarCiclos();
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

        private void bntSaveMaterias_Click(object sender, EventArgs e)
        {
            if (txtMaterias.Text != "")
            {
                OdbcConnection conexion = LittleStarsDB.connectionnResult();
                string sql = string.Format("INSERT INTO materia VALUES(null,'{0}')", txtMaterias.Text);
                OdbcCommand cmd = new OdbcCommand(sql, conexion);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Datos agregados correctamente");
                    txtMaterias.Clear();
                    CargarMaterias();
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

        private void CargarSecciones()
        {
            dataGridView1.Rows.Clear();
            OdbcConnection conexion = LittleStarsDB.connectionnResult();
            try
            {
                string sql = string.Format("SELECT * FROM vista_secciones;");
                OdbcCommand cmd = new OdbcCommand(sql, conexion);
                OdbcDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1));
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1));
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

        private void CargarGrados()
        {
            dataGridView2.Rows.Clear();
            OdbcConnection conexion = LittleStarsDB.connectionnResult();
            try
            {
                string sql = string.Format("SELECT * FROM vista_grados;");
                OdbcCommand cmd = new OdbcCommand(sql, conexion);
                OdbcDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dataGridView2.Rows.Add(reader.GetString(0), reader.GetString(1));
                    while (reader.Read())
                    {
                        dataGridView2.Rows.Add(reader.GetString(0), reader.GetString(1));
                    }
                }
                else
                {
                    MessageBox.Show("No existen clientes", "GESTION GRADOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FALLO LA CONEXION CON LA BASE DE DATOS!" + "\n" + ex.ToString(), "GESTION GRADOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            conexion.Close();
        }

       private void CargarCiclos()
        {
            dataGridView3.Rows.Clear();
            OdbcConnection conexion = LittleStarsDB.connectionnResult();
            try
            {
                string sql = string.Format("SELECT * FROM vista_ciclos;");
                OdbcCommand cmd = new OdbcCommand(sql, conexion);
                OdbcDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dataGridView3.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    while (reader.Read())
                    {
                        dataGridView3.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    }
                }
                else
                {
                    MessageBox.Show("No existen clientes", "GESTION GRADOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FALLO LA CONEXION CON LA BASE DE DATOS!" + "\n" + ex.ToString(), "GESTION GRADOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            conexion.Close();
        }

        private void CargarMaterias()
        {
            dataGridView4.Rows.Clear();
            OdbcConnection conexion = LittleStarsDB.connectionnResult();
            try
            {
                string sql = string.Format("SELECT * FROM vista_materia;");
                OdbcCommand cmd = new OdbcCommand(sql, conexion);
                OdbcDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dataGridView4.Rows.Add(reader.GetString(0), reader.GetString(1));
                    while (reader.Read())
                    {
                        dataGridView4.Rows.Add(reader.GetString(0), reader.GetString(1));
                    }
                }
                else
                {
                    MessageBox.Show("No existen clientes", "GESTION GRADOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FALLO LA CONEXION CON LA BASE DE DATOS!" + "\n" + ex.ToString(), "GESTION GRADOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            conexion.Close();
        }

    }
}
