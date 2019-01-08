using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Aplicaciones_En_Ambientes_Porpietarios
{
    public partial class ActualizarRecorrido : Form
    {
        ValidarSoloLetrasSoloNumeros validar = new ValidarSoloLetrasSoloNumeros();
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        DataTable dt;
        int filaSeleccionada = 0;
        double LatInicial = -0.210319;
        double LngInicial = -78.489065;
        int NumParada = 0;
        string Nombre = "";
        string Descripcion = "";
        public ActualizarRecorrido()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(42, 43);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(38, 39);
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void ActualizarRecorrido_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Nombre", typeof(String)));
            dt.Columns.Add(new DataColumn("Descripción", typeof(String)));
            dt.Columns.Add(new DataColumn("Número de Parada", typeof(int)));
            dt.Columns.Add(new DataColumn("Latitud", typeof(double)));
            dt.Columns.Add(new DataColumn("Longitud", typeof(double)));
           // dt.Rows.Add("Epn", "Facultad de Sistemas", NumParada, LatInicial, LngInicial);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;

            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(LatInicial, LngInicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;

            //Marcador
            markerOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(LatInicial, LngInicial), GMarkerGoogleType.blue);
            markerOverlay.Markers.Add(marker);

            /*ToolTip de Texto
            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = string.Format("Nombre: {0}\n Descripción: {1} \n ", Nombre, Descripcion);
			*/
            //Agregar al mapa
            gMapControl1.Overlays.Add(markerOverlay);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloLetras(e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloLetras(e);
        }

        private void txtNumParada_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloNumeros(e);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
