using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasesDatos.Modulo_SQL
{
    class Select : Gramatica
    {
        public string resultado;
        private BaseDatos BD;
        public Select(BaseDatos bd)
        {
            resultado = "";
            this.BD = bd;
        }
        public string ejecuta_select_all()
        {
            foreach (Tabla t in BD.Tablas)
            {
                if(t._NombreTabla.Replace(" ", "") == tablaA)
                {
                    resultado = tablaA + "\r\n";
                    foreach(Atributo a in t._Atributos)
                    {
                        resultado += a._NombreAtributo + "\t";
                    }
                    resultado += "\r\n";
                    foreach (string s in t._datos)
                        resultado += s + "\r\n";
                }
            }
            return resultado;
        }

        public string ejecuta_select_columns()
        {
            List<int> ind_atributos_no_seleccionados = new List<int>();

            foreach (Tabla t in BD.Tablas)
            {
                if (t._NombreTabla.Replace(" ", "") == tablaA)
                {
                    resultado = tablaA + "\r\n";
                    for (int i = 0; i < t._Atributos.Count; i++)
                    {
                        if (!this.atributos.Contains(t._Atributos[i]._NombreAtributo))
                        {
                            ind_atributos_no_seleccionados.Add(i);
                        }
                        else
                        {
                            resultado += t._Atributos[i]._NombreAtributo + "\t";
                        }
                    }
                    resultado += "\r\n";
                    
                    for (int i = 0; i < t._datos.Count; i++)
                    {
                        string[] datos_split = t._datos[i].Split(',');
                        for(int j = 0; j < datos_split.Length; j++)
                        {
                            if (!ind_atributos_no_seleccionados.Contains(j))
                                resultado += datos_split[j] + "\t";
                        }
                        resultado += "\r\n";
                    }

                }
            }
            return resultado;
        }

        public List<string> divide_atributos(List<int> indices, string datos)
        {
            List<string> datos_separados = datos.Split(',').ToList();
            datos_separados.RemoveAll(s => s == "");

            List<string> nuevos_datos = new List<string>();
            for (int i = 0; i < indices.Count; i++)
                nuevos_datos.Add(datos_separados[indices[i]]);
            return nuevos_datos;
        }
    }
}
