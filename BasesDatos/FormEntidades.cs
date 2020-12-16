using System;
using System.Windows.Forms;

namespace BasesDatos
{
    /// <summary>
    /// Form para mostrar las tablas en la base de datos
    /// </summary>
    public partial class FormEntidades : Form
    {
        public Archivo Archivo;
        public BaseDatos baseActual;
        /// <summary>
        /// Constructor
        /// </summary>
        public FormEntidades()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Evento que pasa cuando recien inicia carga los elementos en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormEntidades_Load(object sender, EventArgs e)
        {
            if (baseActual != null)
            {
                label1.Text += " " + baseActual._NombreBD;
                cargaTablas();
            }

        }
        /// <summary>
        /// Funcion que se encarga de leer las tablas y las carga en el DataGriedView
        /// </summary>
        public void cargaTablas()
        {
            if (baseActual.Tablas.Count > 0)
            {
                foreach (Tabla item in baseActual.Tablas)
                {
                    int n = DataGridEntidades.Rows.Add();

                    DataGridEntidades.Rows[n].Cells[0].Value = item._NombreTabla;
                }
            }
        }
        /// <summary>
        /// Evento para agregar una nueva tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBotonAgregar_Click(object sender, EventArgs e)
        {
            int res = ChecaEntidadRepetida(textBox1.Text);
            if (res == 0)
            {
                Tabla tabla = new Tabla(textBox1.Text);

                baseActual.Tablas.Add(tabla);
                actualizaDataGrid();
                Archivo.GuardarTabla(tabla);
                Archivo.GuardaBase(baseActual);
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("La entidad deseada ya existe");
                textBox1.Text = "";
            }
        }
        /// <summary>
        /// Funcion que actualiza el contenido del DataGridView
        /// </summary>
        public void actualizaDataGrid()
        {
            DataGridEntidades.Rows.Clear();

            foreach (Tabla tb in baseActual.Tablas)
            {
                int n = DataGridEntidades.Rows.Add();

                DataGridEntidades.Rows[n].Cells[0].Value = tb._NombreTabla;

            }
        } 
        /// <summary>
        /// Funcion que comprueba si la tabla nueva a ingresar ya existe
        /// </summary>
        /// <param name="NombreEntidad">Nombre de la tabla nueva a ingresar</param>
        /// <returns></returns>

        public int ChecaEntidadRepetida(string NombreEntidad)
        {
            int repetido = 0;
            if (NombreEntidad != "")
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
        /// <summary>
        /// Funcion que busca la tabla para realizar la modificacion de nombre
        /// </summary>
        public void BuscaTablaModificar()
        {

            foreach (Tabla item in baseActual.Tablas)
            {
                if (item._NombreTabla == (string)DataGridEntidades.CurrentRow.Cells[0].Value)
                {

                    ModificaNombreTabla(baseActual.Tablas.IndexOf(item));
                    break;

                }

            }
        }
        /// <summary>
        /// Funcion que busca la tabla para poder eliminarla de la base de datos
        /// </summary>
        public void BuscaTablaEliminar()
        {

            foreach (Tabla item in baseActual.Tablas)
            {
                if (item._NombreTabla == (string)DataGridEntidades.CurrentRow.Cells[0].Value)
                {
                    Archivo.EliminaTabla(baseActual.Tablas[baseActual.Tablas.IndexOf(item)]._NombreTabla);
                    baseActual.Tablas.RemoveAt(baseActual.Tablas.IndexOf(item));
                    Archivo.GuardaBase(baseActual);
                    actualizaDataGrid();
                    break;

                }

            }
        }
        /// <summary>
        /// Funcion que busca el nombre de la tabla por indice para modificar el nombre
        /// </summary>
        /// <param name="index">indice de la tabla a modificar</param>
        public void ModificaNombreTabla(int index)
        {
            Archivo.EliminaTabla(baseActual.Tablas[index]._NombreTabla);
            baseActual.Tablas[index]._NombreTabla = textBox1.Text;
            Archivo.GuardarTabla(baseActual.Tablas[index]);
            Archivo.GuardaBase(baseActual);
        }
        /// <summary>
        /// Evento del boton para modificar una tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBotonModificar_Click(object sender, EventArgs e)
        {
            int res = ChecaEntidadRepetida(textBox1.Text);
            if (res == 0)
            {
                BuscaTablaModificar();
                actualizaDataGrid();
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("La entidad deseada ya existe");
                textBox1.Text = "";
            }

        }
        /// <summary>
        /// Evento del boton para eliminar una tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBotonEliminar_Click(object sender, EventArgs e)
        {
            BuscaTablaEliminar();
        }
        /// <summary>
        /// Funcion que regresa una tabla
        /// </summary>
        /// <returns>regresa la tabla si coincide con algun elemento existente</returns>
        public Tabla RegresaTabla()
        {
            Tabla tabla = new Tabla();
            foreach (Tabla item in baseActual.Tablas)
            {
                if (item._NombreTabla == (string)DataGridEntidades.CurrentRow.Cells[0].Value)
                {
                    tabla = item;
                    break;
                }

            }
            return tabla;

        }
       /// <summary>
       /// Evento del boton para agregar atributos dentro de una tabla en especifico
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btnBotonAgregarAtributos_Click(object sender, EventArgs e)
        {
            FormAtributos formAtributos = new FormAtributos(RegresaTabla(), baseActual);
            AddOwnedForm(formAtributos);
            formAtributos.FormBorderStyle = FormBorderStyle.None;
            formAtributos.TopLevel = false;
            formAtributos.Dock = DockStyle.Fill;
            this.Controls.Add(formAtributos);
            this.Tag = formAtributos;
            formAtributos.BringToFront();
            formAtributos.Show();


        }
    }
}
