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
    public partial class ModificarGuia : Form
    {
        BaseDeDatos bd = new BaseDeDatos();
        ValidarSoloLetrasSoloNumeros validar = new ValidarSoloLetrasSoloNumeros();
        public ModificarGuia()
        {
            InitializeComponent();
        }

       
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.BringToFront();
            panel1.Location = new Point(40, 150);
            dataGridView1.DataSource = bd.SelectDataTable("EXEC dbo.BuscarPersonaGuia");
        }

    
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(35, 29);
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(41, 35);
        }
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(73, 49);
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(79, 55);
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(73, 49);
        }
        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(79, 55);
        }
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Size = new Size(49, 42);
        }
        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Size = new Size(79, 55);
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Size = new Size(49, 31);
        }
        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.Size = new Size(55, 36);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            comboBox3.SelectedIndex = -1;
            textBox1.Text = "";

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text.Equals("") || textBox1.Text.Equals(""))
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
            if (comboBox3.Text.Equals("Cédula"))
            {
                string consultar = "EXEC dbo.BuscarPersonaGuiaCI @CI  ='" + textBox1.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }
            else if (comboBox3.Text.Equals("RUC"))
            {
                string consultar = "EXEC dbo.BuscarPersonaGuiaRUC @RUC ='" + textBox1.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }
            else if (comboBox3.Text.Equals("Nombre"))
            {
                string consultar = "EXEC dbo.BuscarPersonaGuiaNombre @nombreP ='" + textBox1.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }
            else if (comboBox3.Text.Equals("Apellido"))
            {
                string consultar = "EXEC dbo.BuscarPersonaGuiaApellido @apellidoP ='" + textBox1.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgv = dataGridView1.Rows[e.RowIndex];
            string nombres = dgv.Cells[2].Value.ToString();
            string[] profesor = nombres.Split(' ');
            txtNombre.Text = profesor[0];
            txtApellidos.Text = profesor[1];
            txtDireccion.Text = dgv.Cells[3].Value.ToString();
            dateTimePicker1.Text = dgv.Cells[4].Value.ToString();
            txtTelefono.Text = dgv.Cells[5].Value.ToString();
            txtEmail.Text = dgv.Cells[6].Value.ToString();
            textSueldo.Text = dgv.Cells[7].Value.ToString();
      

            
            txtIdentificacion.Enabled = false;

            if (dgv.Cells[0].Value.ToString() == "")
            {
                txtIdentificacion.Text = dgv.Cells[1].Value.ToString();
                radioButton2.Checked = true;
                radioButton1.Checked = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
            else if (dgv.Cells[1].Value.ToString() == "")
            {
                txtIdentificacion.Text = dgv.Cells[0].Value.ToString();
                radioButton1.Checked = true;
                radioButton2.Checked = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }




        }

       

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            guardar();

        }
        private void guardar()
        {
            if (radioButton1.Checked == true && radioButton2.Checked == false)
            {
                consulta1();
            }
            else if (radioButton2.Checked == true && radioButton1.Checked == false)
            {
                consulta2();
            }
            else
            {
                MessageBox.Show("Seleccione un opción en la identificación");
            }
        }
        private void consulta1()
        {
            string pago = textSueldo.Text;
            string[] sueldo = pago.Split(',');
            string salario = sueldo[0] + "." + sueldo[1];
            string actualizarProfesor = "EXEC dbo.ActualizarPersonaGuiaCI @CI = '" + txtIdentificacion.Text + "', @RUC = null," +
                " @nombreP = '" + txtNombre.Text + "', @apellidoP = '" + txtApellidos.Text + "', " +
                "@direccionP = '" + txtDireccion.Text + "', @fechaNaciP = '" + dateTimePicker1.Text + "', " +
                "@telefonoP = '" + txtTelefono.Text + "', @emailP = '" + txtEmail.Text + "'," +
                " @observacionP = null, @cobreI = '" + salario + "'";

            if (bd.executecommand(actualizarProfesor))
            {
                MessageBox.Show("Datos actualizados exitosamente");
                txtIdentificacion.Text = "";
                txtApellidos.Text = "";
                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                txtEmail.Text = "";
                textSueldo.Text = "";
                dateTimePicker1.Value = System.DateTime.Today;
                
            }
            else
            {
                MessageBox.Show("Error al actualizar");
            }
        }
        private void consulta2()
        {
            string pago = textSueldo.Text;
            string[] sueldo = pago.Split(',');
            string salario = sueldo[0] + "." + sueldo[1];
            string actualizarProfesor = "EXEC dbo.ActualizarPersonaGuiaRUC @CI = null, @RUC = '" + txtIdentificacion.Text + "'," +
                " @nombreP = '" + txtNombre.Text + "', @apellidoP = '" + txtApellidos.Text + "', " +
                "@direccionP = '" + txtDireccion.Text + "', @fechaNaciP = '" + dateTimePicker1.Text + "', " +
                "@telefonoP = '" + txtTelefono.Text + "', @emailP = '" + txtEmail.Text + "'," +
                " @observacionP = null, @cobreI = '" + salario + "'";

            if (bd.executecommand(actualizarProfesor))
            {
                MessageBox.Show("Datos actualizados exitosamente");
                txtIdentificacion.Text = "";
                txtApellidos.Text = "";
                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                txtEmail.Text = "";
                textSueldo.Text = "";
                dateTimePicker1.Value = System.DateTime.Today;
               
            }
            else
            {
                MessageBox.Show("Error al actualizar");
            }
        }

        private void ModificarGuia_Load(object sender, EventArgs e)
        {

        }
    }
}
