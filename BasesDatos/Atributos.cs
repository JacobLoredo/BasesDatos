using System;
using System.Windows.Forms;

namespace BasesDatos
{
    /// <summary>
    /// Form para ingresar atributos a las tablas de la base de datos
    /// </summary>
    public partial class FormAtributos : Form
    {
        public BaseDatos @base;
        public Tabla tablaActual;
        public Archivo Archivo;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="tabla">Tabla donde se van a ingresar los atributos</param>
        /// <param name="baseDatos">Base de datos en la que se esta trabajando</param>
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
        /// <summary>
        /// Funcion que carga los atributos existentes dentro del dataGridView
        /// </summary>
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
                    if (item._TipoLLave == 1)
                    {
                        dataGridAtributos.Rows[n].Cells[2].Value = "PK";
                    }
                    else if (item._TipoLLave == 2)
                    {
                        dataGridAtributos.Rows[n].Cells[2].Value = "FK";
                    }
                    else
                    {
                        dataGridAtributos.Rows[n].Cells[2].Value = "Ninguna";

                    }
                }
            }
        }
        /// <summary>
        /// Evento del Combox que contiene los diferentes tipos de llaves
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBTipoLlave_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(CBTipoLlave.SelectedIndex.ToString());
            if (CBTipoLlave.SelectedIndex == 1)
            {
                label4.Visible = true;
                CBForanea.Visible = true;
                foreach (Tabla item in @base.Tablas)
                {
                    if (item._NombreTabla != tablaActual._NombreTabla)
                    {

                        if (!CBForanea.Items.Contains(item._NombreTabla.ToString()))
                            CBForanea.Items.Add(item._NombreTabla.ToString());

                    }
                }
                TBTamaño.Text = "4";
                TBTamaño.Enabled = false;
                CBTipoDato.SelectedIndex = 0;
                CBTipoDato.Enabled = false;
            }
            else if (CBTipoLlave.SelectedIndex == 1)
            {

                TBTamaño.Enabled = true;
                CBTipoDato.Enabled = true;
                label4.Visible = false;
                CBForanea.Visible = false;
                CBForanea.Items.Clear();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Evento del Combox que contiene los diferentes tipos de datos que se pueden ingresar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBTipoDato_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBTamaño.Enabled = true;
            if (CBTipoDato.SelectedItem.ToString() == "F")
            {
                TBTamaño.Text = "8";
                TBTamaño.Enabled = false;
            }
            else if (CBTipoDato.SelectedItem.ToString() == "E")
            {
                TBTamaño.Text = "4";
                TBTamaño.Enabled = false;
            }
            else
            {
                TBTamaño.Text = "";
                TBTamaño.Enabled = true;
            }

        }
       
        /// <summary>
        /// Funcion que busca el atributo a modificar
        /// </summary>
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
       /// <summary>
       /// Funcion que busca el atributo a eliminar
       /// </summary>
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
        /// <summary>
        /// Funcion que modifica un atributo por su indice en la tablas
        /// </summary>
        /// <param name="index">indice del atributo a modificar</param>
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
       /// <summary>
       /// Evento para modifcar un atributo
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btnBotonModificar_Click(object sender, EventArgs e)
        {
            if ((tablaActual._datos.Count == 0))
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
            else
            {
                MessageBox.Show("no se pueden modificar los atributos ya que contiene datos, eliminalos primero");
            }
        }

        /// <summary>
        /// Evento que cierra el forma actual de Atributos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iconClose_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }
       /// <summary>
       /// Funcion que checa que el atributo a ingresar no se encuentra ya en la tabla actual
       /// </summary>
       /// <param name="NombreAtributo">Nombre del atributo a chechar si esta repetido</param>
       /// <returns></returns>
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
        /// <summary>
        /// Funcion que regresa si el atributo a ingresar es de Tipo PK y si no se encuentra 
        /// </summary>
        /// <returns>si se encuentra repetida la clave primaria o no</returns>
        public bool ChecaClavePrimariaRepetida()
        {
            bool ban = false;
            if (tablaActual._Atributos.Count == 0)
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
       /// <summary>
       /// Funcion que crea un nuevo atributo
       /// </summary>
       /// <param name="n">Nombre del atributo</param>
       /// <param name="TD">Tipo de dato</param>
       /// <param name="LL">Tipo de llave </param>
       /// <param name="T">Tamaño del dato</param>
       /// <returns></returns>
        public Atributo CreaAtributo(string n, char TD, int LL, int T)
        {
            Atributo atributo = new Atributo(n, TD, LL, T);
            return atributo;
        }
        /// <summary>
        /// Funcion que crea un nuevo atributo que contiene una referencia FK
        /// </summary>
        /// <param name="n">Nombre del atributo nuevo</param>
        /// <param name="TD">Tipo de dato</param>
        /// <param name="LL">Tipo de llave</param>
        /// <param name="FK">Nombre de la tabla con la que se relaciona FK</param>
        /// <param name="T">Tamaño del atributo</param>
        /// <returns>Nuevo atributo creado</returns>
        public Atributo CreaAtributoFK(string n, char TD, int LL, string FK, int T)
        {
            Atributo atributo = new Atributo(n, TD, LL, FK, T);
            return atributo;
        }
       /// <summary>
       /// Evento para agregar un nuevo atributo
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btnBotonAgregar_Click(object sender, EventArgs e)
        {
            if (tablaActual._datos.Count == 0)
            {

                if (textBox1.Text != "" && CBTipoDato.Text != "" && CBTipoLlave.Text != "")
                {

                    int res = ChecaAtributoRepetida(textBox1.Text);
                    if (res == 0)
                    {
                        if (!ChecaClavePrimariaRepetida())
                        {
                            if (CBTipoLlave.SelectedIndex == 1)
                            {
                                Atributo atributo = CreaAtributoFK(textBox1.Text, Convert.ToChar(CBTipoDato.Text), CBTipoLlave.SelectedIndex + 1, CBForanea.Text, Convert.ToInt32(TBTamaño.Text));
                                tablaActual._Atributos.Add(atributo);
                                CBTipoDato.Enabled = true;
                                TBTamaño.Text = "";
                                TBTamaño.Enabled = true;
                                CBForanea.Visible = false;
                                CBForanea.Text = "";
                            }
                            else
                            {
                                Atributo atributo = CreaAtributo(textBox1.Text, Convert.ToChar(CBTipoDato.Text), CBTipoLlave.SelectedIndex + 1, Convert.ToInt32(TBTamaño.Text));
                                tablaActual._Atributos.Add(atributo);
                            }
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
            else
            {
                MessageBox.Show("no se puede agregar nuevos atributos ya que se contienen datos, eliminalos primero");
            }
        }
        /// <summary>
        /// Evento que elimina un atributo 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBotonEliminar_Click(object sender, EventArgs e)
        {
            if (tablaActual._datos.Count == 0)
            {
                BuscaAtributoEliminar();
                CargarAtributos();

            }
            else
            {
                MessageBox.Show("no se puede agregar eliminar atributos ya que se contienen datos, eliminalos primero");
            }
        }
        /// <summary>
        /// Evento que crea una nueva instancia para ingresar registros en la tabla Actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            RegistrosFm formRegistros = new RegistrosFm(@base, tablaActual);
            AddOwnedForm(formRegistros);
            formRegistros.FormBorderStyle = FormBorderStyle.None;
            formRegistros.TopLevel = false;
            formRegistros.Dock = DockStyle.Fill;
            this.Controls.Add(formRegistros);
            this.Tag = formRegistros;
            formRegistros.BringToFront();
            formRegistros.Show();
        }
    }
}
