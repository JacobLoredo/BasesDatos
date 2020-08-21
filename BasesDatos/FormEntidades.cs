using System;
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
            if (baseActual != null)
            {
                label1.Text += " " + baseActual._NombreBD;
                cargaTablas();
            }

        }
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
        public void actualizaDataGrid()
        {
            DataGridEntidades.Rows.Clear();

            foreach (Tabla tb in baseActual.Tablas)
            {
                int n = DataGridEntidades.Rows.Add();

                DataGridEntidades.Rows[n].Cells[0].Value = tb._NombreTabla;

            }
        }
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
        public void ModificaNombreTabla(int index)
        {
            Archivo.EliminaTabla(baseActual.Tablas[index]._NombreTabla);
            baseActual.Tablas[index]._NombreTabla = textBox1.Text;
            Archivo.GuardarTabla(baseActual.Tablas[index]);
            Archivo.GuardaBase(baseActual);
        }
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

        private void btnBotonEliminar_Click(object sender, EventArgs e)
        {

            BuscaTablaEliminar();
        }
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
