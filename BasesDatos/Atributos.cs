using System;
using System.Windows.Forms;

namespace BasesDatos
{
    public partial class FormAtributos : Form
    {
        public BaseDatos @base;
        public Tabla tablaActual;
        public Archivo Archivo;
        public FormAtributos(Tabla tabla, BaseDatos baseDatos)
        {
            InitializeComponent();
            Archivo = new Archivo();
            @base = baseDatos;
            Archivo.BaseD = @base;
            tablaActual = tabla;
            NombreTabla.Text += " " + tablaActual._NombreTabla;
            CargarAtributos();
        }
        public void CargarAtributos()
        {
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
        }
        private void CBTipoLlave_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(CBTipoLlave.SelectedIndex.ToString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CBTipoDato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void BuscaAtributoModificar()
        {

            foreach (Atributo item in tablaActual._Atributos)
            {
                if (item._NombreAtributo == (string)dataGridAtributos.CurrentRow.Cells[0].Value)
                {

                    ModificaAtributo(tablaActual._Atributos.IndexOf(item));
                    break;
                }

            }
        }
        public void BuscaAtributoEliminar()
        {

            foreach (Atributo item in tablaActual._Atributos)
            {
                if (item._NombreAtributo == (string)dataGridAtributos.CurrentRow.Cells[0].Value)
                {
                   
                    tablaActual._Atributos.Remove(item);
                    Archivo.GuardarTabla(tablaActual);
                    Archivo.GuardaBase(@base);
                    break;
                }

            }
        }
        public void ModificaAtributo(int index)
        {
            /*Checa cada unas de las posibilidades en las que la persona quiera cambiar 1 o mas elementos de un atributo*/
            if (textBox1.Text != "")
            {
                tablaActual._Atributos[index]._NombreAtributo = textBox1.Text;
            }
            else if (CBTipoDato.Text != "")
            {
                tablaActual._Atributos[index]._TipoDato = Convert.ToChar(CBTipoDato.Text);
            }
            else if (CBTipoLlave.Text != "")
            {
                tablaActual._Atributos[index]._TipoLLave = CBTipoLlave.SelectedIndex + 1;
            }
            else if (textBox1.Text != "" && CBTipoDato.Text != "")
            {
                tablaActual._Atributos[index]._NombreAtributo = textBox1.Text;
                tablaActual._Atributos[index]._TipoDato = Convert.ToChar(CBTipoDato.Text);
            }
            else if (textBox1.Text != "" && CBTipoLlave.Text != "")
            {
                tablaActual._Atributos[index]._NombreAtributo = textBox1.Text;
                tablaActual._Atributos[index]._TipoLLave = CBTipoLlave.SelectedIndex + 1;
            }
            else if (CBTipoDato.Text != "" && CBTipoLlave.Text != "")
            {
                tablaActual._Atributos[index]._TipoDato = Convert.ToChar(CBTipoDato.Text);
                tablaActual._Atributos[index]._TipoLLave = CBTipoLlave.SelectedIndex + 1;
            }
            else
            {
                tablaActual._Atributos[index]._NombreAtributo = textBox1.Text;
                tablaActual._Atributos[index]._TipoDato = Convert.ToChar(CBTipoDato.Text);
                tablaActual._Atributos[index]._TipoLLave = CBTipoLlave.SelectedIndex + 1;
            }

            Archivo.GuardarTabla(tablaActual);
            Archivo.GuardaBase(@base);
            textBox1.Text = "";
            CBTipoDato.Text = "";
            CBTipoLlave.Text = "";
            CargarAtributos();

        }
        private void btnBotonModificar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || CBTipoDato.Text != "" || CBTipoLlave.Text != "")
            {
                int res = ChecaAtributoRepetida(textBox1.Text);
                if (res == 0)
                {
                    if (!ChecaClavePrimariaRepetida())
                    {
                        BuscaAtributoModificar();
                        CargarAtributos();
                    }
                }
                else
                {
                    MessageBox.Show("El atributo deseado ya existe");
                    textBox1.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Faltan campos por llenar");
            }
        }


        private void iconClose_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }
        public int ChecaAtributoRepetida(string NombreAtributo)
        {
            int repetido = 0;
            if (NombreAtributo != "")
            {

                foreach (Atributo item in tablaActual._Atributos)
                {
                    if (item._NombreAtributo == NombreAtributo)
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
        public bool ChecaClavePrimariaRepetida()
        {
            bool ban = false;
            if (tablaActual._Atributos.Count > 0)
            {

                for (int i = 0; i < tablaActual._Atributos.Count; i++)
                {
                    if (tablaActual._Atributos[i]._TipoLLave == 1 && CBTipoLlave.SelectedIndex + 1 == tablaActual._Atributos[i]._TipoLLave)
                    {
                        MessageBox.Show("Ya existe un atributo con Clave Primaria");
                        textBox1.Text = "";
                        ban = true;
                        break;
                    }
                }
            }
            else
            {
                return ban;
            }
            return ban;
        }
        public Atributo CreaAtributo(string n,char TD,int LL) {
            Atributo atributo = new Atributo(n,TD,LL);
            return atributo;
        }
        private void btnBotonAgregar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && CBTipoDato.Text != "" && CBTipoLlave.Text != "")
            {

                int res = ChecaAtributoRepetida(textBox1.Text);
                if (res == 0)
                {
                    if (!ChecaClavePrimariaRepetida())
                    {
                        Atributo atributo = CreaAtributo(textBox1.Text, Convert.ToChar(CBTipoDato.Text), CBTipoLlave.SelectedIndex + 1);
                        tablaActual._Atributos.Add(atributo);
                        Archivo.GuardarTabla(tablaActual);
                        Archivo.GuardaBase(@base);
                        textBox1.Text = "";
                        CBTipoDato.Text = "";
                        CBTipoLlave.Text = "";
                        CargarAtributos();
                    }
                }
                else
                {
                    MessageBox.Show("El atributo deseado ya existe");
                    textBox1.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Faltan campos por llenar");
            }
        }

        private void btnBotonEliminar_Click(object sender, EventArgs e)
        {
            BuscaAtributoEliminar();
            CargarAtributos();
        }
    }
}
