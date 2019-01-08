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
    public partial class ModificarParticipante : Form
    {
        BaseDeDatos bd = new BaseDeDatos();
        public ModificarParticipante()
        {
            InitializeComponent();
            cargarComboBox();
            comboBox1.SelectedIndex = -1;
            textBox2.Text = "";
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.BringToFront();
            panel1.Location = new Point(80, 120);
            dataGridView1.DataSource = bd.SelectDataTable("exec dbo.BuscarPersonaParticipante");
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
                string consultar = "EXEC dbo.BuscarPersonaParticipanteCI @CI  ='" + textBox1.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }
            else if (comboBox3.Text.Equals("RUC"))
            {
                string consultar = "EXEC dbo.BuscarPersonaParticipanteRUC @RUC ='" + textBox1.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }
            else if (comboBox3.Text.Equals("Nombre"))
            {
                string consultar = "EXEC dbo.BuscarPersonaParticipanteNombre @nombreP ='" + textBox1.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }
            else if (comboBox3.Text.Equals("Apellido"))
            {
                string consultar = "EXEC dbo.BuscarPersonaParticipanteApellido @apellidoP ='" + textBox1.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
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

            string nombres = comboBox1.Text;

            string actualizarInstructor = "exec p_participanteModificar " +
                                        "@CI ='" + txtIdentificacion.Text + "', " +
                                        "@RUC =null, " +
                                        "@NOMBRE ='" + txtNombre.Text + "'," +
                                        "@APELLIDO ='" + txtApellidos.Text + "'," +
                                        "@DIRECCION ='" + txtDireccion.Text + "', " +
                                        "@FECHANACI ='" + dateTimePicker1.Text + "', " +
                                        "@TELEFONO ='" + txtTelefono.Text + "', " +
                                        "@EMAIL ='" + txtEmail.Text + "', " +
                                        "@OBSERVACION = null," +
                                        "@NOMBRETALLER ='" + nombres + "'";

            if (bd.executecommand(actualizarInstructor))
            {
                MessageBox.Show("Datos actualizados exitosamente");
                txtIdentificacion.Text = "";
                txtApellidos.Text = "";
                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                txtEmail.Text = "";
                dateTimePicker1.Value = System.DateTime.Today;
                comboBox1.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Error al actualizar");
            }
        }
        private void consulta2()
        {

            string nombres = comboBox1.Text;
            
            string actualizarInstructor = "exec p_participanteModificar " +
                                        "@CI =null, " +
                                        "@RUC ='" + txtIdentificacion.Text + "', " +
                                        "@NOMBRE ='" + txtNombre.Text + "'," +
                                        "@APELLIDO ='" + txtApellidos.Text + "'," +
                                        "@DIRECCION ='" + txtDireccion.Text + "', " +
                                        "@FECHANACI ='" + dateTimePicker1.Text + "', " +
                                        "@TELEFONO ='" + txtTelefono.Text + "', " +
                                        "@EMAIL ='" + txtEmail.Text + "', " +
                                        "@OBSERVACION = null," +
                                        "@NOMBRETALLER ='" + nombres + "'" ;

            if (bd.executecommand(actualizarInstructor))
            {
                MessageBox.Show("Datos actualizados exitosamente");
                txtIdentificacion.Text = "";
                txtApellidos.Text = "";
                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                txtEmail.Text = "";
                dateTimePicker1.Value = System.DateTime.Today;
                comboBox1.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Error al actualizar");
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
            string codTaller = dgv.Cells[7].Value.ToString();
            textBox2.Text = nom(codTaller);
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
        private string nom(string profe)
        {
            string name = bd.selectstring("select (replace(NOMBRE,' ', '')) as NOMBRES from TALLER WHERE CODTALLER =" + profe + "");
            return name;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                textBox2.Text = comboBox1.Text;
            }
        }
        private void cargarComboBox()
        {
            comboBox1.ValueMember = "NOMBRES";
            string nombreProfesores = "select (replace(NOMBRE,' ', ''))as NOMBRES from TALLER ";
            comboBox1.DataSource = bd.SelectDataTable(nombreProfesores);
        }
    }
}
