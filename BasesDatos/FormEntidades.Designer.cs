namespace BasesDatos
{
    partial class FormEntidades
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbCabecera = new System.Windows.Forms.TextBox();
            this.btnBotonAgregar = new System.Windows.Forms.Button();
            this.btnBotonModificar = new System.Windows.Forms.Button();
            this.btnBotonEliminar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBotonAgregarAtributos = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.PanelTablaEntidades = new System.Windows.Forms.Panel();
            this.DataGridEntidades = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelTablaEntidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridEntidades)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(142, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "NombreBD:";
            // 
            // tbCabecera
            // 
            this.tbCabecera.Enabled = false;
            this.tbCabecera.Location = new System.Drawing.Point(15, 12);
            this.tbCabecera.Name = "tbCabecera";
            this.tbCabecera.Size = new System.Drawing.Size(60, 20);
            this.tbCabecera.TabIndex = 1;
            this.tbCabecera.Text = "0";
            // 
            // btnBotonAgregar
            // 
            this.btnBotonAgregar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBotonAgregar.FlatAppearance.BorderSize = 0;
            this.btnBotonAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnBotonAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBotonAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBotonAgregar.Location = new System.Drawing.Point(346, 305);
            this.btnBotonAgregar.Name = "btnBotonAgregar";
            this.btnBotonAgregar.Size = new System.Drawing.Size(100, 26);
            this.btnBotonAgregar.TabIndex = 3;
            this.btnBotonAgregar.Text = "Agregar";
            this.btnBotonAgregar.UseVisualStyleBackColor = false;
            this.btnBotonAgregar.Click += new System.EventHandler(this.btnBotonAgregar_Click);
            // 
            // btnBotonModificar
            // 
            this.btnBotonModificar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBotonModificar.FlatAppearance.BorderSize = 0;
            this.btnBotonModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnBotonModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBotonModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBotonModificar.Location = new System.Drawing.Point(346, 337);
            this.btnBotonModificar.Name = "btnBotonModificar";
            this.btnBotonModificar.Size = new System.Drawing.Size(100, 26);
            this.btnBotonModificar.TabIndex = 4;
            this.btnBotonModificar.Text = "Modificar";
            this.btnBotonModificar.UseVisualStyleBackColor = false;
            this.btnBotonModificar.Click += new System.EventHandler(this.btnBotonModificar_Click);
            // 
            // btnBotonEliminar
            // 
            this.btnBotonEliminar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBotonEliminar.FlatAppearance.BorderSize = 0;
            this.btnBotonEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnBotonEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBotonEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBotonEliminar.Location = new System.Drawing.Point(346, 369);
            this.btnBotonEliminar.Name = "btnBotonEliminar";
            this.btnBotonEliminar.Size = new System.Drawing.Size(100, 26);
            this.btnBotonEliminar.TabIndex = 5;
            this.btnBotonEliminar.Text = "Eliminar";
            this.btnBotonEliminar.UseVisualStyleBackColor = false;
            this.btnBotonEliminar.Click += new System.EventHandler(this.btnBotonEliminar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(223, 337);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(117, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(140, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nombre: ";
            // 
            // btnBotonAgregarAtributos
            // 
            this.btnBotonAgregarAtributos.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBotonAgregarAtributos.FlatAppearance.BorderSize = 0;
            this.btnBotonAgregarAtributos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnBotonAgregarAtributos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBotonAgregarAtributos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBotonAgregarAtributos.Location = new System.Drawing.Point(539, 337);
            this.btnBotonAgregarAtributos.Name = "btnBotonAgregarAtributos";
            this.btnBotonAgregarAtributos.Size = new System.Drawing.Size(153, 26);
            this.btnBotonAgregarAtributos.TabIndex = 8;
            this.btnBotonAgregarAtributos.Text = "Agregar Atributos";
            this.btnBotonAgregarAtributos.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(446, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tablas";
            // 
            // PanelTablaEntidades
            // 
            this.PanelTablaEntidades.Controls.Add(this.DataGridEntidades);
            this.PanelTablaEntidades.Location = new System.Drawing.Point(15, 47);
            this.PanelTablaEntidades.Name = "PanelTablaEntidades";
            this.PanelTablaEntidades.Size = new System.Drawing.Size(935, 248);
            this.PanelTablaEntidades.TabIndex = 2;
            // 
            // DataGridEntidades
            // 
            this.DataGridEntidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridEntidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre});
            this.DataGridEntidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridEntidades.Location = new System.Drawing.Point(0, 0);
            this.DataGridEntidades.Name = "DataGridEntidades";
            this.DataGridEntidades.Size = new System.Drawing.Size(935, 248);
            this.DataGridEntidades.TabIndex = 0;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // FormEntidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 433);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBotonAgregarAtributos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnBotonEliminar);
            this.Controls.Add(this.btnBotonModificar);
            this.Controls.Add(this.PanelTablaEntidades);
            this.Controls.Add(this.tbCabecera);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBotonAgregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEntidades";
            this.Text = "FormEntidades";
            this.Load += new System.EventHandler(this.FormEntidades_Load);
            this.PanelTablaEntidades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridEntidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBotonAgregar;
        private System.Windows.Forms.Button btnBotonModificar;
        private System.Windows.Forms.Button btnBotonEliminar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBotonAgregarAtributos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel PanelTablaEntidades;
        private System.Windows.Forms.DataGridView DataGridEntidades;
        public System.Windows.Forms.TextBox tbCabecera;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
    }
}