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
    public partial class ModuloClientes : Form
    {
        public ModuloClientes()
        {
            InitializeComponent();
        }

        private void nuevoTallerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearEstudiante crearEstudiante = new CrearEstudiante();
            crearEstudiante.TopLevel = false;
            crearEstudiante.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Size = new Size(763, 420);
            panel1.Location = new Point(50, 100);
            panel1.Controls.Add(crearEstudiante);
            crearEstudiante.Dock = DockStyle.Left;
            crearEstudiante.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            crearEstudiante.Show();
        }

        private void nuevoTalleristaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearParticipante crearParticipante = new CrearParticipante();
            crearParticipante.TopLevel = false;
            crearParticipante.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(crearParticipante);
            crearParticipante.Dock = DockStyle.Left;
            crearParticipante.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            crearParticipante.Show();
        }

        private void nuevoTuristaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearTurista crearTurista = new CrearTurista();
            crearTurista.TopLevel = false;
            crearTurista.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(crearTurista);
            crearTurista.Dock = DockStyle.Left;
            crearTurista.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            crearTurista.Show();
        }

        private void modificarTallerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarEstudiante modificarEstudiante = new ModificarEstudiante();
            modificarEstudiante.TopLevel = false;
            modificarEstudiante.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(modificarEstudiante);
            modificarEstudiante.Dock = DockStyle.Left;
            modificarEstudiante.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            modificarEstudiante.Show();
        }

        private void modificarTalleristaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarParticipante modificarParticipante = new ModificarParticipante();
            modificarParticipante.TopLevel = false;
            modificarParticipante.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(modificarParticipante);
            modificarParticipante.Dock = DockStyle.Left;
            modificarParticipante.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            modificarParticipante.Show();
        }

        private void modificarTuristaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarTurista modificarTurista = new ModificarTurista();
            modificarTurista.TopLevel = false;
            modificarTurista.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(modificarTurista);
            modificarTurista.Dock = DockStyle.Left;
            modificarTurista.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            modificarTurista.Show();
        }

        private void pBCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Menu mainMenu = new Menu();
            mainMenu.Show();
            this.Hide();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Menu mainMenu = new Menu();
            mainMenu.Show();
            this.Hide();
        }
    }
}
