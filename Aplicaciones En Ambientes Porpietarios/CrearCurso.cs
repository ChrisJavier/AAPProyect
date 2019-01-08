using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Aplicaciones_En_Ambientes_Porpietarios
{
    public partial class CrearCurso : Form
    {
        BaseDeDatos bd = new BaseDeDatos();
        ValidarSoloLetrasSoloNumeros validar = new ValidarSoloLetrasSoloNumeros();
        public CrearCurso()
        {
            InitializeComponent();
            cargarComboBox();
            dateTimePicker1.Value = System.DateTime.Today;
            dateTimePicker2.Value = System.DateTime.Today;
            dateTimePicker1.MinDate = System.DateTime.Today;
            comboBox3.SelectedIndex = -1;
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(79, 55);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(73, 49);
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Size = new Size(79, 55);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Size = new Size(73, 49);
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(79, 55);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(73, 49);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            AgregarProfesor profesor = new AgregarProfesor();
            profesor.Show();
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloLetras(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloNumeros(e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBox2.Text);
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Size = new Size(40, 41);
        }
        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.Size = new Size(46, 47);
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(40, 41);
        }
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(46, 47);
        }
        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Size = new Size(40, 41);
        }
        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.Size = new Size(46, 47);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void guardar()
        {
            consultar();
        }
        private void consultar()
        {
            string nombreCurso = bd.selectstring("EXEC DBO.cursoNombreNivel @nombre='" + textBox1.Text + "'");
            string nivelCurso = bd.selectstring("EXEC DBO.cursoNivel @nivel='" + comboBox4.Text + "'");
            string nombres = comboBox3.Text;
            string[] profesor = nombres.Split(' ');
            string nombreP = profesor[0];
            string apellidoP = profesor[1];
            string consultarProfesor = bd.selectstring("select INSTRUCTOR.CONINS from PERSONA inner join INSTRUCTOR on PERSONA.CODPERSONA = INSTRUCTOR.CODPERSONA WHERE APELLIDO='"+apellidoP+"'AND NOMBRE='"+nombreP+"'");
            int codProfesor = Int32.Parse(consultarProfesor);
            int cupo = Convert.ToInt32(numericUpDown1.Value);
            string registrarCurso = "EXEC dbo.IngresarCurso "+
                "@CONINS = "+codProfesor+
                ",@NOMBRE = '"+textBox1.Text+
                "',@NIVEL = '"+comboBox4.Text+
                "',@TIPO = '"+comboBox5.Text+
                "',@CUPO = "+cupo+
                ",@FECHAINICIO = '"+dateTimePicker1.Text+
                "',@FECHAFIN = '"+dateTimePicker2.Text+
                "',@SILABO = '"+textBox2.Text+
                "',@DIA = '"+comboBox1.Text+
                "',@HORA = '"+comboBox2.Text+
                "',@COSTO ="+textBox3.Text+"";
            if (textBox1.Text.Equals("")||textBox2.Text.Equals("")|| textBox3.Text.Equals("") || comboBox1.Text.Equals("") ||comboBox2.Text.Equals("")|| comboBox3.Text.Equals("")|| comboBox4.Text.Equals("")||comboBox5.Text.Equals("")||dateTimePicker1.Text.Equals("")||dateTimePicker2.Text.Equals(""))
            {
                MessageBox.Show("Error uno o mas campos vacios");
            }
            else
            {
                if (nombreCurso == textBox1.Text && nivelCurso==comboBox4.Text)
                {
                    MessageBox.Show("Datos ya registrados");
                }
                else
                {
                    MessageBox.Show(registrarCurso);
                    if (bd.executecommand(registrarCurso))
                    {
                        MessageBox.Show("Registrado");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        comboBox1.SelectedIndex=-1;
                        comboBox2.SelectedIndex = -1;
                        comboBox3.SelectedIndex = -1;
                        comboBox4.SelectedIndex = -1;
                        comboBox5.SelectedIndex = -1;
                        dateTimePicker1.Value = System.DateTime.Today;
                        dateTimePicker2.Value = System.DateTime.Today;
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar");
                    }
                }
            }
        }
        private void cargarComboBox()
        {
            comboBox3.ValueMember = "NOMBRES";
            string nombreProfesores = "select (replace(NOMBRE,' ', '')+' '+REPLACE(APELLIDO,' ', '')) as NOMBRES from INSTRUCTOR INNER JOIN PERSONA ON INSTRUCTOR.CODPERSONA=PERSONA.CODPERSONA";
            comboBox3.DataSource = bd.SelectDataTable(nombreProfesores);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateTime = new DateTime();
            dateTime = dateTimePicker1.Value;
            dateTimePicker2.MinDate = dateTime;
        }

        private void CrearCurso_MouseMove(object sender, MouseEventArgs e)
        {
                        
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
