﻿namespace BasesDatos
{
    partial class FormAtributos
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
            this.PanelDataAtributos = new System.Windows.Forms.Panel();
            this.dataGridAtributos = new System.Windows.Forms.DataGridView();
            this.NombreAtributo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoLlave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelBotones = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.TBTamaño = new System.Windows.Forms.TextBox();
            this.CBForanea = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CBTipoLlave = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CBTipoDato = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.NombreTabla = new System.Windows.Forms.Label();
            this.PanelBton = new System.Windows.Forms.Panel();
            this.btnBotonEliminar = new System.Windows.Forms.Button();
            this.btnBotonModificar = new System.Windows.Forms.Button();
            this.btnBotonAgregar = new System.Windows.Forms.Button();
            this.iconClose = new FontAwesome.Sharp.IconButton();
            this.button1 = new System.Windows.Forms.Button();
            this.PanelDataAtributos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAtributos)).BeginInit();
            this.PanelBotones.SuspendLayout();
            this.PanelBton.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelDataAtributos
            // 
            this.PanelDataAtributos.Controls.Add(this.dataGridAtributos);
            this.PanelDataAtributos.Location = new System.Drawing.Point(43, 80);
            this.PanelDataAtributos.Name = "PanelDataAtributos";
            this.PanelDataAtributos.Size = new System.Drawing.Size(644, 203);
            this.PanelDataAtributos.TabIndex = 0;
            // 
            // dataGridAtributos
            // 
            this.dataGridAtributos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAtributos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreAtributo,
            this.TipoDato,
            this.TipoLlave});
            this.dataGridAtributos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridAtributos.Location = new System.Drawing.Point(0, 0);
            this.dataGridAtributos.Name = "dataGridAtributos";
            this.dataGridAtributos.Size = new System.Drawing.Size(644, 203);
            this.dataGridAtributos.TabIndex = 0;
            // 
            // NombreAtributo
            // 
            this.NombreAtributo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NombreAtributo.HeaderText = "NombreAtributo";
            this.NombreAtributo.Name = "NombreAtributo";
            // 
            // TipoDato
            // 
            this.TipoDato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TipoDato.HeaderText = "TipoDato";
            this.TipoDato.Name = "TipoDato";
            // 
            // TipoLlave
            // 
            this.TipoLlave.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TipoLlave.HeaderText = "TipoLlave";
            this.TipoLlave.Name = "TipoLlave";
            // 
            // PanelBotones
            // 
            this.PanelBotones.Controls.Add(this.label5);
            this.PanelBotones.Controls.Add(this.TBTamaño);
            this.PanelBotones.Controls.Add(this.CBForanea);
            this.PanelBotones.Controls.Add(this.label4);
            this.PanelBotones.Controls.Add(this.CBTipoLlave);
            this.PanelBotones.Controls.Add(this.label3);
            this.PanelBotones.Controls.Add(this.label1);
            this.PanelBotones.Controls.Add(this.CBTipoDato);
            this.PanelBotones.Controls.Add(this.label2);
            this.PanelBotones.Controls.Add(this.textBox1);
            this.PanelBotones.Location = new System.Drawing.Point(43, 289);
            this.PanelBotones.Name = "PanelBotones";
            this.PanelBotones.Size = new System.Drawing.Size(246, 143);
            this.PanelBotones.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Tamaño: ";
            // 
            // TBTamaño
            // 
            this.TBTamaño.Location = new System.Drawing.Point(126, 59);
            this.TBTamaño.Name = "TBTamaño";
            this.TBTamaño.Size = new System.Drawing.Size(97, 20);
            this.TBTamaño.TabIndex = 15;
            // 
            // CBForanea
            // 
            this.CBForanea.FormattingEnabled = true;
            this.CBForanea.Location = new System.Drawing.Point(126, 119);
            this.CBForanea.Name = "CBForanea";
            this.CBForanea.Size = new System.Drawing.Size(97, 21);
            this.CBForanea.TabIndex = 14;
            this.CBForanea.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Llave Forenea:";
            this.label4.Visible = false;
            // 
            // CBTipoLlave
            // 
            this.CBTipoLlave.FormattingEnabled = true;
            this.CBTipoLlave.Items.AddRange(new object[] {
            "1-PK",
            "2-FK",
            "3-Ninguna"});
            this.CBTipoLlave.Location = new System.Drawing.Point(126, 85);
            this.CBTipoLlave.Name = "CBTipoLlave";
            this.CBTipoLlave.Size = new System.Drawing.Size(98, 21);
            this.CBTipoLlave.TabIndex = 12;
            this.CBTipoLlave.SelectedIndexChanged += new System.EventHandler(this.CBTipoLlave_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tipo De Llave:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tipo De Dato:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CBTipoDato
            // 
            this.CBTipoDato.FormattingEnabled = true;
            this.CBTipoDato.Items.AddRange(new object[] {
            "E",
            "F",
            "C"});
            this.CBTipoDato.Location = new System.Drawing.Point(126, 32);
            this.CBTipoDato.Name = "CBTipoDato";
            this.CBTipoDato.Size = new System.Drawing.Size(98, 21);
            this.CBTipoDato.TabIndex = 9;
            this.CBTipoDato.SelectedIndexChanged += new System.EventHandler(this.CBTipoDato_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nombre: ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 20);
            this.textBox1.TabIndex = 0;
            // 
            // NombreTabla
            // 
            this.NombreTabla.AutoSize = true;
            this.NombreTabla.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreTabla.Location = new System.Drawing.Point(40, 49);
            this.NombreTabla.Name = "NombreTabla";
            this.NombreTabla.Size = new System.Drawing.Size(64, 17);
            this.NombreTabla.TabIndex = 9;
            this.NombreTabla.Text = "Tabla : ";
            // 
            // PanelBton
            // 
            this.PanelBton.Controls.Add(this.btnBotonEliminar);
            this.PanelBton.Controls.Add(this.btnBotonModificar);
            this.PanelBton.Controls.Add(this.btnBotonAgregar);
            this.PanelBton.Location = new System.Drawing.Point(349, 319);
            this.PanelBton.Name = "PanelBton";
            this.PanelBton.Size = new System.Drawing.Size(142, 102);
            this.PanelBton.TabIndex = 10;
            // 
            // btnBotonEliminar
            // 
            this.btnBotonEliminar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBotonEliminar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBotonEliminar.FlatAppearance.BorderSize = 0;
            this.btnBotonEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnBotonEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBotonEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBotonEliminar.Location = new System.Drawing.Point(0, 76);
            this.btnBotonEliminar.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnBotonEliminar.Name = "btnBotonEliminar";
            this.btnBotonEliminar.Size = new System.Drawing.Size(142, 26);
            this.btnBotonEliminar.TabIndex = 8;
            this.btnBotonEliminar.Text = "Eliminar";
            this.btnBotonEliminar.UseVisualStyleBackColor = false;
            this.btnBotonEliminar.Click += new System.EventHandler(this.btnBotonEliminar_Click);
            // 
            // btnBotonModificar
            // 
            this.btnBotonModificar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBotonModificar.FlatAppearance.BorderSize = 0;
            this.btnBotonModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnBotonModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBotonModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBotonModificar.Location = new System.Drawing.Point(0, 39);
            this.btnBotonModificar.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnBotonModificar.Name = "btnBotonModificar";
            this.btnBotonModificar.Size = new System.Drawing.Size(141, 26);
            this.btnBotonModificar.TabIndex = 7;
            this.btnBotonModificar.Text = "Modificar";
            this.btnBotonModificar.UseVisualStyleBackColor = false;
            this.btnBotonModificar.Click += new System.EventHandler(this.btnBotonModificar_Click);
            // 
            // btnBotonAgregar
            // 
            this.btnBotonAgregar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBotonAgregar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBotonAgregar.FlatAppearance.BorderSize = 0;
            this.btnBotonAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnBotonAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBotonAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBotonAgregar.Location = new System.Drawing.Point(0, 0);
            this.btnBotonAgregar.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnBotonAgregar.Name = "btnBotonAgregar";
            this.btnBotonAgregar.Size = new System.Drawing.Size(142, 26);
            this.btnBotonAgregar.TabIndex = 6;
            this.btnBotonAgregar.Text = "Agregar";
            this.btnBotonAgregar.UseVisualStyleBackColor = false;
            this.btnBotonAgregar.Click += new System.EventHandler(this.btnBotonAgregar_Click);
            // 
            // iconClose
            // 
            this.iconClose.BackColor = System.Drawing.Color.Transparent;
            this.iconClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconClose.FlatAppearance.BorderSize = 0;
            this.iconClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconClose.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.iconClose.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(25)))), ((int)(((byte)(45)))));
            this.iconClose.IconSize = 40;
            this.iconClose.Location = new System.Drawing.Point(648, -1);
            this.iconClose.Name = "iconClose";
            this.iconClose.Rotation = 0D;
            this.iconClose.Size = new System.Drawing.Size(39, 50);
            this.iconClose.TabIndex = 11;
            this.iconClose.UseVisualStyleBackColor = false;
            this.iconClose.Click += new System.EventHandler(this.iconClose_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(566, 321);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 26);
            this.button1.TabIndex = 12;
            this.button1.Text = "Agregar Datos";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormAtributos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 444);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.iconClose);
            this.Controls.Add(this.PanelBton);
            this.Controls.Add(this.NombreTabla);
            this.Controls.Add(this.PanelBotones);
            this.Controls.Add(this.PanelDataAtributos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAtributos";
            this.Text = "Atributos";
            this.PanelDataAtributos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAtributos)).EndInit();
            this.PanelBotones.ResumeLayout(false);
            this.PanelBotones.PerformLayout();
            this.PanelBton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelDataAtributos;
        private System.Windows.Forms.DataGridView dataGridAtributos;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreAtributo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDato;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoLlave;
        private System.Windows.Forms.Panel PanelBotones;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox CBTipoLlave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBTipoDato;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NombreTabla;
        private System.Windows.Forms.Panel PanelBton;
        private System.Windows.Forms.Button btnBotonEliminar;
        private System.Windows.Forms.Button btnBotonModificar;
        private System.Windows.Forms.Button btnBotonAgregar;
        private FontAwesome.Sharp.IconButton iconClose;
        private System.Windows.Forms.ComboBox CBForanea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TBTamaño;
        private System.Windows.Forms.Label label5;
    }
}