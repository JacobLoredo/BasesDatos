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
        public List<string> atributos_tablaA, atributos_tablaB;
        public List<List<string>> datos;
        public List<string> ansA, ansB;
        public BaseDatos BD;
        public bool resuelve_ambiguedad;
        public Select(BaseDatos bd)
        {
            resuelve_ambiguedad = false;
            resultado = "";
            this.BD = bd;
            datos = new List<List<string>>();
            ansA = new List<string>();
            ansB = new List<string>();
            atributos_tablaA = new List<string>();
            atributos_tablaB = new List<string>();
        }

        #region ejecuciones 
        public bool ejecuta_select_all()
        {
            foreach (Tabla t in BD.Tablas)
            {
                if (t._NombreTabla.Replace(" ", "") == tablaA)
                {
                    if (atributos_repetidos())
                    {
                        resultado = "Existen atributos repetidos!.";
                        return false;
                    }

                    inicializa_variables(t, null);

                    foreach (Atributo a in t._Atributos)
                    {
                        resultado += a._NombreAtributo + "\t";
                        this.atributos.Add(a._NombreAtributo);
                    }

                    datos = obten_registros(t, false);
                    resultado = "Ejecución terminada correctamente.";
                    return true;
                }
            }
            resultado = "La tabla no existe!.";
            return false;
        }

        private bool atributos_repetidos()
        {
            foreach(string atr in this.atributos)
            {
                if (this.atributos.Count(a => a == atr) > 1)
                    return true;
            }
            return false;
        }

        public bool ejecuta_select_columns(bool where)
        {
            foreach (Tabla t in BD.Tablas)
            {
                if (t._NombreTabla.Replace(" ", "") == tablaA)
                {
                    inicializa_variables(t, null);
                    if (atributos_repetidos())
                    {
                        resultado = "Existen atributos repetidos!.";
                        return false;
                    }
                    // verificamos que existan todos los atributos a mostrar
                    if (!verifica_atributos(t, where))
                    {
                        resultado = "Algun atributo no existe!";
                        return false;
                    }

                    //reorganiza_atributos(t, null);
                    ansA = separa_atributos_a_mostrar(t, false);

                    datos = obten_registros(t, where);
                    resultado = "Ejecución terminada correctamente.";
                    return true;
                }
            }
            resultado = "La tabla no existe!.";
            return false;
        }
        #endregion

        public bool ejecuta_inner_join()
        {
            // comprobamos que existan las dos tablas
            Tabla ta = BD.obten_tabla(tablaA);
            Tabla tb = BD.obten_tabla(tablaB);

            if (ta != null && tb != null)
            {
                // comprobamos que las tablas referenciadas por los atributos existan
                if (!verifica_tablas(ta, tb, this.atributos))
                {
                    resultado = "No existe alguna tabla referenciada!.";
                    return false;
                }

                // comprobamos que los atributos seleccionados existan al menos en una de las dos tablas
                foreach (string a in atributos)
                {
                    if (atributos_repetidos())
                    {
                        resultado = "Existen atributos repetidos!.";
                        return false;
                    }

                    if (verifica_atributos(ta, new string[] { a }) && verifica_atributos(tb, new string[] { a }))
                    {
                        // verificamos que los atributos de cada tabla existan
                        if(!(verifica_atributos(ta) && verifica_atributos(tb)))
                        {
                            resultado = "Algun atributo no existe en una de las tablas!.";
                            return false;
                        }
                    }
                    if (!verifica_atributos(ta, new string[] { a }) && !verifica_atributos(tb, new string[] { a }))
                    {
                        resultado = "Un atributo no existe en ninguna de las dos tablas!.";
                        return false;
                    }
                }

                inicializa_variables(ta, tb);

                //reorganiza_atributos(ta, tb);

                ansA = separa_atributos_a_mostrar(ta, false);
                ansB = separa_atributos_a_mostrar(tb, false);

                int ind_atr_tA = ta.lista_nombre_atributos().ToList().IndexOf(atributo_inner);
                int ind_atr_tB = tb.lista_nombre_atributos().ToList().IndexOf(atributo_inner);

                // obtenemos todos las tuplas que cumplen la condicion
                datos = obten_tuplas_inner_join(ta, tb, ind_atr_tA, ind_atr_tB);
                resultado = "Ejecución terminada correctamente!.";
                return true;
            }
            resultado = "La tabla no existe!.";
            return false;
        }

        #region verificaciones
        public bool cumple_condicion(Tabla t, string[] tupla)
        {
            int indice_atributo_condicional = t.lista_nombre_atributos().ToList().IndexOf(id);

            if (indice_atributo_condicional >= 0)
            {
                float valor_f = float.Parse(this.valor, System.Globalization.CultureInfo.InvariantCulture);
                float valor_tupla = float.Parse(tupla[indice_atributo_condicional], System.Globalization.CultureInfo.InvariantCulture);
                switch (signo)
                {
                    case "=":
                        return valor_tupla == valor_f;
                    case ">":
                        return valor_tupla > valor_f;
                    case "<":
                        return valor_tupla < valor_f;
                    case ">=":
                        return valor_tupla >= valor_f;
                    case "<=":
                        return valor_tupla <= valor_f;
                    case "<>":
                        return valor_tupla != valor_f;
                    default:
                        return false;
                }
            }
            return false;
        }

        public bool hay_tablas()
        {
            if (BD == null)
                return false;
            if (BD.Tablas == null)
                return false;
            if (BD.Tablas.Count == 0)
            {
                resultado = "No hay tablas!.";
                return false;
            }
            return true;
        }
        
        private bool verifica_atributos(Tabla t, bool where)
        {
            if (!verifica_atributos(t, this.atributos.ToArray()))
                return false;

            if (where)
                return verifica_where(t);

            return true;
        }

        private bool verifica_atributos(Tabla t, string[] atributos)
        {
            List<string> atrs = t.lista_nombre_atributos().ToList();

            foreach (string s in obten_parte_atributos(atributos.ToList()))
                if (!atrs.Contains(s))
                    return false;
            return true;
        }

        private bool verifica_tablas(Tabla a, Tabla b, List<string> atributos)
        {
            string t = "";
            foreach(string s in atributos)
            {
                if (s.Contains('.'))
                {
                    t = s.Substring(0, s.IndexOf('.'));
                    if (a._NombreTabla != t && b._NombreTabla != t)
                        return false;
                }
            }
            return true;
        }

        private bool verifica_atributos(Tabla tabla)
        {
            List<string> atr_de_tabla = new List<string>();

            foreach(string s in atributos)
            {

                if(s.IndexOf(tabla._NombreTabla) == 0)
                {
                    atr_de_tabla.Add(s.Substring((s.IndexOf('.') + 1), (s.Length - s.IndexOf('.') - 1)));
                }
            }
            return verifica_atributos(tabla, atr_de_tabla.ToArray());
        }

        private bool verifica_where(Tabla t)
        {
            List<string> nombre_atributos = t.lista_nombre_atributos().ToList();

            if (id != "" && !nombre_atributos.Contains(id))
                return false;

            int indice_atr_id = nombre_atributos.ToList().IndexOf(id);

            if (indice_atr_id >= 0)
            {
                if (t._Atributos[indice_atr_id]._TipoDato.ToString().ToUpper() == "C")
                    return false;
            }
            else if (id != "")
                return false;
            return true;
        }
        #endregion

        #region utilidades
        private List<List<string>> obten_tuplas_inner_join(Tabla a, Tabla b, int ia, int ib)
        {
            List<List<string>> ra = obten_registros(a, false);
            List<List<string>> rb = obten_registros(b, false);
            List<List<string>> resultado = new List<List<string>>();

            int num_atrA = ra[0].Count;
            int num_atrB = rb[0].Count;

            string id_ta;

            for (int i = 0; i < ra.Count; i++)
            {
                id_ta = ra[i][ia];
                foreach (List<string> list in rb.FindAll(tupla => tupla[ib] == id_ta))
                {
                    resultado.Add(clona_lista(ra[i]));
                    foreach(string s in list)
                    {
                        resultado.Last().Add(s);
                    }
                }
            }

            resultado.RemoveAll(list => list.Count < (num_atrA + num_atrB));

            return resultado;
        }

        private List<string> clona_lista(List<string> lista)
        {
            List<string> clona = new List<string>();
            foreach (string s in lista)
                clona.Add(s);
            return clona;
        }

        private string elimina_nombre_atributo(string tupla, Tabla t)
        {
            foreach (string atributo in t.lista_nombre_atributos())
                tupla = tupla.Replace(atributo+":", "");
            if(id != "")
                tupla = tupla.Replace(id + ":", "");
            return tupla;
        }

        /// <summary>
        /// Obtiene los indices de los atributos que deseamos mostrar
        /// </summary>
        private List<int> separa_atributos_a_mostrar(Tabla t)
        {
            List<int> res = new List<int>();
            // separamos los atributos que nos interesan de los que no
            for (int i = 0; i < t._Atributos.Count; i++)
            {
                if (!this.atributos.Contains(t._Atributos[i]._NombreAtributo))
                    res.Add(i);
            }

            return res;
        }

        private List<string> separa_atributos_a_mostrar(Tabla t, bool hola)
        {
            List<string> res = new List<string>();

            List<string> atributos_especificos = obten_parte_atributos(null);

            // separamos los atributos que nos interesan de los que no
            for (int i = 0; i < t._Atributos.Count; i++)
            {
                if (!atributos_especificos.Contains(t._Atributos[i]._NombreAtributo))
                    res.Add(t._Atributos[i]._NombreAtributo);
            }

            return res;
        }

        public List<string> obten_parte_atributos(List<string> lista_atributos)
        {
            List<string> atributos_especificos = new List<string>();
            string t = "";
            
            List<string> atributos_usar;

            if (lista_atributos != null)
                atributos_usar = lista_atributos;
            else
                atributos_usar = this.atributos;

            foreach (string atr in atributos_usar)
            {
                // si contiene un punto, solo obtenemos el nombre del atributo
                if (atr.Contains('.'))
                {
                    t = atr.Substring((atr.IndexOf('.') + 1), (atr.Length - atr.IndexOf('.') - 1));
                    atributos_especificos.Add(t);
                }
                else
                    atributos_especificos.Add(atr);
            }

            return atributos_especificos;
        }

        /// <summary>
        /// Obtiene los datos de la tabla
        /// </summary>
        /// <param name="t"></param>
        /// <param name="where"></param>
        private List<List<string>> obten_registros(Tabla t, bool where) 
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
                    if (where)
                    {
                        // comprobamos que cumpla la condicion
                        if (cumple_condicion(t, datos_split))
                        {
                            // se cumple, añadimos el registro
                            registros.Last().Add(datos_split[j]);
                        }
                    }
                    else
                    {
                        // simplemente añadimos el registro
                        registros.Last().Add(datos_split[j]);
                    }
                }
            }
            if (where)
                // limpiamos las tuplas que quedaron vacias por no cumplir la condicional
                registros.RemoveAll(l => l.Count == 0);
            return registros;
        }

        private void inicializa_variables(Tabla ta, Tabla tb)
        {
            atributos_tablaA = new List<string>();
            atributos_tablaB = new List<string>();
            ansA = new List<string>();
            ansB = new List<string>();
            if (ta != null)
                atributos_tablaA = ta.lista_nombre_atributos();
            if (tb != null)
                atributos_tablaB = tb.lista_nombre_atributos();
            datos.Clear();
        }

        /*private void reorganiza_atributos(Tabla ta, Tabla tb)
        {
            for (int i = 0; i < this.atributos.Count; i++)
            {
                if (ta != null)
                    orden_atrA.Add(ta.lista_nombre_atributos().ToList().IndexOf(this.atributos[i]));
                if (tb != null)
                    orden_atrB.Add(tb.lista_nombre_atributos().ToList().IndexOf(this.atributos[i]));
            }
        }*/
        #endregion
    }
}

