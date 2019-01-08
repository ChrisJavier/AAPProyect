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
    public partial class CrearTaller : Form
    {
        BaseDeDatos bd = new BaseDeDatos();
        ValidarSoloLetrasSoloNumeros validar = new ValidarSoloLetrasSoloNumeros();
        public CrearTaller()
        {
            InitializeComponent();
            cargarComboBox();
            comboBox1.SelectedIndex = -1;
        }

        
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            CrearTallerista crearTallerista = new CrearTallerista();
            crearTallerista.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = openFileDialog1.FileName;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBox3.Text);
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(46, 47);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(40,41);
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.Size = new Size(46, 47);
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Size = new Size(40, 41);
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.Size = new Size(46, 47);
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Size = new Size(40, 41);
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(74, 56);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(68,50);
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(74, 56);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(68, 50);
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Size = new Size(74, 56);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Size = new Size(68, 50);
        }
        bool isChecked= false;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = radioButton1.Checked;
        }
        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked && !isChecked)
            {
                radioButton1.Checked = false;
                numericUpDown1.Enabled = false;
            }
            else
            {
                radioButton1.Checked = true;
                isChecked = false;
                numericUpDown1.Enabled = true;
            }
        }
        private void cargarComboBox()
        {
            comboBox1.ValueMember = "NOMBRES";
            string nombreTalleristas = "select (replace(NOMBRE,' ', '')+' '+REPLACE(APELLIDO,' ', '')) as NOMBRES from TALLERISTA INNER JOIN PERSONA ON TALLERISTA.CODPERSONA=PERSONA.CODPERSONA";
            comboBox1.DataSource = bd.SelectDataTable(nombreTalleristas);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            guardar();
        }
        private void guardar()
        {
            string nombreCurso = bd.selectstring("EXEC dbo.consultarNombreTaller @NOMBRE='" + textBox1.Text + "'");
            string nombres = comboBox1.Text;
            string[] profesor = nombres.Split(' ');
            string nombreP = profesor[0];
            string apellidoP = profesor[1];
            string consultarProfesor = bd.selectstring("select TALLERISTA.CONTALL from PERSONA inner join TALLERISTA on PERSONA.CODPERSONA = TALLERISTA.CODPERSONA WHERE APELLIDO='" + apellidoP + "'AND NOMBRE='" + nombreP + "'");
            int codProfesor = Int32.Parse(consultarProfesor);
            int cupo = Convert.ToInt32(numericUpDown1.Value);
            string registrarTaller = "";
            if (radioButton1.Checked==true)
            {
                registrarTaller = "dbo.registrarTaller "+
                                  "@CONTALL = "+codProfesor+","+
                                  "@NOMBRE = '"+textBox1.Text+"',"+
                                  "@DESCRIPCION ='"+textBox2.Text+"',"+
                                  "@CUPO = "+cupo+","+
                                  "@MATERIALES = '"+textBox3.Text+"',"+
                                  "@FECHA = '"+comboBox2.Text+"',"+
                                  "@HORA = '"+comboBox3.Text+"'";
            }
            else
            {
                registrarTaller = "dbo.registrarTaller "+
                                  "@CONTALL = " + codProfesor + "," +
                                  "@NOMBRE = '" + textBox1.Text + "'," +
                                  "@DESCRIPCION ='" + textBox2.Text + "'," +
                                  "@CUPO = null," +
                                  "@MATERIALES = '" + textBox3.Text + "'," +
                                  "@FECHA = '" + comboBox2.Text + "'," +
                                  "@HORA = '" + comboBox3.Text + "'"; 
            }

            if (textBox1.Text.Equals("")|| textBox2.Text.Equals("")|| textBox2.Text.Equals("")||comboBox1.Text.Equals("") || comboBox2.Text.Equals("") || comboBox3.Text.Equals(""))
            {
                MessageBox.Show("Error uno o mas campos vacios");
            }
            else
            {
                if (nombreCurso == textBox1.Text )
                {
                    MessageBox.Show("Datos ya registrados");
                }
                else
                {
                    
                    if (bd.executecommand(registrarTaller))
                    {
                        MessageBox.Show("Registrado");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        comboBox1.SelectedIndex = -1;
                        comboBox2.SelectedIndex = -1;
                        comboBox3.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar");
                    }
                }
            }
        }
    }
}
