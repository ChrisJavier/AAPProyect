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
    public partial class NuevoGuia : Form
    {
        BaseDeDatos bd = new BaseDeDatos();
        ValidarSoloLetrasSoloNumeros validar = new ValidarSoloLetrasSoloNumeros();
        public NuevoGuia()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            txtIdentificacion.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
        }

        private void txtIdentificacion_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true && txtIdentificacion.TextLength == 10)
            {
                if (validar.VerificarCedula(txtIdentificacion.Text) == true)
                {
                    pictureBox1.Visible = false;
                    txtNombre.Enabled = true;
                    txtApellidos.Enabled = true;
                    txtDireccion.Enabled = true;
                    txtEmail.Enabled = true;
                    txtTelefono.Enabled = true;
                    dateTimePicker1.Enabled = true;
                    textSueldo.Enabled = true;
                }
                else
                {
                    pictureBox1.Visible = true;
                    MessageBox.Show("Cédula de identidad incorrecta");
                    txtNombre.Enabled = false;
                    txtApellidos.Enabled = false;
                    txtDireccion.Enabled = false;
                    txtEmail.Enabled = false;
                    txtTelefono.Enabled = false;
                    textSueldo.Enabled = false;
                    dateTimePicker1.Enabled = false;
                }
            }
            if (radioButton2.Checked == true && txtIdentificacion.TextLength == 13)
            {
                string cadena = txtIdentificacion.Text;

                String aux = cadena.Substring(10, 3);
                string parte1 = cadena.Substring(0, 10);
                if (txtIdentificacion.TextLength != 13 || aux.Length != 3 || !aux.Contains("001") || !validar.VerificarCedula(parte1))
                {
                    pictureBox1.Visible = true;
                    MessageBox.Show("RUC incorrecto");
                    txtNombre.Enabled = false;
                    txtApellidos.Enabled = false;
                    txtDireccion.Enabled = false;
                    txtEmail.Enabled = false;
                    txtTelefono.Enabled = false;
                    textSueldo.Enabled = false;
                    dateTimePicker1.Enabled = false;

                }
                else
                {
                    pictureBox1.Visible = false;
                    txtNombre.Enabled = true;
                    txtApellidos.Enabled = true;
                    txtDireccion.Enabled = true;
                    txtEmail.Enabled = true;
                    txtTelefono.Enabled = true;
                    textSueldo.Enabled = true;
                    dateTimePicker1.Enabled = true;
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void txtIdentificacion_Leave(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true && txtIdentificacion.TextLength != 10)
            {
                MessageBox.Show("Cédula de identidad no válida");
                txtIdentificacion.Text = "";
            }
            if (radioButton2.Checked == true && txtIdentificacion.TextLength != 13)
            {
                MessageBox.Show("RUC no válido");
                txtIdentificacion.Text = "";
            }

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloLetras(e);
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloLetras(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloNumeros(e);
        }

        private void textSueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.NumerosDecimal(e);
        }
        private void guardar()
        {
            if (radioButton1.Checked == true && radioButton2.Checked == false)
            {
                if (validar.VerificarCedula(txtIdentificacion.Text))
                {
                    consultar1();
                }
                else
                {
                    MessageBox.Show("Cédula de Identidad no válida");
                }

            }
            else if (radioButton2.Checked == true && radioButton1.Checked == false)
            {
                consultar2();
            }
            else
            {
                MessageBox.Show("Seleccione un opción en la identificación");
            }
        }
        private void consultar1()
        {
            string consultarPersona = bd.selectstring("select CI from PERSONA WHERE CI = '" + txtIdentificacion.Text + "'");
            string ingresarInstructor = "EXEC dbo.InsertarPersonaGuia @CI = '" + txtIdentificacion.Text + "', @RUC = null," +
                " @nombreP = '" + txtNombre.Text + "', @apellidoP = '" + txtApellidos.Text + "', " +
                "@direccionP = '" + txtDireccion.Text + "', @fechaNaciP = '" + dateTimePicker1.Text + "', " +
                "@telefonoP = '" + txtTelefono.Text + "', @emailP = '" + txtEmail.Text + "'," +
                " @observacionP = null, @cobreI = '" + textSueldo.Text +  "'";
            if (txtIdentificacion.Text.Equals("") || txtNombre.Text.Equals("") || txtApellidos.Text.Equals("") || txtDireccion.Text.Equals("") || dateTimePicker1.Text.Equals("") || txtTelefono.Text.Equals("") || textSueldo.Text.Equals("")  || txtEmail.Text.Equals("") )
            {
                MessageBox.Show("Error uno o mas campos vacios");
            }
            else
            {
                if (consultarPersona == txtIdentificacion.Text)
                {
                    MessageBox.Show("Datos ya registrados");
                }
                else
                {
                    MessageBox.Show(ingresarInstructor);
                    if (bd.executecommand(ingresarInstructor))
                    {
                        MessageBox.Show("Registrado");
                        txtIdentificacion.Text = "";
                        txtApellidos.Text = "";
                        txtNombre.Text = "";
                        txtDireccion.Text = "";
                        dateTimePicker1.Text = "";
                        txtTelefono.Text = "";
                        txtEmail.Text = "";
                        textSueldo.Text = "";
                     
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar");
                    }
                }
            }
        }
        private void consultar2()
        {
            string consultarPersona = bd.selectstring("select RUC from PERSONA RUC = '" + txtIdentificacion.Text + "'");
            string ingresarInstructor = "EXEC dbo.InsertarPersonaGuia @CI = null, @RUC = '" + txtIdentificacion.Text + "'," +
                " @nombreP = '" + txtNombre.Text + "', @apellidoP = '" + txtApellidos.Text + "', " +
                "@direccionP = '" + txtDireccion.Text + "', @fechaNaciP = '" + dateTimePicker1.Text + "', " +
                "@telefonoP = '" + txtTelefono.Text + "', @emailP = '" + txtEmail.Text + "'," +
                " @observacionP = null, @cobreI = '" + textSueldo.Text + "'";
            if (txtIdentificacion.Text.Equals("") || txtNombre.Text.Equals("") || txtApellidos.Text.Equals("") || txtDireccion.Text.Equals("") || dateTimePicker1.Text.Equals("") || txtTelefono.Text.Equals("") || textSueldo.Text.Equals("") || txtEmail.Text.Equals("") )
            {
                MessageBox.Show("Error uno o mas campos vacios");
            }
            else
            {
                if (consultarPersona == txtIdentificacion.Text)
                {
                    MessageBox.Show("Datos ya registrados");
                }
                else
                {
                    MessageBox.Show(ingresarInstructor);
                    if (bd.executecommand(ingresarInstructor))
                    {
                        MessageBox.Show("Registrado");
                        txtIdentificacion.Text = "";
                        txtApellidos.Text = "";
                        txtNombre.Text = "";
                        txtDireccion.Text = "";
                        dateTimePicker1.Text = "";
                        txtTelefono.Text = "";
                        txtEmail.Text = "";
                        textSueldo.Text = "";
                    
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar");
                    }
                }
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            txtTelefono.MaxLength = 15;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            guardar();
        }
    }

}
