using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BasesDatos.Modulo_SQL
{
    class Gramatica
    {
        public string tablaA, tablaB;
        public string id = "";
        public string signo = "";
        public string valor = "";
        public string atributo_inner = "";
        public List<string> atributos;
        public bool sentencia_correcta;

        /// <summary>
        /// Expresion regular para 'select * from tabla"
        /// </summary>
        public Regex select_all = new Regex(
            @"\s*\n*\t*(SELECT|select)\s+\*\s+(FROM|from)\s+(\w+)\s*;?\s*",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Expresion regular para 'select atributos from tabla"
        /// </summary>
        Regex select_colums = new Regex(
            @"\s*\n*\t*(SELECT|select)((\s+\w+,?)+)\s+(FROM|from)\s+(\w+)\s*;?\s*",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Expresion regular para 'select atributos from tabla id signo valor"
        /// </summary>
        Regex select_where = new Regex(
            @"\s*\n*\t*(SELECT|select)((\s+\w+,?)+)\s+(FROM|from)\s+(\w+)\s*(WHERE|where)\s+(\w+)\s+(=|>|<|>=|<=|<>)\s+(\d+)\s*;?",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        /// <summary>
        /// Expresion regular para 'select atributos from tA Inner Join tB On tA.atr = tB.atr"
        /// </summary>
        Regex inner_join = new Regex(
            @"\s*\n*\t*(SELECT|select)((\s+(\w+\.)?\w+,?)+)\s+(FROM|from)\s+(\w+)\s+(inner join|INNER JOIN)\s+(\w+)\s+(ON|on)\s+(\w+)\.(\w+)\s*=\s*(\w+)\.(\w+)\s*;?\s*",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public Gramatica()
        {
            atributos = new List<string>();
            sentencia_correcta = false;
        }


        public bool coincide_select_all(string entrada)
        {
            MatchCollection mc = select_all.Matches(entrada);
            GroupCollection gc = select_all.Match(entrada).Groups;

            if (mc.Count == 1 && mc[0].Length == entrada.Length)
            {
                limpia_variables();
                tablaA = limpia_cadena(gc[3].Value)[0];
                sentencia_correcta = true;
                return true;
            }
            sentencia_correcta = false;
            return false;
        }

        public bool coincide_select_columns(string entrada)
        {
            MatchCollection mc = select_colums.Matches(entrada);
            GroupCollection gc = select_colums.Match(entrada).Groups;

            if (mc.Count == 1 && mc[0].Length == entrada.Length)
            {
                limpia_variables();
                tablaA = gc[5].Value;
                atributos = limpia_cadena(gc[2].Value);
                sentencia_correcta = true;
                return true;
            }
            sentencia_correcta = false;
            return false;
        }

        public bool coincide_select_where(string entrada)
        {
            MatchCollection mc = select_where.Matches(entrada);
            GroupCollection gc = select_where.Match(entrada).Groups;

            if (mc.Count == 1 && mc[0].Length == entrada.Length)
            {
                limpia_variables();
                tablaA = gc[5].Value;
                atributos = limpia_cadena(gc[2].Value);
                id = gc[7].Value;
                signo = gc[8].Value;
                valor = gc[9].Value;
                sentencia_correcta = true;
                return true;
            }
            sentencia_correcta = false;
            return false;
        }

        public bool coincide_inner_join(string entrada)
        {
            MatchCollection mc = inner_join.Matches(entrada);
            GroupCollection gc = inner_join.Match(entrada).Groups;

            sentencia_correcta = false;

            if (mc.Count == 1 && mc[0].Length == entrada.Length)
            {
                limpia_variables();
                atributos = limpia_cadena(gc[2].Value);
                tablaA = gc[6].Value;
                tablaB = gc[8].Value;
                
                if(tablaA != gc[10].Value || tablaB != gc[12].Value)        
                    return false;
                
                string atrA = gc[11].Value, atrB = gc[13].Value;

                if (atrA != atrB)
                    return false;

                atributo_inner = atrA;

                sentencia_correcta = true;
                return true;
            }

            return false;
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

        /// <summary>
        /// Divide una serie de palabras separadas por espacios y comas
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns>
        /// Regresa una lista con solo las palabras
        /// </returns>
        private List<string> limpia_cadena(string cadena)
        {
            List<string> lista_atrs = new List<string>();
            Regex r = new Regex(@"\s+|,");
            lista_atrs = r.Replace(cadena, " ").Split(' ').ToList();
            lista_atrs.RemoveAll(s => s == "");
            return lista_atrs;
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
