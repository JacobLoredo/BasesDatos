﻿namespace BasesDatos.Modulo_SQL
{
    partial class SQL_formulario
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgv_resultados = new System.Windows.Forms.DataGridView();
            this.txt_salida = new System.Windows.Forms.TextBox();
            this.txtb_entrada = new System.Windows.Forms.TextBox();
            this.txt_compilacion = new System.Windows.Forms.TextBox();
            this.tab_ctrl = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.agregarPestañaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarPestañaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarResultadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecutarSentenciaF5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limpiaGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_resultados)).BeginInit();
            this.tab_ctrl.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgv_resultados);
            this.tabPage1.Controls.Add(this.txt_salida);
            this.tabPage1.Controls.Add(this.txtb_entrada);
            this.tabPage1.Controls.Add(this.txt_compilacion);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(829, 513);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "SQL";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgv_resultados
            // 
            this.dgv_resultados.AllowUserToAddRows = false;
            this.dgv_resultados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_resultados.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_resultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_resultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_resultados.Location = new System.Drawing.Point(3, 164);
            this.dgv_resultados.Name = "dgv_resultados";
            this.dgv_resultados.ReadOnly = true;
            this.dgv_resultados.RowHeadersVisible = false;
            this.dgv_resultados.Size = new System.Drawing.Size(823, 226);
            this.dgv_resultados.TabIndex = 4;
            // 
            // txt_salida
            // 
            this.txt_salida.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_salida.Dock = System.Windows.Forms.DockStyle.Top;
            this.txt_salida.Enabled = false;
            this.txt_salida.Location = new System.Drawing.Point(3, 154);
            this.txt_salida.Multiline = true;
            this.txt_salida.Name = "txt_salida";
            this.txt_salida.ReadOnly = true;
            this.txt_salida.Size = new System.Drawing.Size(823, 10);
            this.txt_salida.TabIndex = 1;
            this.txt_salida.Visible = false;
            // 
            // txtb_entrada
            // 
            this.txtb_entrada.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtb_entrada.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_entrada.Location = new System.Drawing.Point(3, 3);
            this.txtb_entrada.Multiline = true;
            this.txtb_entrada.Name = "txtb_entrada";
            this.txtb_entrada.Size = new System.Drawing.Size(823, 151);
            this.txtb_entrada.TabIndex = 0;
            // 
            // txt_compilacion
            // 
            this.txt_compilacion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_compilacion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_compilacion.Location = new System.Drawing.Point(3, 390);
            this.txt_compilacion.Multiline = true;
            this.txt_compilacion.Name = "txt_compilacion";
            this.txt_compilacion.ReadOnly = true;
            this.txt_compilacion.Size = new System.Drawing.Size(823, 120);
            this.txt_compilacion.TabIndex = 2;
            // 
            // tab_ctrl
            // 
            this.tab_ctrl.Controls.Add(this.tabPage1);
            this.tab_ctrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_ctrl.Location = new System.Drawing.Point(0, 24);
            this.tab_ctrl.Name = "tab_ctrl";
            this.tab_ctrl.SelectedIndex = 0;
            this.tab_ctrl.Size = new System.Drawing.Size(837, 539);
            this.tab_ctrl.TabIndex = 0;
            this.tab_ctrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tab_ctrl_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarPestañaToolStripMenuItem,
            this.ejecutarSentenciaF5ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(837, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // agregarPestañaToolStripMenuItem
            // 
            this.agregarPestañaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarPestañaToolStripMenuItem1,
            this.exportarResultadosToolStripMenuItem,
            this.limpiaGridToolStripMenuItem});
            this.agregarPestañaToolStripMenuItem.Name = "agregarPestañaToolStripMenuItem";
            this.agregarPestañaToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.agregarPestañaToolStripMenuItem.Text = "Opciones";
            // 
            // agregarPestañaToolStripMenuItem1
            // 
            this.agregarPestañaToolStripMenuItem1.Name = "agregarPestañaToolStripMenuItem1";
            this.agregarPestañaToolStripMenuItem1.Size = new System.Drawing.Size(205, 22);
            this.agregarPestañaToolStripMenuItem1.Text = "Agregar pestaña";
            this.agregarPestañaToolStripMenuItem1.Click += new System.EventHandler(this.Agrega_nueva_pestaña_sql);
            // 
            // exportarResultadosToolStripMenuItem
            // 
            this.exportarResultadosToolStripMenuItem.Name = "exportarResultadosToolStripMenuItem";
            this.exportarResultadosToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.exportarResultadosToolStripMenuItem.Text = "Exportar resultados";
            // 
            // ejecutarSentenciaF5ToolStripMenuItem
            // 
            this.ejecutarSentenciaF5ToolStripMenuItem.Name = "ejecutarSentenciaF5ToolStripMenuItem";
            this.ejecutarSentenciaF5ToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            this.ejecutarSentenciaF5ToolStripMenuItem.Text = "Ejecutar sentencia (F5)";
            this.ejecutarSentenciaF5ToolStripMenuItem.Click += new System.EventHandler(this.ejecutarSentenciaF5ToolStripMenuItem_Click);
            // 
            // limpiaGridToolStripMenuItem
            // 
            this.limpiaGridToolStripMenuItem.Name = "limpiaGridToolStripMenuItem";
            this.limpiaGridToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.limpiaGridToolStripMenuItem.Text = "Limpia grid";
            this.limpiaGridToolStripMenuItem.Click += new System.EventHandler(this.limpiaGridToolStripMenuItem_Click);
            // 
            // SQL_formulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 563);
            this.Controls.Add(this.tab_ctrl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SQL_formulario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL_formulario";
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_resultados)).EndInit();
            this.tab_ctrl.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txt_salida;
        private System.Windows.Forms.TextBox txt_compilacion;
        private System.Windows.Forms.TextBox txtb_entrada;
        private System.Windows.Forms.TabControl tab_ctrl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem agregarPestañaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarPestañaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportarResultadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejecutarSentenciaF5ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgv_resultados;
        private System.Windows.Forms.ToolStripMenuItem limpiaGridToolStripMenuItem;
    }
}