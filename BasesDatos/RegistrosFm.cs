using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BasesDatos
{
    /// <summary>
    /// Formulario para ingresar registros a una tabla 
    /// </summary>
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
       /// <summary>
       /// Constructor del forma Registros
       /// </summary>
       /// <param name="base">Base de datos actual</param>
       /// <param name="tabla">Tabla actual donde se estan ingresando datos</param>
        public RegistrosFm(BaseDatos @base, Tabla tabla)
        {
            InitializeComponent();
            Archivo = new Archivo();
            @baseActual = @base;
            Archivo.BaseD = @baseActual;
            tablaRegistros = tabla;
            CreaTextBoxLabel();
            if (tablaRegistros._datos != null)
            {
                CargarAtributos();
                
            }
        }
        /// <summary>
        /// Funcion que crea los textbox y combox necesarios de manera dinamica dependiendo de la cantidad de atributos
        /// </summary>
        public void CreaTextBoxLabel()
        {
            foreach (Atributo item in tablaRegistros._Atributos)
            {
                if (item._TipoLLave == 2)
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
                        if (item._NombreFK == tabla._NombreTabla)
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
                                combo.Items.Add(datos[r + 1]);
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
                    if (atr._TipoLLave == 2)
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
        /// <summary>
        /// Funcion que carga los datos en un dataGriedView
        /// </summary>
        public void CargarAtributos()
        {
            string[] hola;

            if (tablaRegistros._datos.Count > 0)
            {
                dataGridView1.Rows.Clear();

                for (int i = 0; i < tablaRegistros._datos.Count; i++)
                {
                    int cont = 1;
                    hola = tablaRegistros._datos[i].Split(',', ':');
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

        /// <summary>
        /// Evento para cerrar el Form de Registros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iconClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Evento para agregar un nuevo datos a la tabla actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            bool TipoDatoIncorrecto = false;
            bool PKRepetida = false;
            for (int i = 0; i < tablaRegistros._Atributos.Count; i++)
            {
                if (tablaRegistros._Atributos[i]._TipoLLave == 2)
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
                if (tablaRegistros._datos.Count > 0)
                {
                    for (int i = 0; i < tablaRegistros._Atributos.Count; i++)
                    {
                        if (tablaRegistros._Atributos[i]._TipoLLave == 1)
                        {
                            foreach (DataGridViewRow item in dataGridView1.Rows)
                            {
                                if (item.Cells[i].Value != null)
                                    if (textBoxes[i].Text == item.Cells[i].Value.ToString())
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
                        bool vacio = false;
                        bool sincampos = false;
                        bool referencia = false;

                        foreach (ComboBox item in comboBoxes)
                        {
                            if (item.Text == "")
                            {
                                MessageBox.Show("Algun campo esta vacio");
                                vacio = true;
                                break;
                            }
                            if (item.Items.Count == 0)
                            {
                                sincampos = true;
                                break;
                            }
                            if (!item.Items.Contains(item.Text))
                            {

                                referencia = true;
                                break;
                            }
                        }
                        if (!vacio && !sincampos && !referencia)
                        {

                            AgregarDataGridView();

                        }
                        else
                        {
                            MessageBox.Show("Error en referencia ");
                        }


                    }
                }
                else
                {
                    bool vacio = false;
                    bool sincampos = false;
                    bool referencia = false;

                    foreach (ComboBox item in comboBoxes)
                    {
                        if (item.Text == "")
                        {
                            MessageBox.Show("Algun campo esta vacio");
                            vacio = true;
                            break;
                        }
                        if (item.Items.Count == 0)
                        {
                            sincampos = true;
                            break;
                        }
                        if (!item.Items.Contains(item.Text))
                        {

                            referencia = true;
                           
                        }
                    }
                    if (!vacio && !sincampos && !referencia)
                    {

                        AgregarDataGridView();

                    }
                    else
                    {
                        MessageBox.Show("Error en referencia ");
                    }

                }


            }
        }
        /// <summary>
        /// Funcion que se encargade poner el nuevo registro en el dataGridView
        /// </summary>
        private void AgregarDataGridView()
        {
            int n = dataGridView1.Rows.Add();
            for (int i = 0; i < textBoxes.Count; i++)
            {
                dataGridView1.Rows[n].Cells[i].Value = textBoxes[i].Text.Replace(',', '.');

                textBoxes[i].Text = "";
            }

            if (comboBoxes.Count > 0)
            {
                for (int i = 0; i < comboBoxes.Count; i++)
                {
                    dataGridView1.Rows[n].Cells[i + textBoxes.Count].Value = comboBoxes[i].Text;
                }

            }
            GuardarData();
        }
        /// <summary>
        /// Funcion que guarda el registro en el archivo, lo toma directamente del dataGriedView
        /// </summary>
        private void GuardarData()
        {
            string datos = "";

            int columna = 0;
            if (tablaRegistros._datos != null)
            {
                tablaRegistros._datos.Clear();

            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (row.Cells[i].Value != null)
                    {
                        if (i + 1 == row.Cells.Count)
                        {
                            datos += tablaRegistros._Atributos[columna]._NombreAtributo.ToString() + ":" + row.Cells[i].Value.ToString();
                            columna++;
                        }
                        else
                        {
                            datos += tablaRegistros._Atributos[columna]._NombreAtributo.ToString() + ":" + row.Cells[i].Value.ToString() + ",";
                            columna++;

                        }
                    }
                }
                if (datos.ToString() != "")
                {
                    tablaRegistros._datos.Add(datos);

                }
                datos = "";
                columna = 0;
            }
            Archivo.GuardaBase(baseActual);
        }
        /// <summary>
        /// Funcion que verifica que el tipo de dato sea el correcto en un texbox 
        /// </summary>
        /// <param name="atributo">El atributo que se va a verificar</param>
        /// <param name="idTextbox">id del texbox que donde se puso el dato</param>
        /// <returns></returns>
        private bool chechaTipoDato(Atributo atributo, int idTextbox)
        {
            bool ban = false;
            if (textBoxes[idTextbox].Text == "")
            {
                MessageBox.Show("Debes de completar todos los campos correctamente");
                ban = true;
            }
            else
            {

                if (atributo._TipoDato == 'E')
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxes[idTextbox].Text, "^[0-9][0-9]*$"))
                    {
                        MessageBox.Show("El campo: " + labels[idTextbox].Text + " solo acepta numeros enteros");
                        textBoxes[idTextbox].Text = "";
                        ban = true;
                    }
                    else
                    {
                        ban = false;
                    }
                }
                else if (atributo._TipoDato == 'F')
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxes[idTextbox].Text, "^-?[0-9]+(?:.[0-9]+)?$"))
                    {
                        MessageBox.Show("El campo: " + labels[idTextbox].Text + " solo acepta numeros Flotantes");
                        textBoxes[idTextbox].Text = "";
                        ban = true;
                    }
                    else
                    {
                        ban = false;
                    }
                }

            }

            return ban;
        }
       /// <summary>
       /// Funcion que checa si existe alguna referencia en alguna otra tabla
       /// </summary>
       /// <returns></returns>
        private bool ChecarReferecia() {
            bool ban = false;
            int indicePK;
            int indiceFK;
            List<List<string>> datosActuales = new List<List<string>>();
            datosActuales = obten_registros(tablaRegistros);
            indicePK= BuscaClavePrimaria(tablaRegistros);
            
            foreach (Tabla item in baseActual.Tablas)
            {
                foreach (Atributo A in item._Atributos)
                {
                    if (tablaRegistros._NombreTabla==A._NombreFK&&item._datos.Count>0)
                    {   
                        List<List<string>> datosReferencia = new List<List<string>>();
                        datosReferencia= obten_registros(item);
                        indiceFK = BuscaIndiceKF(item);

                        
                        
                            foreach (List<string> DK in datosReferencia)
                            {
                                if (datosActuales[dataGridView1.CurrentRow.Index][indicePK] == DK[indiceFK])
                                {
                                    ban = true;
                                    break;
                                }
                            }  
                        
                    }
                }
            }
            if (ban)
            {
                MessageBox.Show("Esta tabla esta referenciada en otro lugar, no se puede modificar su clave Primaria, los demas elementos se actualizaran");
            }
            return ban;
        }
        /// <summary>
        /// funcion que busca el indice cuando hay clave FK
        /// </summary>
        /// <param name="tabla">Tabla donde se buscara la Clave FK</param>
        /// <returns>Indice del atributo donde se encuentra esa clave FK</returns>
        private int BuscaIndiceKF(Tabla tabla)
        {
            int PK = new int();
            for (int i = 0; i < tabla._Atributos.Count; i++)
            {
                if (tabla._Atributos[i]._NombreFK == tablaRegistros._NombreTabla)
                {
                    PK = i;
                }
            }
            return PK;
        }
        /// <summary>
        /// Funcion que busca dentro de una tabla cual es el indice de su clave PK
        /// </summary>
        /// <param name="tabla">Tabla donde se buscara la clave PK</param>
        /// <returns>indice de donde se encuentra el indice PK</returns>
        private int BuscaClavePrimaria(Tabla tabla)
        {
            int PK = new int();
            for (int i = 0; i < tabla._Atributos.Count; i++)
            {
                if (tabla._Atributos[i]._TipoLLave==1)
                {
                    PK = i;
                }
            }
            return PK;
        }

        /// <summary>
        /// Evento del boton para poder eliminar algun registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (!ChecarReferecia())
            {
                if (dataGridView1.Rows.Count == 1)
                    return;
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                tablaRegistros._datos.RemoveAt(dataGridView1.CurrentRow.Index);
                Archivo.GuardaBase(baseActual);

            }
        }
        /// <summary>
        /// Funcion que elimina el nombre del atributo en los datos
        /// </summary>
        /// <param name="tupla">Registro completo</param>
        /// <param name="t">tabla donde se encuentra</param>
        /// <returns>cadena con la informacion del registro </returns>
        private string elimina_nombre_atributo(string tupla, Tabla t)
        {
            foreach (string atributo in t.lista_nombre_atributos())
                tupla = tupla.Replace(atributo + ":", "");
         /*   if (id != "")
                tupla = tupla.Replace(id + ":", "");
         */
            return tupla;
        }
       /// <summary>
       /// Funcion que obtienen todos los registros dentro de la tabla Actual
       /// </summary>
       /// <param name="t">Tabla donde se obtendran los registros</param>
       /// <returns>Lista de listas de cadenas con cada registro separado por atributos</returns>
        private List<List<string>> obten_registros(Tabla t)
        {
            List<List<string>> registros = new List<List<string>>();
            // por cada tupla
            for (int i = 0; i < t._datos.Count; i++)
            {
                registros.Add(new List<string>());

                // separamos la tupla por cada uno de sus metadatos
                string[] datos_split = elimina_nombre_atributo(t._datos[i], t).Split(',');
                // por cada metadato
                for (int j = 0; j < datos_split.Length; j++)
                {
                   
                        // simplemente añadimos el registro
                        registros.Last().Add(datos_split[j]);
                   
                }
            }
          
            return registros;
        }
       /// <summary>
       /// Funcion que se encarga de checar si se puede eliminar un dato referenciado
       /// </summary>
       /// <returns>Si se puede eliminar o no</returns>
        public bool checarReferenciaElimina() {
            bool ban = false;
            foreach (Tabla item in baseActual.Tablas)
            {
                foreach (Atributo A in item._Atributos)
                {
                    if (tablaRegistros._NombreTabla == A._NombreFK && item._datos.Count > 0)
                    {

                        ban = true;
                        break;
                    }
                }
            }
            if (ban)
            {
                MessageBox.Show("Esta tabla esta referenciada en otro lugar, no se puede modificar su clave Primaria, los demas elementos se actualizaran");
            }
            return ban;

        }
        /// <summary>
        /// Evenot del boton para poder modificar la informacion de un registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            int numTextBox = 0;
            bool PKrepetida = false;

            foreach (TextBox item in textBoxes)
            {
                if (item.Text != "")
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
                            if (tablaRegistros._Atributos[numTextBox]._TipoLLave == 1)
                            {

                                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
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
                                if (!PKrepetida && !ChecarReferecia())
                                {
                                    dataGridView1.CurrentRow.Cells[numTextBox].Value = item.Text;
                                    textBoxes[numTextBox].Text = "";
                                }
                            }
                            else
                            {
                                dataGridView1.CurrentRow.Cells[numTextBox].Value = item.Text;
                                textBoxes[numTextBox].Text = "";
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
                    else if (tablaRegistros._Atributos[numTextBox]._TipoDato == 'C') {

                        dataGridView1.CurrentRow.Cells[numTextBox].Value = item.Text;
                    }

                }
                numTextBox++;
            }
            if (comboBoxes.Count > 0)
            {
                
                foreach (ComboBox combo in comboBoxes)
                {
                    
                    if (combo.Text != ""&&!checarReferenciaElimina())
                    {

                        dataGridView1.CurrentRow.Cells[numTextBox - 1 + comboBoxes.Count].Value = combo.Text;

                    }
                }
            }
            GuardarData();
        }
    }
}
