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
    public partial class BuscarProfesor : Form
    {
        BaseDeDatos bd = new BaseDeDatos();
        public BuscarProfesor()
        {
            InitializeComponent();
            
        }
        private void BuscarProfesor_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(55, 48);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(49, 42);
        }
        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.Size = new Size(47, 48);
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Size = new Size(41, 42);
        }
        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("") || textBox1.Text.Equals(""))
            {
                MessageBox.Show("Ingrese parametros de busqueda");
            }
            else
            {
                buscar();
            }
        }
        private void buscar()
        {
            if (comboBox1.Text.Equals("Cédula"))
            {
                string consultar = "EXEC dbo.BuscarPersonaInstructorCI @CI = '" + textBox1.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }
            else if (comboBox1.Text.Equals("RUC"))
            {
                string consultar = "EXEC dbo.BuscarPersonaInstructorRUC @RUC ='" + textBox1.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }
            else if (comboBox1.Text.Equals("Nombre"))
            {
                string consultar = "EXEC dbo.BuscarPersonaInstructorNombre @nombreP = '" + textBox1.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }
            else if (comboBox1.Text.Equals("Apellido"))
            {
                string consultar = "EXEC dbo.BuscarPersonaInstructorApellido @apellidoP ='" + textBox1.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }
            
        }
    }
}
