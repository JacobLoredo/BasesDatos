using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BasesDatos.Modulo_SQL
{
    class Gramatica
    {
        public string tablaA, tablaB;
        public string id = "";
        public string signo = "";
        public string valor = "";
        public List<string> atributos;
        public bool sentencia_correcta;

        // Define a regular expression for repeated words.
        public Regex select_all = new Regex(
            @"(SELECT|select)\s+\*\s+(FROM|from)\s+\w+\s*;?\s*",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        // Define a regular expression for repeated words.
        Regex select_colums = new Regex(
            @"(SELECT|select)(\s+\w+,?)+\s+(FROM|from)\s+\w+\s*;?\s*",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        // Define a regular expression for repeated words.
        Regex select_where = new Regex(
            @"(SELECT|select)(\s+\w+,?)+\s+(FROM|from)\s+\w+\s*(WHERE|where)\s+\w+\s+(=|>|<|>=|<=|<>)\s+\d+\s*;?",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public Gramatica()
        {
            atributos = new List<string>();
            sentencia_correcta = false;
        }


        public bool coincide_select_all(string entrada)
        {
            MatchCollection mc = select_all.Matches(entrada);
            if (mc.Count == 1 && mc[0].Length == entrada.Length)
            {
                limpia_variables();
                Regex r = new Regex(@"(SELECT|select)\s+\*\s+(FROM|from)\s+");
                string res = r.Replace(entrada, "");
                r = new Regex(@"(\s|;)*");
                tablaA = r.Replace(res, "");
                sentencia_correcta = true;
                return true;
         
            }
            sentencia_correcta = false;
            return false;
        }

        public bool coincide_select_columns(string entrada)
        {
            MatchCollection mc = select_colums.Matches(entrada);
            if (mc.Count == 1 && mc[0].Length == entrada.Length)
            {
                limpia_variables();
                Regex r = new Regex(@"(SELECT|select)\s+");
                entrada = r.Replace(entrada, "");
                int indice_from = entrada.IndexOf("FROM");
                if(indice_from < 0)
                    indice_from = entrada.IndexOf("from");
                
                tablaA = entrada.Substring(indice_from + 5, entrada.Length - (indice_from + 5));
                tablaA = tablaA.Replace(";", "");
                r = new Regex(@"\s*");
                tablaA = r.Replace(tablaA, "");

                entrada = entrada.Substring(0, indice_from);
                entrada = entrada.Replace(",", "");
                atributos = entrada.Split(' ').ToList();
                atributos.RemoveAll(s => s == "");
                sentencia_correcta = true;
                return true;
            }
            sentencia_correcta = false;
            return false;
        }

        public bool coincide_select_where(string entrada)
        {
            MatchCollection mc = select_where.Matches(entrada); 
            if (mc.Count == 1 && mc[0].Length == entrada.Length)
            {
                limpia_variables();
                int indice_where = obten_condicion(entrada);
                Regex r = new Regex(@"(SELECT|select)\s+");
                entrada = r.Replace(entrada, "");
                int indice_from = entrada.IndexOf("FROM");
                if (indice_from < 0)
                    indice_from = entrada.IndexOf("from");
                
                tablaA = entrada.Substring(indice_from + 5, entrada.Length - (indice_where - 7));
                tablaA = tablaA.Replace(";", "");
                tablaA = tablaA.Split(' ')[0];
                r = new Regex(@"\s+");
                tablaA = r.Replace(tablaA, " ");

                entrada = entrada.Substring(0, indice_from);
                entrada = entrada.Replace(",", "");
                atributos = entrada.Split(' ').ToList();
                atributos.RemoveAll(s => s == "");
                sentencia_correcta = true;
                return true;
            }
            sentencia_correcta = false;
            return false;
        }

        public int obten_condicion(string entrada)
        {
            int indice_where = entrada.IndexOf("WHERE");
            if(indice_where < 0)
                indice_where = entrada.IndexOf("where");

            int w = indice_where + 5;
            int l = entrada.Length - w;
            entrada = entrada.Substring(w, l);

            entrada = entrada.Replace(";", "");
            List<string> condicion = entrada.Split(' ').ToList();
            condicion.RemoveAll(s => s == "");

            id = condicion[0];
            signo = condicion[1];
            valor = condicion[2];

            return indice_where + 5;
        }

        public void limpia_variables()
        {
            id = "";
            signo = "";
            valor = "";
            atributos.Clear();
            tablaA = "";
            tablaB = "";
        }

        public string obten_atributos()
        {
            string s = "";
            foreach (string str in atributos)
                s += str + " ";
            return s;
        }
    }
}
