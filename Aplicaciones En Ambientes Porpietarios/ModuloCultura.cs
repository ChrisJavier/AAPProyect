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
    public partial class ModuloCultura : Form
    {
        public ModuloCultura()
        {
            InitializeComponent();
        }

        private void tallerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevoTallerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearTaller crearTaller = new CrearTaller();
            crearTaller.TopLevel = false;
            crearTaller.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Size = new Size(748, 409);
            panel1.Location = new Point(100, 50);
            panel1.Controls.Add(crearTaller);
            crearTaller.Dock = DockStyle.Left;
            crearTaller.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            crearTaller.Show();
        }

        private void modificarTallerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarTaller modificarTaller = new ModificarTaller();
            modificarTaller.TopLevel = false;
            modificarTaller.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Size = new Size(756, 420);
            panel1.Location = new Point(100, 50);
            panel1.Controls.Add(modificarTaller);
            modificarTaller.Dock = DockStyle.Left;
            modificarTaller.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            modificarTaller.Show();
        }

        private void eliminarTallerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarTaller eliminarTaller = new BuscarTaller();
            eliminarTaller.TopLevel = false;
            eliminarTaller.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Size = new Size(693, 402);
            panel1.Location = new Point(100, 50);
            panel1.Controls.Add(eliminarTaller);
            eliminarTaller.Dock = DockStyle.Left;
            eliminarTaller.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            eliminarTaller.Show();
        }

        private void nuevoTalleristaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearTallerista crearTallerista = new CrearTallerista();
            crearTallerista.TopLevel = false;
            crearTallerista.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Size = new Size(784, 440);
            panel1.Location = new Point(50,50);
            panel1.Controls.Add(crearTallerista);
            crearTallerista.Dock = DockStyle.Left;
            crearTallerista.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            crearTallerista.Show();
        }

        private void modificarTalleristaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarTallerista modificarTallerista = new ModificarTallerista();
            modificarTallerista.TopLevel = false;
            modificarTallerista.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Size = new Size(666, 411);
            panel1.Location = new Point(100,50);
            panel1.Controls.Add(modificarTallerista);
            modificarTallerista.Dock = DockStyle.Left;
            modificarTallerista.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            modificarTallerista.Show();
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
    }
}
