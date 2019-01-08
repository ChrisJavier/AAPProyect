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
    public partial class ModificarTaller : Form
    {
        BaseDeDatos bd = new BaseDeDatos();

        public ModificarTaller()
        {
            InitializeComponent();
            cargarComboBox();
            comboBox1.SelectedIndex = -1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CrearTallerista crearTallerista = new CrearTallerista();
            crearTallerista.Show();
            
        }

        private void pBCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            buscar();
        }
        private void buscar()
        {
            if (comboBox6.Text.Equals("Nombre"))
            {
                string consultar = "SELECT * FROM TALLER WHERE NOMBRE ='" + textBox4.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }
           
            else if (comboBox6.Text.Equals("Día"))
            {
                string consultar = "SELECT * FROM TALLER WHERE FECHA='" + textBox4.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }
            else if (comboBox6.Text.Equals("Hora"))
            {
                string consultar = "SELECT * FROM TALLER WHERE HORA ='" + textBox4.Text + "'";
                dataGridView1.DataSource = bd.SelectDataTable(consultar);
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.BringToFront();
            panel1.Location = new Point(90, 90);
            dataGridView1.DataSource = bd.SelectDataTable("SELECT * FROM TALLER");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgv = dataGridView1.Rows[e.RowIndex];
            string nombre = dgv.Cells[1].Value.ToString();
            textBox5.Text = nombreT(nombre);
            textBox1.Text = dgv.Cells[2].Value.ToString();
            textBox2.Text= dgv.Cells[3].Value.ToString();
            if (dgv.Cells[4].Value.ToString()=="")
            {
                numericUpDown1.Value = 1;
            }
            else
            {
                numericUpDown1.Value = Int32.Parse(dgv.Cells[4].Value.ToString());
                radioButton1.Checked = true;
            }
            textBox3.Text = dgv.Cells[5].Value.ToString();
            string dia = dgv.Cells[6].Value.ToString();
            comboBox2.SelectedIndex = day(dia);
            string hora = dgv.Cells[7].Value.ToString();
            comboBox3.SelectedIndex = hours(hora);
            textBox1.Enabled = false;

        }
        private string nombreT(string nom)
        {
            string nomT = bd.selectstring("select (replace(NOMBRE,' ', '')+' '+REPLACE(APELLIDO,' ', '')) as NOMBRES from TALLERISTA INNER JOIN PERSONA ON TALLERISTA.CODPERSONA=PERSONA.CODPERSONA WHERE CONTALL=" +nom+"");
            return nomT;
        }
        private int day(string dia)
        {
            string[] d = dia.Split(' ');
            int index = 0;
            if (d[0] == "Lunes")
            {
                index = 0;
            }
            else if (d[0] == "Martes")
            {
                index = 1;
            }
            else if (d[0] == "Miercoles")
            {
                index = 2;
            }
            else if (d[0] == "Jueves")
            {
                index = 3;
            }
            else if (d[0] == "Viernes")
            {
                index = 4;
            }
            else if (d[0] == "Sabados")
            {
                index = 5;
            }
            return index;
        }
        private int hours(string hora)
        {
            string[] d = hora.Split(' ');
            int index = 0;
            if (d[0] == "9-11")
            {
                index = 0;
            }
            else if (d[0] == "11-13")
            {
                index = 1;
            }
            else if (d[0] == "13-15")
            {
                index = 2;
            }
            else if (d[0] == "15-17")
            {
                index = 3;
            }
            else if (d[0] == "17-19")
            {
                index = 4;
            }
            return index;
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
            pictureBox1.Size = new Size(46, 47);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(40, 41);
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
        bool isChecked = false;
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

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.Size = new Size(43,32);
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            pictureBox7.Size = new Size(49, 38);
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.Size = new Size(49,31);
        }

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            pictureBox8.Size = new Size(55, 37);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(65, 49);
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(71, 55);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(65, 49);
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(71, 55);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                textBox4.Text = comboBox1.Text;
            }
        }

        private void guardar()
        {
            string nombres = comboBox1.Text;
            string[] profesor = nombres.Split(' ');
            string nombreP = profesor[0];
            string apellidoP = profesor[1];
            string consultarIDTallerista = bd.selectstring("select TALLERISTA.CONTALL from PERSONA inner join TALLERISTA on PERSONA.CODPERSONA = TALLERISTA.CODPERSONA where APELLIDO = '" + apellidoP + "' AND NOMBRE ='" + nombreP + "'");
            int codTaller = Int32.Parse(consultarIDTallerista);

            int cupo = Convert.ToInt32(numericUpDown1.Value);
            string actualizarTaller = "";
            if (radioButton1.Checked==true)
            {
                actualizarTaller = "EXEC dbo.ActualizarTaller " +
               "@CONTALL = " + codTaller +
               ",@NOMBRE = '" + textBox1.Text +
               "',@DESCRIPCION = '" + textBox2.Text +
               "',@CUPO=" + cupo +
               ",@MATERIALES = '" + textBox3.Text +
               "',@FECHA = '" + comboBox2.Text +
               "',@HORA = '" + comboBox3.Text + "'";
            }
            else
            {
                actualizarTaller = "EXEC dbo.ActualizarTaller " +
               "@CONTALL = " + codTaller +
               ",@NOMBRE = '" + textBox1.Text +
               "',@DESCRIPCION = '" + textBox2.Text +
               "',@CUPO=null" + 
               ",@MATERIALES = '" + textBox3.Text +
               "',@FECHA = '" + comboBox2.Text +
               "',@HORA = '" + comboBox3.Text + "'";
            }


            MessageBox.Show(actualizarTaller);
            if (bd.executecommand(actualizarTaller))
            {
                MessageBox.Show("Datos actualizados exitosamente");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
           
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                
                numericUpDown1.Value = 1;
            }
            else
            {
                MessageBox.Show("Error al actualizar");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            guardar();
        }
        private void cargarComboBox()
        {
            comboBox1.ValueMember = "NOMBRES";
            string nombreTalleristas = "select (replace(NOMBRE,' ', '')+' '+REPLACE(APELLIDO,' ', '')) as NOMBRES from TALLERISTA INNER JOIN PERSONA ON TALLERISTA.CODPERSONA=PERSONA.CODPERSONA";
            comboBox1.DataSource = bd.SelectDataTable(nombreTalleristas);
        }
    }
}
