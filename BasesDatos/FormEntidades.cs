using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasesDatos
{
    public partial class FormEntidades : Form
    {
        public Archivo Archivo;
        public BaseDatos baseActual;
        public FormEntidades()
        {
            InitializeComponent();
        }

        private void FormEntidades_Load(object sender, EventArgs e)
        {
            label1.Text += " "+baseActual._NombreBD;
           
        }

        private void btnBotonAgregar_Click(object sender, EventArgs e)
        {
            int res = ChecaEntidadRepetida(textBox1.Text);
            if (res==0)
            {
                Tabla tabla = new Tabla(textBox1.Text);
                baseActual.Tablas.Add(tabla);
                DataGridEntidades.Rows.Clear();

                foreach (Tabla tb in baseActual.Tablas)
                {
                    int n = DataGridEntidades.Rows.Add();

                    DataGridEntidades.Rows[n].Cells[0].Value = tb._NombreTabla;
                   
                }
                Archivo.GuardarTabla(tabla);
                Archivo.GuardaBase(baseActual);
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("La entidad deseada ya existe");
            }
        }
        public int ChecaEntidadRepetida(string NombreEntidad) {
            int repetido = 0;
            if (NombreEntidad!="")
            {
                
                foreach (Tabla item in baseActual.Tablas)
                {
                    if (item._NombreTabla == NombreEntidad)
                    {
                        repetido = 1;
                        break;
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Inserta una nombre para la entidad");
            }
            return repetido;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
