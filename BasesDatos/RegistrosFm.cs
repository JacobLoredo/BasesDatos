using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasesDatos
{
    public partial class RegistrosFm : Form
    {
        public BaseDatos @baseActual;
        public Tabla tablaRegistros;
        public Archivo Archivo;
        public Point p1 = new Point(15, 30);//Posicion X,Y de los label.
        public Point p2 = new Point(70, 30);
        public List<TextBox> textBoxes = new List<TextBox>();
        public List<Label> labels = new List<Label>();
        public RegistrosFm(BaseDatos @base, Tabla tabla)
        {
            InitializeComponent();
            Archivo = new Archivo();
            @baseActual = @base;
            Archivo.BaseD = @baseActual;
            tablaRegistros = tabla;
            CreaTextBoxLabel();
            CargarAtributos();
        }

        public void CreaTextBoxLabel()
        {
            foreach (Atributo item in tablaRegistros._Atributos)
            {

            Label lb = new Label();
            TextBox tb = new TextBox();

            lb.Enabled = true;
            tb.Enabled = true;

            lb.Visible = true;
            tb.Visible = true;

            lb.Location = p1;
            tb.Location = p2;

            lb.Text = item._NombreAtributo;
            
            this.Controls.Add(tb);
            this.Controls.Add(lb);
            textBoxes.Add(tb);
            labels.Add(lb);
            p1.Y = p1.Y + 30;
            p2.Y = p2.Y + 30;
            }
            dataGridView1.Location = p1;
            if (dataGridView1.Rows.Count < 2)
            {
                foreach (Atributo atr in tablaRegistros._Atributos)//Agrega nuevas columnas segun los atributos existentes.
                {
                    dataGridView1.Columns.Add("Nom" + atr._NombreAtributo, atr._NombreAtributo);
                }
               
            }
        }

        public void CargarAtributos()
        {
            /*
            if (tablaActual._Atributos.Count > 0)
            {
                dataGridAtributos.Rows.Clear();
                foreach (Atributo item in tablaActual._Atributos)
                {
                    int n = dataGridAtributos.Rows.Add();

                    dataGridAtributos.Rows[n].Cells[0].Value = item._NombreAtributo;
                    dataGridAtributos.Rows[n].Cells[1].Value = item._TipoDato;
                    dataGridAtributos.Rows[n].Cells[2].Value = item._TipoLLave;
                }
            }
            */
        }
       

        private void iconClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool TipoDatoIncorrecto=false;
            for (int i = 0; i < tablaRegistros._Atributos.Count; i++)
            {
                if (chechaTipoDato(tablaRegistros._Atributos[i], i)) 
                {
                    TipoDatoIncorrecto = true;
                    break;
                }
            }
            if (TipoDatoIncorrecto)
            {
                
            }
            else
            {
                foreach (TextBox text in textBoxes)
                {

                }
                AgregarDataGridView();
                //ChecarDatoRepetido();
            }
        }

        private void AgregarDataGridView()
        {
            int n = dataGridView1.Rows.Add();
            for (int i = 0; i < textBoxes.Count; i++)
            {
                dataGridView1.Rows[n].Cells[i].Value =textBoxes[i].Text;
                textBoxes[i].Text = "";
            }

        }

        private void ChecarDatoRepetido()
        {
           
        }

        private bool chechaTipoDato(Atributo atributo, int idTextbox)
        {
            bool ban = false;
            if (textBoxes[idTextbox].Text=="")
            {
                MessageBox.Show("Debes de completar todos los campos correctamente");
                ban = true;
            }
            else
            {
            if (atributo._TipoDato == 'E')
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxes[idTextbox].Text, "^[1-9][0-9]*$"))
                {
                    MessageBox.Show("El campo: " + labels[idTextbox].Text + " solo acepta numeros enteros");
                    textBoxes[idTextbox].Text = "";
                    ban =true;
                }
                else
                {
                    ban= false;
                }
            }
            else if (atributo._TipoDato == 'F')
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxes[idTextbox].Text, "^-?[0-9]+(?:.[0-9]+)?$"))
                {
                    MessageBox.Show("El campo: " + labels[idTextbox].Text + " solo acepta numeros Flotantes");
                    textBoxes[idTextbox].Text = "";
                    ban= true;
                }
                else
                {
                    ban=false;
                }
            }
            
            }
            
            return ban;
            } 
    }
}
