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
    public partial class CrearTurista : Form
    {
        BaseDeDatos bd = new BaseDeDatos();
        ValidarSoloLetrasSoloNumeros validar = new ValidarSoloLetrasSoloNumeros();
        public CrearTurista()
        {
            InitializeComponent();
            cargarComboBox();
            comboBox1.SelectedIndex = -1;
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



        private void txtIdentificacion_TextChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true && txtIdentificacion.TextLength == 10)
            {
                if (validar.VerificarCedula(txtIdentificacion.Text) == true)
                {

                    txtNombre.Enabled = true;
                    txtApellidos.Enabled = true;
                    txtDireccion.Enabled = true;
                    txtEmail.Enabled = true;
                    txtTelefono.Enabled = true;
                    dateTimePicker1.Enabled = true;
                }
                else
                {

                    MessageBox.Show("Cédula de identidad incorrecta");
                    txtNombre.Enabled = false;
                    txtApellidos.Enabled = false;
                    txtDireccion.Enabled = false;
                    txtEmail.Enabled = false;
                    txtTelefono.Enabled = false;
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

                    MessageBox.Show("RUC incorrecto");
                    txtNombre.Enabled = false;
                    txtApellidos.Enabled = false;
                    txtDireccion.Enabled = false;
                    txtEmail.Enabled = false;
                    txtTelefono.Enabled = false;
                    dateTimePicker1.Enabled = false;

                }
                else
                {

                    txtNombre.Enabled = true;
                    txtApellidos.Enabled = true;
                    txtDireccion.Enabled = true;
                    txtEmail.Enabled = true;
                    txtTelefono.Enabled = true;
                    dateTimePicker1.Enabled = true;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txtIdentificacion.Text = "";
            txtApellidos.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
        }
        private void txtIdentificacion_Leave(object sender, EventArgs e)
        {

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
        private void cargarComboBox()
        {
            comboBox1.ValueMember = "NOMBRES";
            string nombreProfesores = "select (replace(NOMBRE,' ', ''))as NOMBRES from RECORRIDO ";
            comboBox1.DataSource = bd.SelectDataTable(nombreProfesores);
        }
        private void consultar1()
        {
            string consultarPersona = bd.selectstring("select CI from PERSONA WHERE CI = '" + txtIdentificacion.Text + "'");
            string consultarPer = bd.selectstring("select CODPERSONA from PERSONA WHERE CI = '" + txtIdentificacion.Text + "'");
            string nombres = comboBox1.Text;

            string ingresarInstructor = "exec p_turistaRegistrar " +
                                        "@CI ='" + txtIdentificacion.Text + "', " +
                                        "@RUC =null, " +
                                        "@NOMBRE ='" + txtNombre.Text + "'," +
                                        "@APELLIDO ='" + txtApellidos.Text + "'," +
                                        "@DIRECCION ='" + txtDireccion.Text + "', " +
                                        "@FECHANACI ='" + dateTimePicker1.Text + "', " +
                                        "@TELEFONO ='" + txtTelefono.Text + "', " +
                                        "@EMAIL ='" + txtEmail.Text + "', " +
                                        "@OBSERVACION = null," +
                                        "@NOMBRERECORRIDO ='" + nombres + "'";

            if (txtIdentificacion.Text.Equals("") || txtNombre.Text.Equals("") || txtApellidos.Text.Equals("") || txtDireccion.Text.Equals("") || dateTimePicker1.Text.Equals("") || txtTelefono.Text.Equals("") || comboBox1.Text.Equals("") || txtEmail.Text.Equals(""))
            {
                MessageBox.Show("Error uno o mas campos vacios");
            }
            else
            {
                if (consultarPersona == txtIdentificacion.Text)
                {
                    MessageBox.Show("Error");
                }
                else
                {
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
                        comboBox1.SelectedIndex = -1;
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
            string consultarPersona = bd.selectstring("select CI from PERSONA WHERE CI = '" + txtIdentificacion.Text + "'");
            string consultarPer = bd.selectstring("select CODPERSONA from PERSONA WHERE CI = '" + txtIdentificacion.Text + "'");
            string nombres = comboBox1.Text;

            string ingresarInstructor = "exec p_turistaRegistrar " +
                                        "@CI =null, " +
                                        "@RUC ='" + txtIdentificacion.Text + "', " +
                                        "@NOMBRE ='" + txtNombre.Text + "'," +
                                        "@APELLIDO ='" + txtApellidos.Text + "'," +
                                        "@DIRECCION ='" + txtDireccion.Text + "', " +
                                        "@FECHANACI ='" + dateTimePicker1.Text + "', " +
                                        "@TELEFONO ='" + txtTelefono.Text + "', " +
                                        "@EMAIL ='" + txtEmail.Text + "', " +
                                        "@OBSERVACION = null," +
                                        "@NOMBRERECORRIDO ='" + nombres + "'";
            if (txtIdentificacion.Text.Equals("") || txtNombre.Text.Equals("") || txtApellidos.Text.Equals("") || txtDireccion.Text.Equals("") || dateTimePicker1.Text.Equals("") || txtTelefono.Text.Equals("") || comboBox1.Text.Equals("") || txtEmail.Text.Equals(""))
            {
                MessageBox.Show("Error uno o mas campos vacios");
            }
            else
            {
                if (consultarPersona == txtIdentificacion.Text)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    
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
                        comboBox1.SelectedIndex = -1;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            guardar();
        }
    }
}
