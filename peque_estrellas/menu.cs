using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace peque_estrellas
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }
        
        public void PantallaOK()
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void menu_Load(object sender, EventArgs e)
        {
            PantallaOK();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_inicio_sesion_Click(object sender, EventArgs e)
        {
            new frm_alumnos().Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new frm_notas().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frm_gestion_escolar().Show();
        }

        private void btnInfoAlumno_MouseHover(object sender, EventArgs e)
        {
            
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new frm_gestion_de_personal().Show();
        }
    }
}
