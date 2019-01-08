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
    public partial class ModificarEstudiante : Form
    {
        public ModificarEstudiante()
        {
            InitializeComponent();
            cargarComboBox();
            comboBox1.SelectedIndex = -1;
            textBox2.Text = "";
        }

        BaseDeDatos bd = new BaseDeDatos();
        private void cargarComboBox()
        {
            comboBox1.ValueMember = "NOMBRES";
            string nombreProfesores = "select (replace(NOMBRE,' ', '')+' '+replace(NIVEL,' ', '')) AS NOMBRES from CURSO ";
            comboBox1.DataSource = bd.SelectDataTable(nombreProfesores);
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
                string consultar = "EXEC dbo.BuscarPersonaEstudianteCI @CI  ='" + textBox1.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }
            else if (comboBox3.Text.Equals("RUC"))
            {
                string consultar = "EXEC dbo.BuscarPersonaEstudianteRUC @RUC ='" + textBox1.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }
            else if (comboBox3.Text.Equals("Nombre"))
            {
                string consultar = "EXEC dbo.BuscarPersonaEstudianteNombre @nombreP ='" + textBox1.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }
            else if (comboBox3.Text.Equals("Apellido"))
            {
                string consultar = "EXEC dbo.BuscarPersonaEstudianteApellido @apellidoP ='" + textBox1.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
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
            dataGridView1.DataSource = bd.SelectDataTable("exec dbo.BuscarPersonaEstudiante");
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
            txtOcupacion.Text = dgv.Cells[9].Value.ToString();
            string nivelIngles = dgv.Cells[7].Value.ToString();
            string codcurso = dgv.Cells[8].Value.ToString();
            textBox2.Text = nom(codcurso);
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
        private string nom(string profe)
        {
            string name = bd.selectstring("select (replace(NOMBRE,' ', '')+' '+REPLACE(NIVEL,' ', '')) as NOMBRES from CURSO WHERE CODCURSO =" + profe + "");
            return name;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                textBox2.Text = comboBox1.Text;
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
            string[] profesor = nombres.Split(' ');
            string nombreP = profesor[0];
            string apellidoP = profesor[1];
            string actualizarInstructor = "exec p_estudianteModificar " +
                                        "@NIVELING ='" + comboBox2.Text + "', " +
                                        "@OCUPACION ='" + txtOcupacion.Text + "', " +
                                        "@CI ='" + txtIdentificacion.Text + "', " +
                                        "@RUC =null, " +
                                        "@NOMBRE ='" + txtNombre.Text + "'," +
                                        "@APELLIDO ='" + txtApellidos.Text + "'," +
                                        "@DIRECCION ='" + txtDireccion.Text + "', " +
                                        "@FECHANACI ='" + dateTimePicker1.Text + "', " +
                                        "@TELEFONO ='" + txtTelefono.Text + "', " +
                                        "@EMAIL ='" + txtEmail.Text + "', " +
                                        "@OBSERVACION = null," +
                                        "@NOMBRECURSO ='" + nombreP + "'," +
                                        "@NIVELCURSO = '" + apellidoP + "'";

            if (bd.executecommand(actualizarInstructor))
            {
                MessageBox.Show("Datos actualizados exitosamente");
                txtIdentificacion.Text = "";
                txtApellidos.Text = "";
                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                txtEmail.Text = "";
                txtOcupacion.Text = "";
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

            string nombres = comboBox1.Text;
            string[] profesor = nombres.Split(' ');
            string nombreP = profesor[0];
            string apellidoP = profesor[1];
            string actualizarInstructor = "exec p_estudianteModificar " +
                                        "@NIVELING ='" + comboBox2.Text + "', " +
                                        "@OCUPACION ='" + txtOcupacion.Text + "', " +
                                        "@CI =null, " +
                                        "@RUC ='" + txtIdentificacion.Text + "', " +
                                        "@NOMBRE ='" + txtNombre.Text + "'," +
                                        "@APELLIDO ='" + txtApellidos.Text + "'," +
                                        "@DIRECCION ='" + txtDireccion.Text + "', " +
                                        "@FECHANACI ='" + dateTimePicker1.Text + "', " +
                                        "@TELEFONO ='" + txtTelefono.Text + "', " +
                                        "@EMAIL ='" + txtEmail.Text + "', " +
                                        "@OBSERVACION = null," +
                                        "@NOMBRECURSO ='" + nombreP + "'," +
                                        "@NIVELCURSO = '" + apellidoP + "'";

            if (bd.executecommand(actualizarInstructor))
            {
                MessageBox.Show("Datos actualizados exitosamente");
                txtIdentificacion.Text = "";
                txtApellidos.Text = "";
                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                txtEmail.Text = "";
                txtOcupacion.Text = "";
                dateTimePicker1.Value = System.DateTime.Today;
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Error al actualizar");
            }
        }
    }
}
