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
        public List<ComboBox> comboBoxes = new List<ComboBox>();
        public RegistrosFm(BaseDatos @base, Tabla tabla)
        {
            InitializeComponent();
            Archivo = new Archivo();
            @baseActual = @base;
            Archivo.BaseD = @baseActual;
            tablaRegistros = tabla;
            CreaTextBoxLabel();
            if (tablaRegistros._datos!=null)
            {
                CargarAtributos();

            }
        }

        public void CreaTextBoxLabel()
        {
            foreach (Atributo item in tablaRegistros._Atributos)
            {
                if (item._TipoLLave==2)
                {
                    continue;
                }
                else
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
            }
            foreach (Atributo item in tablaRegistros._Atributos)
            {
                if (item._TipoLLave == 2)
                {
                    Label lb = new Label();
                    ComboBox combo = new ComboBox();
                    lb.Enabled = true;
                    combo.Enabled = true;

                    lb.Visible = true;
                    combo.Visible = true;
                    lb.Location = p1;
                    combo.Location = p2;
                    lb.Text = item._NombreAtributo;
                    this.Controls.Add(combo);
                    this.Controls.Add(lb);
                    labels.Add(lb);
                    comboBoxes.Add(combo);
                    p1.Y = p1.Y + 30;
                    p2.Y = p2.Y + 30;
                    foreach (Tabla tabla in baseActual.Tablas)
                    {
                        if (item._NombreFK==tabla._NombreTabla)
                        {
                            string[] datos;
                            int cont = 1;
                            int r = 0;
                            for (int i = 0; i < tabla._Atributos.Count; i++)
                            {
                                if (tabla._Atributos[i]._TipoLLave == 1)
                                {
                                    r = i;
                                }
                            }
                            for (int i = 0; i < tabla._datos.Count; i++)
                            {
                                    datos = tabla._datos[i].Split(',', ':');
                                    combo.Items.Add(datos[r+1]);
                                    cont += 2;

                                
                            }
                            cont = 1;

                        }

                    }
                }
            }
            dataGridView1.Location = p1;
            if (dataGridView1.Rows.Count < 2)
            {
                foreach (Atributo atr in tablaRegistros._Atributos)//Agrega nuevas columnas segun los atributos existentes.
                {
                    if (atr._TipoLLave==2)
                    {
                        continue;
                    }
                    else
                    {
                        dataGridView1.Columns.Add("Nom" + atr._NombreAtributo, atr._NombreAtributo);
                    }
                }
                foreach (Atributo atr in tablaRegistros._Atributos)
                {
                    if (atr._TipoLLave == 2)
                    {
                        dataGridView1.Columns.Add("Nom" + atr._NombreAtributo, atr._NombreAtributo);
                    }
                }
               
            }
        }

        public void CargarAtributos()
        {
            string[] hola;
            
            if (tablaRegistros._datos.Count > 0)
            {
                dataGridView1.Rows.Clear();

                for (int i = 0; i < tablaRegistros._datos.Count; i++)
                {
                    int cont = 1;
                    hola = tablaRegistros._datos[i].Split(',',':');
                    int n = dataGridView1.Rows.Add();
                    for (int j = 0; j < dataGridView1.Rows[n].Cells.Count; j++)
                    {
                     dataGridView1.Rows[n].Cells[j].Value = hola[cont];
                     cont += 2;
                    }
                    cont = 1;
                }
            }
            
        }


        private void iconClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool TipoDatoIncorrecto=false;
            bool PKRepetida = false;    
            for (int i = 0; i < tablaRegistros._Atributos.Count; i++)
            {
                if (tablaRegistros._Atributos[i]._TipoLLave==2)
                {
                    continue;
                }
                else
                {

                if (chechaTipoDato(tablaRegistros._Atributos[i], i)) 
                {
                    TipoDatoIncorrecto = true;
                    break;
                }
                }
            }
            if (TipoDatoIncorrecto)
            {
                
            }
            else
            {
                if (tablaRegistros._datos.Count>0)
                {
                for (int i = 0; i < tablaRegistros._Atributos.Count; i++)
                {
                    if (tablaRegistros._Atributos[i]._TipoLLave == 1) 
                    {
                            foreach (DataGridViewRow item in dataGridView1.Rows)
                            {
                                if (item.Cells[i].Value != null)
                                if (textBoxes[i].Text==item.Cells[i].Value.ToString() )    
                                {
                                    PKRepetida = true;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                    }
                }
                    if (PKRepetida)
                    {
                        MessageBox.Show("Clave Primaria repetida");
                        
                    }
                    else
                    {
                        AgregarDataGridView();

                    }
                }
                else
                {
                    AgregarDataGridView();
                }
                
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
            if (comboBoxes.Count>0)
            {
                for (int  i = 0; i < comboBoxes.Count; i++)
                {
                    dataGridView1.Rows[n].Cells[i+textBoxes.Count].Value = comboBoxes[i].Text;
                }

            }
           GuardarData();
        }

        private void GuardarData()
        {
            string datos="";
            
            int columna = 0;
            if (tablaRegistros._datos!=null)
            {
                tablaRegistros._datos.Clear();

            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                for (int i= 0; i < row.Cells.Count; i++)
                {
                    if (row.Cells[i].Value!=null)
                    {
                        if (i+1 == row.Cells.Count)
                        {
                            datos += tablaRegistros._Atributos[columna]._NombreAtributo.ToString() + ":" + row.Cells[i].Value.ToString();
                            columna++;
                        }
                        else
                        {
                        datos += tablaRegistros._Atributos[columna]._NombreAtributo.ToString() + ":"+ row.Cells[i].Value.ToString()+",";
                        columna++;

                        }
                    }
                }
                if (datos.ToString()!="")
                {
                    tablaRegistros._datos.Add(datos);

                }
                datos = "";
                columna = 0;
            }
            Archivo.GuardaBase(baseActual);
        }

        private void ChecarDatoRepetido()
        {
           
        }
        private void checarTipoCampo(Atributo atributo, int idTextbox) { 

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
        //Funcion para borrar registros
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            tablaRegistros._datos.RemoveAt(dataGridView1.CurrentRow.Index);
            Archivo.GuardaBase(baseActual);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int numTextBox=0;
            bool PKrepetida = false;
           
            foreach (TextBox item in textBoxes)
            {
                if (item.Text!="")
                {
                    if (tablaRegistros._Atributos[numTextBox]._TipoDato == 'E')
                    {
                        if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxes[numTextBox].Text, "^[1-9][0-9]*$"))
                        {
                            MessageBox.Show("El campo: " + labels[numTextBox].Text + " solo acepta numeros enteros");
                            textBoxes[numTextBox].Text = "";
                        }
                        else
                        {
                            if (tablaRegistros._Atributos[numTextBox]._TipoLLave==1)
                            {
                              
                                    for(int i = 0; i < dataGridView1.Rows.Count-1; i++ )
                                    {
                                        if (textBoxes[numTextBox].Text == dataGridView1.Rows[i].Cells[numTextBox].Value.ToString())
                                        {
                                            MessageBox.Show("La Clave Primaria ya existe");
                                            textBoxes[numTextBox].Text = "";
                                            PKrepetida = true;
                                        break;
                                        }
                                        else
                                        {

                                        }
                                    }
                                if (!PKrepetida)
                                {
                                  dataGridView1.CurrentRow.Cells[numTextBox].Value = item.Text;
                                  textBoxes[numTextBox].Text = "";
                                }
                            }

                                
                        }
                            
                    }
                
                    else if (tablaRegistros._Atributos[numTextBox]._TipoDato == 'F')
                    {
                        if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxes[numTextBox].Text, "^-?[0-9]+(?:.[0-9]+)?$"))
                        {
                            MessageBox.Show("El campo: " + labels[numTextBox].Text + " solo acepta numeros Flotantes");
                            textBoxes[numTextBox].Text = "";
                            
                        }
                        else
                        {
                            dataGridView1.CurrentRow.Cells[numTextBox].Value = item.Text;
                            
                            
                        }
                    }
                    //dataGridView1.CurrentRow.Cells[numTextBox].Value = item.Text;
                }
                numTextBox++;
            }
            if (comboBoxes.Count > 0)
            {
                foreach (ComboBox combo in comboBoxes)
                {
                    if (combo.Text!="")
                    {
                        dataGridView1.CurrentRow.Cells[numTextBox-1+comboBoxes.Count].Value = combo.Text;

                    }
                }
            }
            GuardarData();
        }
    }
}
