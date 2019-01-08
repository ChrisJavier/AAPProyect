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
    public partial class BuscarTaller : Form
    {
        BaseDeDatos bd = new BaseDeDatos();
        public BuscarTaller()
        {
            InitializeComponent();
        }

        
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            buscar();
        }
        private void buscar()
        {
            if (comboBox1.Text.Equals("Nombre"))
            {
                string consultar = "SELECT * FROM TALLER WHERE NOMBRE ='" + textBox1.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }

            else if (comboBox1.Text.Equals("Día"))
            {
                string consultar = "SELECT * FROM TALLER WHERE FECHA='" + textBox1.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }
            else if (comboBox1.Text.Equals("Hora"))
            {
                string consultar = "SELECT * FROM TALLER WHERE HORA ='" + textBox1.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }

        }
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(49, 42);
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(55, 48);
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.Size = new Size(55, 37);
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Size = new Size(49, 31);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
