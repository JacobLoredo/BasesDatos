using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasesDatos.Modulo_SQL
{
    public partial class SQL_formulario : System.Windows.Forms.Form
    {
        private TabPage nueva_tab;
        //private Gramatica mysql;
        private BaseDatos BD;
        private Select select;
        public SQL_formulario(BaseDatos bd)
        {
            this.BD = bd;
            select = new Select(BD);
            InitializeComponent();
            //mysql = new Gramatica();
            //clona_tab();
            tab_ctrl.TabPages[0].Text += " 1";
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

            foreach(Control c in tab_ctrl.TabPages[0].Controls)
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
            if(e.KeyCode == Keys.F5)
            {
                txt_compilacion.Text = ejecuta_sentencia();
                //MessageBox.Show("f5 pressed!");
            }
        }

        public string ejecuta_sentencia()
        {
            string entrada = txtb_entrada.Text;
            if (select.coincide_select_all(entrada))
            {
                select.ejecuta_select_all();
                txt_salida.Text = select.resultado;
                return "de la tabla " + select.tablaA + " muestra todos las tuplas.";
            }
            else if (select.coincide_select_columns(entrada))
                return "de la tabla " + select.tablaA + " muestra todos las tuplas pero solo con los atributos " + select.obten_atributos();
            else if (select.coincide_select_where(entrada))
                return "de la tabla " + select.tablaA + " muestra todos las tuplas pero solo con los atributos " + select.obten_atributos() + " y se cumple que el atributo " + select.id + " " + select.signo + " " + select.valor;
            return "no coincide!";
        }

        private void ejecutarSentenciaF5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txt_compilacion.Text = ejecuta_sentencia();
        }
    }
}

