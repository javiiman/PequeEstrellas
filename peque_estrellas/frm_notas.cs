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
    public partial class frm_notas : Form
    {
        public frm_notas()
        {
            InitializeComponent();
            CargarProfesor();
            cargar_materias();
            cargar_alumnos();
            cargar_ciclos();
        }

        private void btnSaveNotas_Click(object sender, EventArgs e)
        {
            if (cbxAlumnoN.Text != "" & cbxCicloN.Text != "" & cbxMateriaN.Text != "" & cbxProfesorN.Text != "" & txtZona.Text != "" & txtParcial1.Text != "" & txtParcial2.Text != "" & txtParcial3.Text != "" & txtParcial4.Text != "" & txtTotal.Text != "")
            {
                OdbcConnection conexion = LittleStarsDB.connectionnResult();
                string sql = string.Format("INSERT INTO NOTAS VALUES (null, (SELECT idalumno FROM alumno WHERE nombres = '{0}'), (SELECT idmateria FROM materia WHERE nombre = '{1}'), (SELECT idciclo FROM ciclo WHERE nombre = '{2}'), (SELECT idpersona FROM persona WHERE nombre = '{3}'),'{4}','{5}','{6}','{7}','{8}','{9}')", cbxAlumnoN.Text, cbxMateriaN.Text, cbxCicloN.Text, cbxProfesorN.Text, txtZona.Text, txtParcial1.Text, txtParcial2.Text, txtParcial3.Text, txtParcial4.Text, txtTotal.Text);
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

        private void cargar_ciclos()
        {
            OdbcConnection conexion = LittleStarsDB.connectionnResult();
            string sql = string.Format("SELECT nombre FROM CICLO");
            OdbcCommand cmd = new OdbcCommand(sql, conexion);
            OdbcDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //cbxGenero.Items.Clear();
                cbxCicloN.Items.Add(reader.GetString(0));
                while (reader.Read())
                {
                    cbxCicloN.Items.Add(reader.GetString(0));
                }
            }
            else
            {
                MessageBox.Show("Error al extraer los datos de Materias");
            }
            conexion.Close();
        }

        private void cargar_alumnos()
        {
            OdbcConnection conexion = LittleStarsDB.connectionnResult();
            string sql = string.Format("SELECT nombres FROM ALUMNO");
            OdbcCommand cmd = new OdbcCommand(sql, conexion);
            OdbcDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //cbxGenero.Items.Clear();
                cbxAlumnoN.Items.Add(reader.GetString(0));
                while (reader.Read())
                {
                    cbxAlumnoN.Items.Add(reader.GetString(0));
                }
            }
            else
            {
                MessageBox.Show("Error al extraer los datos de Materias");
            }
            conexion.Close();
        }

        private void cargar_materias()
        {
            OdbcConnection conexion = LittleStarsDB.connectionnResult();
            string sql = string.Format("SELECT nombre FROM MATERIA");
            OdbcCommand cmd = new OdbcCommand(sql, conexion);
            OdbcDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //cbxGenero.Items.Clear();
                cbxMateriaN.Items.Add(reader.GetString(0));
                while (reader.Read())
                {
                    cbxMateriaN.Items.Add(reader.GetString(0));
                }
            }
            else
            {
                MessageBox.Show("Error al extraer los datos de Materias");
            }
            conexion.Close();
        }

        private void CargarProfesor()
        {
            OdbcConnection conexion = LittleStarsDB.connectionnResult();
            string sql = string.Format("SELECT nombre FROM PERSONA");
            OdbcCommand cmd = new OdbcCommand(sql, conexion);
            OdbcDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //cbxGenero.Items.Clear();
                cbxProfesorN.Items.Add(reader.GetString(0));
                while (reader.Read())
                {
                    cbxProfesorN.Items.Add(reader.GetString(0));
                }
            }
            else
            {
                MessageBox.Show("Error al extraer los datos de Profesores");
            }
            conexion.Close();
        }

        private void txtParcial4_Leave(object sender, EventArgs e)
        {
            int n1, n2, n3, n4, r;
            n1 = Convert.ToInt32(txtParcial1.Text);
            n2 = Convert.ToInt32(txtParcial2.Text);
            n3 = Convert.ToInt32(txtParcial3.Text);
            n4 = Convert.ToInt32(txtParcial4.Text);
            r = n1 + n2 + n3 + n4;
            txtTotal.Text = r.ToString();

            if (r >= 244)
            {
                labelEstado.Text = "Aprobado";
            }
            else
            {
                labelEstado.Text = "Reprobado";
            }
        }
    }
}
