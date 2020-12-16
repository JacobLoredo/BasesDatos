using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BasesDatos.Modulo_SQL
{
    /// <summary>
    /// Clase que se encarga de la parte sintactica de las consultas
    /// </summary>
    class Gramatica
    {
        /// <summary>
        /// Nombre de la tabla A
        /// </summary>
        public string tablaA;
        /// <summary>
        /// Nombre de la tabla B
        /// </summary>
        public string tablaB;
        /// <summary>
        /// Atributo a comprar
        /// </summary>
        public string id = "";
        /// <summary>
        /// Signo de comparación
        /// </summary>
        public string signo = "";
        /// <summary>
        /// Valor numérico a comprar
        /// </summary>
        public string valor = "";
        /// <summary>
        /// Atributo de union entre dos tablas
        /// </summary>
        public string atributo_inner = "";
        /// <summary>
        /// Lista de atributos referenciados por las sentencias
        /// </summary>
        public List<string> atributos;
        /// <summary>
        /// Indica si la sentencia es correcta o no
        /// </summary>
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

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Gramatica()
        {
            atributos = new List<string>();
            sentencia_correcta = false;
        }

        /// <summary>
        /// Verifica que una entrada coincida con la una consulta SELECT * FROM TABLA
        /// </summary>
        /// <param name="entrada">
        /// Cadena que contiene la consulta
        /// </param>
        /// <returns>
        /// Verdadero si coincide, falso en caso contrario</returns>
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
        /// <summary>
        /// Verifica que una entrada coincida con la una consulta SELECT ATRIBUTOS FROM TABLA
        /// </summary>
        /// <param name="entrada">
        /// Cadena que contiene la consulta
        /// </param>
        /// <returns>
        /// Verdadero si coincide, falso en caso contrario</returns>
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
        /// <summary>
        /// Verifica que una entrada coincida con la una consulta SELECT ATRIBUTOS FROM TABLA WHERE ID SIGNO VALOR
        /// </summary>
        /// <param name="entrada">
        /// Cadena que contiene la consulta
        /// </param>
        /// <returns>
        /// Verdadero si coincide, falso en caso contrario</returns>
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
        /// <summary>
        /// Verifica que una entrada coincida con la una consulta SELECT ATRIBUTOS FROM TABLA_A INNER JOIN TABLA_A ON TABLA_A.ID = TABLA_B.ID
        /// </summary>
        /// <param name="entrada">
        /// Cadena que contiene la consulta
        /// </param>
        /// <returns>
        /// Verdadero si coincide, falso en caso contrario</returns>
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

        /// <summary>
        /// Limpia las variables locales
        /// </summary>
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
        /// Regresa una lista con solo las palabras sin espacios ni comas
        /// </returns>
        private List<string> limpia_cadena(string cadena)
        {
            List<string> lista_atrs = new List<string>();
            Regex r = new Regex(@"\s+|,");
            lista_atrs = r.Replace(cadena, " ").Split(' ').ToList();
            lista_atrs.RemoveAll(s => s == "");
            return lista_atrs;
        }
    }
}
