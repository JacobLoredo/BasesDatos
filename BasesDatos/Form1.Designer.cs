namespace BasesDatos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelMenuVertical = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelBarraTitulo = new System.Windows.Forms.Panel();
            this.iconMinimize = new FontAwesome.Sharp.IconButton();
            this.iconMaximize = new FontAwesome.Sharp.IconButton();
            this.iconRestore = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconClose = new FontAwesome.Sharp.IconButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelCentral = new System.Windows.Forms.Panel();
            this.sQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelMenuVertical.SuspendLayout();
            this.PanelBarraTitulo.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMenuVertical
            // 
            this.PanelMenuVertical.BackColor = System.Drawing.Color.LightSteelBlue;
            this.PanelMenuVertical.Controls.Add(this.label1);
            this.PanelMenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMenuVertical.Location = new System.Drawing.Point(0, 0);
            this.PanelMenuVertical.Name = "PanelMenuVertical";
            this.PanelMenuVertical.Size = new System.Drawing.Size(229, 650);
            this.PanelMenuVertical.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bases de Datos A";
            // 
            // PanelBarraTitulo
            // 
            this.PanelBarraTitulo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PanelBarraTitulo.Controls.Add(this.iconMinimize);
            this.PanelBarraTitulo.Controls.Add(this.iconMaximize);
            this.PanelBarraTitulo.Controls.Add(this.iconRestore);
            this.PanelBarraTitulo.Controls.Add(this.iconButton2);
            this.PanelBarraTitulo.Controls.Add(this.iconClose);
            this.PanelBarraTitulo.Controls.Add(this.menuStrip1);
            this.PanelBarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelBarraTitulo.Location = new System.Drawing.Point(229, 0);
            this.PanelBarraTitulo.Name = "PanelBarraTitulo";
            this.PanelBarraTitulo.Size = new System.Drawing.Size(746, 50);
            this.PanelBarraTitulo.TabIndex = 1;
            // 
            // iconMinimize
            // 
            this.iconMinimize.BackColor = System.Drawing.Color.Transparent;
            this.iconMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconMinimize.FlatAppearance.BorderSize = 0;
            this.iconMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconMinimize.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.iconMinimize.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(25)))), ((int)(((byte)(45)))));
            this.iconMinimize.IconSize = 40;
            this.iconMinimize.Location = new System.Drawing.Point(590, 0);
            this.iconMinimize.Name = "iconMinimize";
            this.iconMinimize.Rotation = 0D;
            this.iconMinimize.Size = new System.Drawing.Size(39, 50);
            this.iconMinimize.TabIndex = 6;
            this.iconMinimize.UseVisualStyleBackColor = false;
            this.iconMinimize.Click += new System.EventHandler(this.iconMinimize_Click);
            // 
            // iconMaximize
            // 
            this.iconMaximize.BackColor = System.Drawing.Color.Transparent;
            this.iconMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconMaximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconMaximize.FlatAppearance.BorderSize = 0;
            this.iconMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconMaximize.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.iconMaximize.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(25)))), ((int)(((byte)(45)))));
            this.iconMaximize.IconSize = 40;
            this.iconMaximize.Location = new System.Drawing.Point(629, 0);
            this.iconMaximize.Name = "iconMaximize";
            this.iconMaximize.Rotation = 0D;
            this.iconMaximize.Size = new System.Drawing.Size(39, 50);
            this.iconMaximize.TabIndex = 5;
            this.iconMaximize.UseVisualStyleBackColor = false;
            this.iconMaximize.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // iconRestore
            // 
            this.iconRestore.BackColor = System.Drawing.Color.Transparent;
            this.iconRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconRestore.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconRestore.FlatAppearance.BorderSize = 0;
            this.iconRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconRestore.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconRestore.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            this.iconRestore.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(25)))), ((int)(((byte)(45)))));
            this.iconRestore.IconSize = 40;
            this.iconRestore.Location = new System.Drawing.Point(668, 0);
            this.iconRestore.Name = "iconRestore";
            this.iconRestore.Rotation = 0D;
            this.iconRestore.Size = new System.Drawing.Size(39, 50);
            this.iconRestore.TabIndex = 2;
            this.iconRestore.UseVisualStyleBackColor = false;
            this.iconRestore.Visible = false;
            this.iconRestore.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.Transparent;
            this.iconButton2.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Bars;
            this.iconButton2.IconColor = System.Drawing.Color.Black;
            this.iconButton2.IconSize = 50;
            this.iconButton2.Location = new System.Drawing.Point(0, 0);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Rotation = 0D;
            this.iconButton2.Size = new System.Drawing.Size(50, 50);
            this.iconButton2.TabIndex = 1;
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // iconClose
            // 
            this.iconClose.BackColor = System.Drawing.Color.Transparent;
            this.iconClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconClose.FlatAppearance.BorderSize = 0;
            this.iconClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconClose.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.iconClose.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(25)))), ((int)(((byte)(45)))));
            this.iconClose.IconSize = 40;
            this.iconClose.Location = new System.Drawing.Point(707, 0);
            this.iconClose.Name = "iconClose";
            this.iconClose.Rotation = 0D;
            this.iconClose.Size = new System.Drawing.Size(39, 50);
            this.iconClose.TabIndex = 0;
            this.iconClose.UseVisualStyleBackColor = false;
            this.iconClose.Click += new System.EventHandler(this.iconClose_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem1,
            this.sQLToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(50, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(746, 50);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            // 
            // archivoToolStripMenuItem1
            // 
            this.archivoToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.NuevoToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.cerrarToolStripMenuItem1});
            this.archivoToolStripMenuItem1.Name = "archivoToolStripMenuItem1";
            this.archivoToolStripMenuItem1.Size = new System.Drawing.Size(60, 46);
            this.archivoToolStripMenuItem1.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // NuevoToolStripMenuItem
            // 
            this.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem";
            this.NuevoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.NuevoToolStripMenuItem.Text = "Nuevo";
            this.NuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click_1);
            // 
            // cerrarToolStripMenuItem1
            // 
            this.cerrarToolStripMenuItem1.Name = "cerrarToolStripMenuItem1";
            this.cerrarToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.cerrarToolStripMenuItem1.Text = "Cerrar";
            this.cerrarToolStripMenuItem1.Click += new System.EventHandler(this.cerrarToolStripMenuItem1_Click);
            // 
            // PanelCentral
            // 
            this.PanelCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCentral.Location = new System.Drawing.Point(229, 50);
            this.PanelCentral.Name = "PanelCentral";
            this.PanelCentral.Size = new System.Drawing.Size(746, 600);
            this.PanelCentral.TabIndex = 2;
            this.PanelCentral.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelCentral_Paint);
            // 
            // sQLToolStripMenuItem
            // 
            this.sQLToolStripMenuItem.Name = "sQLToolStripMenuItem";
            this.sQLToolStripMenuItem.Size = new System.Drawing.Size(40, 46);
            this.sQLToolStripMenuItem.Text = "SQL";
            this.sQLToolStripMenuItem.Click += new System.EventHandler(this.Abre_modulo_sql);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 650);
            this.Controls.Add(this.PanelCentral);
            this.Controls.Add(this.PanelBarraTitulo);
            this.Controls.Add(this.PanelMenuVertical);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.PanelMenuVertical.ResumeLayout(false);
            this.PanelMenuVertical.PerformLayout();
            this.PanelBarraTitulo.ResumeLayout(false);
            this.PanelBarraTitulo.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMenuVertical;
        private System.Windows.Forms.Panel PanelBarraTitulo;
        private System.Windows.Forms.Panel PanelCentral;
        private FontAwesome.Sharp.IconButton iconClose;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconRestore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private FontAwesome.Sharp.IconButton iconMinimize;
        private FontAwesome.Sharp.IconButton iconMaximize;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sQLToolStripMenuItem;
    }
}

