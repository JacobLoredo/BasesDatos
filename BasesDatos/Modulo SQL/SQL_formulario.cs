using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BasesDatos.Modulo_SQL
{
    public partial class SQL_formulario : System.Windows.Forms.Form
    {
        private TabPage nueva_tab;
        //private Gramatica mysql;
        private BaseDatos BD;
        private Select select;
        private bool ejecuta;
        public SQL_formulario(BaseDatos bd)
        {
            ejecuta = false;
            this.BD = bd;
            select = new Select(BD);
            InitializeComponent();
            //mysql = new Gramatica();
            //clona_tab();
            tab_ctrl.TabPages[0].Text += " 1";
        }

        public void actualiza_bd(BaseDatos nueva_bd)
        {
            select.BD = nueva_bd;
        }
        private void Agrega_nueva_pestaña_sql(object sender, EventArgs e)
        {

            return;
            TextBox entrada = new TextBox()
            {
                Font = new Font("Consolas", 12),
                Multiline = true,
                //Dock = DockStyle.Top,
            };

            TextBox salida = new TextBox()
            {
                Multiline = true,
                //Dock = DockStyle.Fill,
            };

            TextBox compilacion = new TextBox()
            {
                Multiline = true,
                //Dock = DockStyle.Bottom,
            };
            nueva_tab = new TabPage();
            nueva_tab.Controls.Add(entrada);
            nueva_tab.Controls.Add(salida);
            nueva_tab.Controls.Add(compilacion);

            nueva_tab.Controls[nueva_tab.Controls.Count - 3].Dock = DockStyle.Top;
            nueva_tab.Controls[nueva_tab.Controls.Count - 1].Dock = DockStyle.Bottom;
            nueva_tab.Controls[nueva_tab.Controls.Count - 2].Dock = DockStyle.Fill;


            nueva_tab.Text = "SQL " + tab_ctrl.TabPages.Count + 1;
            tab_ctrl.TabPages.Add(nueva_tab);
        }

        public void clona_tab()
        {
            nueva_tab = new TabPage();

            foreach (Control c in tab_ctrl.TabPages[0].Controls)
            {
                Control nc = (Control)Activator.CreateInstance(c.GetType());
                PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(c);

                foreach (PropertyDescriptor entrada in pdc)
                {
                    object val = entrada.GetValue(c);
                    entrada.SetValue(nc, val);
                }

                // add control to new TabPage
                nueva_tab.Controls.Add(nc);
            }

        }

        private void tab_ctrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                txt_compilacion.Text = ejecuta_sentencia();
                muestra_resultados_grid();
                //MessageBox.Show("f5 pressed!");
            }
        }

        public string ejecuta_sentencia()
        {
            ejecuta = true;
            // si no hay tablas, amonos
            if (!select.hay_tablas())
            {
                ejecuta = false;
                return "Abre una base de datos primero!.";
            }
            string entrada = txtb_entrada.Text;
            if (select.coincide_select_all(entrada) && select.ejecuta_select_all())
            {
                txt_salida.Text = select.resultado;
                return "de la tabla " + select.tablaA + " muestra todos las tuplas.";
            }
            else if (select.coincide_select_columns(entrada) && select.ejecuta_select_columns(false))
            {
                txt_salida.Text = select.resultado;
                return "de la tabla " + select.tablaA + " muestra todos las tuplas pero solo con los atributos " + select.obten_atributos();
            }
            else if (select.coincide_select_where(entrada) && select.ejecuta_select_columns(true))
            {
                txt_salida.Text = select.resultado;
                return "de la tabla " + select.tablaA + " muestra todos las tuplas pero solo con los atributos " + select.obten_atributos() + " y se cumple que el atributo " + select.id + " " + select.signo + " " + select.valor;
            }
            else if (select.coincide_inner_join(entrada) && select.ejecuta_inner_join())
            {
                return select.resultado;
            }
            ejecuta = false;
            limpia_grid();
            return select.resultado;
        }

        private void ejecutarSentenciaF5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txt_compilacion.Text = ejecuta_sentencia();
            muestra_resultados_grid();
        }

        public void limpia_grid()
        {
            if (select.atributos != null)
            {
                dgv_resultados.Columns.Clear();
                dgv_resultados.Rows.Clear();
            }
        }

        private void muestra_resultados_grid()
        {
            if (!ejecuta)
                return;
            limpia_grid();

            // agregando el encabezado del grid
            for (int i = 0; i < select.atributos_tablaA.Length; i++)
            {
                if(!select.resuelve_ambiguedad)
                    dgv_resultados.Columns.Add(select.atributos_tablaA[i], select.atributos_tablaA[i]);
                else
                    dgv_resultados.Columns.Add(select.tablaA + "." + select.atributos_tablaA[i], select.tablaA + "." + select.atributos_tablaA[i]);
            }

            for (int i = 0; i < select.atributos_tablaB.Length; i++)
            {
                if (!select.resuelve_ambiguedad)
                    dgv_resultados.Columns.Add(select.atributos_tablaB[i], select.atributos_tablaB[i]);
                else
                    dgv_resultados.Columns.Add(select.tablaB + "." + select.atributos_tablaB[i], select.tablaB + "." + select.atributos_tablaB[i]);
            }

            // agregando los datos
            for (int i = 0; i < select.datos.Count; i++)
            {
                dgv_resultados.Rows.Add(select.datos[i].ToArray());
            }

            // ocultando las columnas que no nos interesan
            for (int i = 0; i < select.atr_no_selA.Count; i++)
                dgv_resultados.Columns[select.atr_no_selA[i]].Visible = false;

            int desplazamiento = select.atr_no_selA.Count + 1;

            for (int i = 0; i < select.atr_no_selB.Count; i++)
                dgv_resultados.Columns[select.atr_no_selB[i] + desplazamiento].Visible = false;

            // reorganizando las columnas
            for (int i = 0; i < select.orden_atrA.Count; i++)
                dgv_resultados.Columns[select.orden_atrA[i]].DisplayIndex = i;
        }

        private void resolverAmbiguedadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            select.resuelve_ambiguedad = false;
        }

        private void noResolverAmbiguedadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            select.resuelve_ambiguedad = true;
        }
    }
}

