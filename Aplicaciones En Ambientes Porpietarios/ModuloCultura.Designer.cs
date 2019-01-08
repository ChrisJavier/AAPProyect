namespace Aplicaciones_En_Ambientes_Porpietarios
{
    partial class ModuloCultura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuloCultura));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tallerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoTallerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarTallerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.talleristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoTalleristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarTalleristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.eliminarTallerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarTalleristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.talleristaToolStripMenuItem,
            this.tallerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(890, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tallerToolStripMenuItem
            // 
            this.tallerToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.tallerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoTallerToolStripMenuItem,
            this.modificarTallerToolStripMenuItem,
            this.eliminarTallerToolStripMenuItem});
            this.tallerToolStripMenuItem.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.tallerToolStripMenuItem.Name = "tallerToolStripMenuItem";
            this.tallerToolStripMenuItem.Size = new System.Drawing.Size(85, 32);
            this.tallerToolStripMenuItem.Text = "Talleres";
            this.tallerToolStripMenuItem.Click += new System.EventHandler(this.tallerToolStripMenuItem_Click);
            // 
            // nuevoTallerToolStripMenuItem
            // 
            this.nuevoTallerToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.nuevoTallerToolStripMenuItem.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.nuevoTallerToolStripMenuItem.Name = "nuevoTallerToolStripMenuItem";
            this.nuevoTallerToolStripMenuItem.Size = new System.Drawing.Size(212, 32);
            this.nuevoTallerToolStripMenuItem.Text = "Registrar Taller";
            this.nuevoTallerToolStripMenuItem.Click += new System.EventHandler(this.nuevoTallerToolStripMenuItem_Click);
            // 
            // modificarTallerToolStripMenuItem
            // 
            this.modificarTallerToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.modificarTallerToolStripMenuItem.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.modificarTallerToolStripMenuItem.Name = "modificarTallerToolStripMenuItem";
            this.modificarTallerToolStripMenuItem.Size = new System.Drawing.Size(212, 32);
            this.modificarTallerToolStripMenuItem.Text = "Modificar Taller";
            this.modificarTallerToolStripMenuItem.Click += new System.EventHandler(this.modificarTallerToolStripMenuItem_Click);
            // 
            // talleristaToolStripMenuItem
            // 
            this.talleristaToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.talleristaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoTalleristaToolStripMenuItem,
            this.modificarTalleristaToolStripMenuItem,
            this.buscarTalleristaToolStripMenuItem});
            this.talleristaToolStripMenuItem.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.talleristaToolStripMenuItem.Name = "talleristaToolStripMenuItem";
            this.talleristaToolStripMenuItem.Size = new System.Drawing.Size(105, 32);
            this.talleristaToolStripMenuItem.Text = "Talleristas";
            // 
            // nuevoTalleristaToolStripMenuItem
            // 
            this.nuevoTalleristaToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.nuevoTalleristaToolStripMenuItem.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.nuevoTalleristaToolStripMenuItem.Name = "nuevoTalleristaToolStripMenuItem";
            this.nuevoTalleristaToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.nuevoTalleristaToolStripMenuItem.Text = "Registrar Tallerista";
            this.nuevoTalleristaToolStripMenuItem.Click += new System.EventHandler(this.nuevoTalleristaToolStripMenuItem_Click);
            // 
            // modificarTalleristaToolStripMenuItem
            // 
            this.modificarTalleristaToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.modificarTalleristaToolStripMenuItem.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.modificarTalleristaToolStripMenuItem.Name = "modificarTalleristaToolStripMenuItem";
            this.modificarTalleristaToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.modificarTalleristaToolStripMenuItem.Text = "Modificar Tallerista";
            this.modificarTalleristaToolStripMenuItem.Click += new System.EventHandler(this.modificarTalleristaToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(12, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(866, 437);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(842, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // eliminarTallerToolStripMenuItem
            // 
            this.eliminarTallerToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.eliminarTallerToolStripMenuItem.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.eliminarTallerToolStripMenuItem.Name = "eliminarTallerToolStripMenuItem";
            this.eliminarTallerToolStripMenuItem.Size = new System.Drawing.Size(212, 32);
            this.eliminarTallerToolStripMenuItem.Text = "Buscar Taller";
            this.eliminarTallerToolStripMenuItem.Click += new System.EventHandler(this.eliminarTallerToolStripMenuItem_Click);
            // 
            // buscarTalleristaToolStripMenuItem
            // 
            this.buscarTalleristaToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.buscarTalleristaToolStripMenuItem.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.buscarTalleristaToolStripMenuItem.Name = "buscarTalleristaToolStripMenuItem";
            this.buscarTalleristaToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.buscarTalleristaToolStripMenuItem.Text = "Buscar Tallerista";
            // 
            // ModuloCultura
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(890, 503);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModuloCultura";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ModuloCultura";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tallerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem talleristaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoTallerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarTallerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoTalleristaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarTalleristaToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem eliminarTallerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarTalleristaToolStripMenuItem;
    }
}