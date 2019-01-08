using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicaciones_En_Ambientes_Porpietarios
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
           
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(190, 153);
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(220, 183);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(190, 153);
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(220, 183);
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(220, 183);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(190, 153);
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.Size = new Size(220, 183);
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Size = new Size(190, 153);
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.Size = new Size(220, 183);
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Size = new Size(190, 153);
        }

        private void pBCerrar_MouseHover(object sender, EventArgs e)
        {
            pBCerrar.Size = new Size(60, 57);
        }

        private void pBCerrar_MouseLeave(object sender, EventArgs e)
        {
            pBCerrar.Size = new Size(54, 51);
        }

        private void pBCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Size = new Size(190, 153);
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Size = new Size(220, 183);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Turismo2 turismo = new Turismo2();
            turismo.Show();
            this.Hide();
            
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Cursos cursos = new Cursos();
            cursos.Show();
            this.Hide();
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Facturaccion facturaccion = new Facturaccion();
            facturaccion.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ModuloCultura cultura = new ModuloCultura();
            cultura.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ModuloClientes cliente = new ModuloClientes();
            cliente.Show();
            this.Hide();
        }
    }
}
