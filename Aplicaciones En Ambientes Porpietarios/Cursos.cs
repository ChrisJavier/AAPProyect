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
    public partial class Cursos : Form
    {
        public Cursos()
        {
            InitializeComponent();
            
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarProfesor modificarCurso = new ModificarProfesor();
            modificarCurso.TopLevel = false;
            modificarCurso.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(modificarCurso);
            modificarCurso.Dock = DockStyle.Left;
            modificarCurso.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            modificarCurso.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Menu mainMenu = new Menu();
            mainMenu.Show();
            this.Hide();

        }

        private void ingresarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearCurso cursoNuevo = new CrearCurso();
            cursoNuevo.TopLevel = false;
            cursoNuevo.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(cursoNuevo);
            cursoNuevo.Dock = DockStyle.Left;
            cursoNuevo.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            cursoNuevo.Show();
            
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoEstudiante alumnoNuevo = new NuevoEstudiante();
            alumnoNuevo.TopLevel = false;
            alumnoNuevo.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(alumnoNuevo);
            alumnoNuevo.Dock = DockStyle.Left;
            alumnoNuevo.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            alumnoNuevo.Show();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(54,54);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(48, 48);
        }

        private void actualizarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarCurso modificarCurso = new ModificarCurso();
            modificarCurso.TopLevel = false;
            modificarCurso.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(modificarCurso);
            modificarCurso.Dock = DockStyle.Left;
            modificarCurso.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            modificarCurso.Show();
        }

        private void buscarProfesoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarProfesor buscarProfesor = new BuscarProfesor();
            buscarProfesor.TopLevel = false;
            buscarProfesor.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(buscarProfesor);
            buscarProfesor.Dock = DockStyle.Left;
            buscarProfesor.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            buscarProfesor.Show();
        }

        private void buscarCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarCurso buscarCurso = new BuscarCurso();
            buscarCurso.TopLevel = false;
            buscarCurso.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(buscarCurso);
            buscarCurso.Dock = DockStyle.Left;
            buscarCurso.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            buscarCurso.Show();
        }

        private void asignarAlCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarProfesor buscarCurso = new AgregarProfesor();
            buscarCurso.TopLevel = false;
            buscarCurso.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(buscarCurso);
            buscarCurso.Dock = DockStyle.Left;
            buscarCurso.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            buscarCurso.Show();
        }

        private void eliminarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            EliminarProfesor eliminarProfesor = new EliminarProfesor();
            eliminarProfesor.TopLevel = false;
            eliminarProfesor.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(eliminarProfesor);
            eliminarProfesor.Dock = DockStyle.Left;
            eliminarProfesor.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            eliminarProfesor.Show();
        }

        private void alumnosPorCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportesAlumnos reportesAlumnos = new ReportesAlumnos();
            reportesAlumnos.TopLevel = false;
            reportesAlumnos.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(reportesAlumnos);
            reportesAlumnos.Dock = DockStyle.Left;
            reportesAlumnos.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            reportesAlumnos.Show();
        }

        private void profesorPorCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportesProfesores reportesProfesores = new ReportesProfesores();
            reportesProfesores.TopLevel = false;
            reportesProfesores.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(reportesProfesores);
            reportesProfesores.Dock = DockStyle.Left;
            reportesProfesores.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            reportesProfesores.Show();
        }

        private void horariosDeCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportesHorarios reportesHorarios = new ReportesHorarios();
            reportesHorarios.TopLevel = false;
            reportesHorarios.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(reportesHorarios);
            reportesHorarios.Dock = DockStyle.Left;
            reportesHorarios.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            reportesHorarios.Show();
        }

        private void estudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eliminarCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarCurso eliminarNuevo = new EliminarCurso();
            eliminarNuevo.TopLevel = false;
            eliminarNuevo.AutoScroll = true;
            panel1.Controls.Clear();
            panel1.Controls.Add(eliminarNuevo);
            eliminarNuevo.Dock = DockStyle.Left;
            eliminarNuevo.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            eliminarNuevo.Show();
        }
    }
}
