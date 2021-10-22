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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_inicio_sesion_Click(object sender, EventArgs e)
        {
            OdbcConnection conexion = LittleStarsDB.connectionnResult();
            string sql = string.Format("SELECT * FROM usuario where username = '"+txtUsuario.Text+"'AND psw ='"+txtPassword.Text+"'");
            OdbcCommand cmd = new OdbcCommand(sql,conexion);
            OdbcDataReader reader= cmd.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show("Bienvenido");
                new menu().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
                txtPassword.Clear();
                txtUsuario.Clear();
                txtUsuario.Focus();
            }
            conexion.Close();
        }

        private void login_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }
    }
}
