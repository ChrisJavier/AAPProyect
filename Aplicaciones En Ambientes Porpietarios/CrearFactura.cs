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
    public partial class CrearFactura : Form
    {
        BaseDeDatos bd = new BaseDeDatos();
        ValidarSoloLetrasSoloNumeros validar = new ValidarSoloLetrasSoloNumeros();
        
        public CrearFactura()
        {
            InitializeComponent();
            double subTotal = suma();
            double iv = iva(subTotal);
            double tot = total(iv, subTotal);
            textBox6.Text = subTotal.ToString();
            textBox7.Text = iv.ToString();
            textBox8.Text = tot.ToString();
        }
        int filaSelecciona=0;
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Location = new Point(199, 155);
            if (radioButton1.Checked==true&& radioButton2.Checked == false)
            {
                dataGridView2.DataSource = bd.SelectDataTable("select CI,RUC,NOMBRE,APELLIDO,DIRECCION,TELEFONO from PERSONA where CI='" + txtIdentificacion.Text + "'");
            }
            else if (radioButton2.Checked==true&& radioButton1.Checked == false)
            {
                dataGridView2.DataSource = bd.SelectDataTable("select CI,RUC,NOMBRE,APELLIDO,DIRECCION,TELEFONO from PERSONA where RUC='" + txtIdentificacion.Text + "'");
            }

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel2.Location = new Point(199, 155);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel3.Location = new Point(408, 88);
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(73, 58);
            panel3.Visible = true;
            panel3.Location = new Point(408, 88);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(67, 52);
            
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Size = new Size(73, 58);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Size = new Size(67, 52);
        }

        private void panel3_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void pictureBox14_MouseHover(object sender, EventArgs e)
        {
            pictureBox14.Size = new Size(76, 69);
        }

        private void pictureBox14_MouseLeave(object sender, EventArgs e)
        {
            pictureBox14.Size = new Size(70, 63);
        }
        private void pictureBox12_MouseHover(object sender, EventArgs e)
        {
            pictureBox12.Size = new Size(76, 69);
        }

        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {
            pictureBox12.Size = new Size(70, 63);
        }
        private void pictureBox13_MouseHover(object sender, EventArgs e)
        {
            pictureBox13.Size = new Size(76, 69);
        }

        private void pictureBox13_MouseLeave(object sender, EventArgs e)
        {
            pictureBox13.Size = new Size(70, 63);
        }
        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(58, 45);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(52, 39);
        }
        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.Size = new Size(45, 38);
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Size = new Size(39, 32);
        }

        
        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            pictureBox10.Size = new Size(70, 63);
        }
        private void pictureBox10_MouseHover(object sender, EventArgs e)
        {
            pictureBox10.Size = new Size(76, 69);
        }
        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            pictureBox11.Size = new Size(70, 63);
        }
        private void pictureBox11_MouseHover(object sender, EventArgs e)
        {
            pictureBox11.Size = new Size(76, 69);
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Size = new Size(43, 32); 
        }
        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.Size = new Size(49, 38);
        }

        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            pictureBox8.Size = new Size(49, 38);
        }
        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.Size = new Size(43, 32);
        }
        
        private void pictureBox16_MouseLeave(object sender, EventArgs e)
        {
            pictureBox16.Size = new Size(35, 33);
        }
        private void pictureBox16_MouseHover(object sender, EventArgs e)
        {
            pictureBox16.Size = new Size(41, 39);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloNumeros(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloNumeros(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloLetras(e);
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloLetras(e);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            CrearParticipante participante = new CrearParticipante();
            participante.Show();
            panel3.Visible = false;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            CrearTurista turista = new CrearTurista();
            turista.Show();
            panel3.Visible = false;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            CrearEstudiante estudiante = new CrearEstudiante();
            estudiante.Show();
            panel3.Visible = false;
        }

        

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = bd.SelectDataTable("select (replace(CURSO.NOMBRE,' ', '')+' '+REPLACE(CURSO.NIVEL,' ', '')) as NOMBRES,COSTO from PERSONA inner join ESTUDIANTE on ESTUDIANTE.CODPERSONA= PERSONA.CODPERSONA inner join CURSO on CURSO.CODCURSO= ESTUDIANTE.CODCURSO where CI='" + txtIdentificacion.Text + "'OR RUC='" + txtIdentificacion.Text + "'");
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = bd.SelectDataTable("select(replace(RECORRIDO.NOMBRE, ' ', '')) as NOMBRES,PRECIO from PERSONA inner join TURISTA on TURISTA.CODPERSONA = PERSONA.CODPERSONA inner join RECORRIDO on RECORRIDO.CODRECORRIDO = TURISTA.CODRECORRIDO where CI='"+txtIdentificacion.Text+"'OR RUC='"+txtIdentificacion.Text+"'");
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgv = dataGridView2.Rows[e.RowIndex];
            txtNombre.Text = dgv.Cells[2].Value.ToString();
            txtApellidos.Text = dgv.Cells[3].Value.ToString();
            txtDireccion.Text = dgv.Cells[4].Value.ToString();
            txtTelefono.Text= dgv.Cells[5].Value.ToString();
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
            txtIdentificacion.Enabled = false;
            txtNombre.Enabled = false;
            txtApellidos.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
        }

       

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgv = dataGridView3.Rows[e.RowIndex];
            string cantidad = "1";
            string descricion = dgv.Cells[0].Value.ToString();
            string precio = dgv.Cells[1].Value.ToString();
            dataGridView1.Rows.Add(cantidad,descricion,precio);
            double subTotal = suma();
            double iv = iva(subTotal);
            double tot = total(iv, subTotal);
            textBox6.Text = subTotal.ToString();
            textBox7.Text = iv.ToString();
            textBox8.Text = tot.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            filaSelecciona = e.RowIndex;
            double subTotal = suma();
            double iv = iva(subTotal);
            double tot = total(iv, subTotal);
            textBox6.Text = subTotal.ToString();
            textBox7.Text = iv.ToString();
            textBox8.Text = tot.ToString();

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(filaSelecciona);
            
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            
        }
        private double iva (double valor)
        {
            double iva = 0;
            iva = (valor * 12)/100;
            return iva;
        }

        private double total (double iva, double subtotal)
        {
            double total = 0;
            total = subtotal + iva;
            return total;
        }

        private double suma()
        {
            const int columna = 2;

            double suma = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                suma += Double.Parse (row.Cells[columna].Value.ToString());
            }
            return suma;
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            string pago = textBox8.Text;
            string[] sueldo = pago.Split(',');
            string salario = sueldo[0] + "." + sueldo[1];
            string ingresarFactura = "";
            string selectCODPARTIC = "";
            string selectCONDTURI = "";
            string selectCODE = "";
            if (radioButton1.Checked==true&& radioButton2.Checked == false)
            {
                selectCODE = bd.selectstring("select CODE from ESTUDIANTE INNER JOIN PERSONA ON PERSONA.CODPERSONA= TURISTA.CODPERSONA WHERE CI='" + txtIdentificacion.Text + "' OR RUC=''");
                selectCONDTURI = bd.selectstring("select CONDTURI from TURISTA INNER JOIN PERSONA ON PERSONA.CODPERSONA= TURISTA.CODPERSONA WHERE CI='" + txtIdentificacion.Text + "' OR RUC=''");
                selectCODPARTIC = bd.selectstring("select CODPARTIC from PARTICIPANTE INNER JOIN PERSONA ON PERSONA.CODPERSONA= PARTICIPANTE.CODPERSONA WHERE CI='" + txtIdentificacion.Text + "' OR RUC=''");
                if (selectCODE.Equals(""))
                {
                    selectCODE = "null";
                }
                if (selectCODPARTIC.Equals(""))
                {
                    selectCODPARTIC = "null";
                }
                if (selectCONDTURI.Equals(""))
                {
                    selectCONDTURI = "null";
                }
                ingresarFactura = "exec  dbo.facturar " +
                                         "@CONDTURI =" + selectCONDTURI + ", " +
                                         "@CODPARTIC =" + selectCODPARTIC + ", " +
                                         "@CODE =" + selectCODE + ", " +
                                         "@FECHA ='" + dateTimePicker1.Text + "', " +
                                         "@TOTAL =" + salario + "";
            }else if (radioButton2.Checked == true && radioButton1.Checked == false)
            {
                selectCODE = bd.selectstring("select CODE from ESTUDIANTE INNER JOIN PERSONA ON PERSONA.CODPERSONA= TURISTA.CODPERSONA WHERE CI='' OR RUC='" + txtIdentificacion.Text + "'");
                selectCONDTURI = bd.selectstring("select CONDTURI from TURISTA INNER JOIN PERSONA ON PERSONA.CODPERSONA= TURISTA.CODPERSONA WHERE CI='' OR RUC='" + txtIdentificacion.Text + "'");
                selectCODPARTIC = bd.selectstring("select CODPARTIC from PARTICIPANTE INNER JOIN PERSONA ON PERSONA.CODPERSONA= PARTICIPANTE.CODPERSONA WHERE CI='' OR RUC='" + txtIdentificacion.Text + "'");
                if (selectCODE.Equals(""))
                {
                    selectCODE = "null";
                }
                if (selectCODPARTIC.Equals(""))
                {
                    selectCODPARTIC = "null";
                }
                if (selectCONDTURI.Equals(""))
                {
                    selectCONDTURI = "null";
                }
                ingresarFactura = "exec  dbo.facturar " +
                                         "@CONDTURI =" + selectCONDTURI + ", " +
                                         "@CODPARTIC =" + selectCODPARTIC + ", " +
                                         "@CODE =" + selectCODE + ", " +
                                         "@FECHA ='" + dateTimePicker1.Text + "', " +
                                         "@TOTAL =" + salario + "";
            }
            
            MessageBox.Show(ingresarFactura);
            if (bd.executecommand(ingresarFactura))
            {
                MessageBox.Show("Registrado");
                txtIdentificacion.Text = "";
                txtNombre.Text = "";
                txtApellidos.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                dataGridView1.Refresh();
                txtIdentificacion.Enabled = true;
                txtNombre.Enabled = true;
                txtApellidos.Enabled = true;
                txtDireccion.Enabled = true;
                txtTelefono.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error al agregar");
            }
        }
    }
}
