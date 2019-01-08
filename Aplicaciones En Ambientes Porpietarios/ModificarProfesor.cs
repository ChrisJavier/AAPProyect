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
    public partial class ModificarProfesor : Form
    {
        BaseDeDatos bd = new BaseDeDatos();
        ValidarSoloLetrasSoloNumeros validar = new ValidarSoloLetrasSoloNumeros();
        public ModificarProfesor()
        {
            InitializeComponent();
            
        }
      
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.BringToFront();
            panel1.Location = new Point(100, 150);
            dataGridView1.DataSource = bd.SelectDataTable("EXEC dbo.BuscarPersonaInstructor");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Size = new Size(35, 29);
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.Size = new Size(41, 35);
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
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(49, 42);
        }
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(79, 55);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Size = new Size(49, 31);
        }
        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Size = new Size(55, 36);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            comboBox3.SelectedIndex = -1;
            textBox1.Text = "";
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
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
                string consultar = "EXEC dbo.BuscarPersonaInstructorCI @CI  ='" + textBox1.Text+"'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }
            else if (comboBox3.Text.Equals("RUC"))
            {
                string consultar = "EXEC dbo.BuscarPersonaInstructorRUC @RUC ='" + textBox1.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }
            else if (comboBox3.Text.Equals("Nombre"))
            {
                string consultar = "EXEC dbo.BuscarPersonaInstructorNombre @nombreP ='" + textBox1.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }
            else if (comboBox3.Text.Equals("Apellido"))
            {
                string consultar = "EXEC dbo.BuscarPersonaInstructorApellido @apellidoP ='" + textBox1.Text + "'";
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
                string cobroPor = dgv.Cells[8].Value.ToString();
                string nivelIngles = dgv.Cells[9].Value.ToString();
                comboBox1.SelectedIndex = verIndex(cobroPor);
                comboBox2.SelectedIndex = index(nivelIngles);
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

        private int verIndex(string cobroPor)
        {
            int index = 0; 
            if (cobroPor == "Hora                ")
            {
                index=  0;
                
            }
            else if (cobroPor == "Día                 ")
            {
                index = 1;
            }
            else if (cobroPor == "Curso               ")
            {
                index = 2;
            }
            return index;
        }
        private int index(string variable)
        {
            int index = 0;
            if (variable.Equals("Medio          "))
            {
                index = 1;
            }
            else if (variable.Equals("Bajo           "))
            {
                index = 2;
            }
            else if (variable.Equals("Alto           "))
            {
                index = 0;
            }
            return index;
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
            string actualizarProfesor = "EXEC dbo.ActualizarPersonaInstructorCI @CI = '" + txtIdentificacion.Text+"', @RUC = null," +
                " @nombreP = '" + txtNombre.Text + "', @apellidoP = '" + txtApellidos.Text + "', " +
                "@direccionP = '" + txtDireccion.Text + "', @fechaNaciP = '" + dateTimePicker1.Text + "', " +
                "@telefonoP = '" + txtTelefono.Text + "', @emailP = '" + txtEmail.Text + "'," +
                " @observacionP = null, @cobreI = '" +salario + "', @cobroPorI =  '" + comboBox1.Text + "', " +
                "@nivelII = '" + comboBox2.Text + "'";
           
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
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
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
            string actualizarProfesor = "EXEC dbo.ActualizarPersonaInstructor @CI = null, @RUC = '" + txtIdentificacion.Text + "'," +
                " @nombreP = '" + txtNombre.Text + "', @apellidoP = '" + txtApellidos.Text + "', " +
                "@direccionP = '" + txtDireccion.Text + "', @fechaNaciP = '" + dateTimePicker1.Text + "', " +
                "@telefonoP = '" + txtTelefono.Text + "', @emailP = '" + txtEmail.Text + "'," +
                " @observacionP = null, @cobreI = '" + salario + "', @cobroPorI =  '" + comboBox1.Text + "', " +
                "@nivelII = '" + comboBox2.Text + "'";
       
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
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Error al actualizar");
            }
        }

        private void ModificarProfesor_Load(object sender, EventArgs e)
        {

        }

        private void txtIdentificacion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
