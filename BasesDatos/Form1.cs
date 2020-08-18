﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace BasesDatos
{
    public partial class Form1 : Form
    {
        public string nombre_archivo;
        public Archivo arc;
        public long cabecera;
        public BaseDatos BaseDatos;
        public Form1()
        {
            InitializeComponent();
           
            arc = new Archivo();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd,int msg,int wparam,int lparam);
        private void iconClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (PanelMenuVertical.Width==250)
            {
                PanelMenuVertical.Width = 90;
            }
            else
            {
                PanelMenuVertical.Width = 250;
            }
        }

        private void PanelCentral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconMaximize.Visible = true;
            iconRestore.Visible = false;

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconMaximize.Visible = false;
            iconRestore.Visible = true;
        }

        private void iconMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }
        private void AbrirFormInPanel(object FormHijo) {
            if (this.PanelCentral.Controls.Count>0)
                this.PanelCentral.Controls.RemoveAt(0);
            Form form = FormHijo as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.PanelCentral.Controls.Add(form);
            this.PanelCentral.Tag = form;
            form.Show();
        }
        
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FormEntidades());
        }

        
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (arc.SaveD.ShowDialog() == DialogResult.OK)
            {

                nombre_archivo = arc.SaveD.FileName;
                arc.nombre_archivo = nombre_archivo;
                
               
                arc.CreaArchivo(nombre_archivo, 0);
                BaseDatos = arc.BaseD;

                FormEntidades formEntidades = new FormEntidades();
                formEntidades.Archivo = arc;
                formEntidades.baseActual = BaseDatos;
                
                AbrirFormInPanel(formEntidades);
            }
        }
        private void guardarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void cerrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            arc.CierraArchivo();
            if (this.PanelCentral.Controls.Count > 0)
                this.PanelCentral.Controls.RemoveAt(0);
        }
        public void CierraArchivo()
        {
            
        }
    }
}
