using System.Collections.Generic;

namespace BasesDatos
{
    /// <summary>
    /// Clase que define a una tabla dentro de una base de datos.
    /// </summary>
    public class Tabla
    {
        private string NombreTabla;
        private List<Atributo> atributos;
        private List<string> datos;

        /// <summary>
        /// Constructor de la tabla
        /// </summary>
        /// <param name="nombre">Nombre de la tabla</param>
        public Tabla(string nombre)
        {
            NombreTabla = nombre;
            atributos = new List<Atributo>();
            datos = new List<string>();
        }
        /// <summary>
        /// Construcor de la Tabla
        /// </summary>
        public Tabla()
        {
            atributos = new List<Atributo>();
            datos = new List<string>();
        }
        /// <summary>
        /// Funcion que lista los nombres de cada atributo
        /// </summary>
        /// <returns>nombre_atributos</returns>
        public List<string> lista_nombre_atributos()
        {
            List<string> nombres_atributos = new List<string>();

            for (int i = 0; i < atributos.Count; i++)
            {
                nombres_atributos.Add("");
                nombres_atributos[i] = atributos[i]._NombreAtributo;
            }
                

            return nombres_atributos;
        }
        /// <value> Gets and set la lista de atributos de la tabla .</value>
        public List<Atributo> _Atributos { get { return atributos; } set { atributos = value; } }
        /// <value>Gets and set el nombre de la tabla</value>
        public string _NombreTabla { get { return NombreTabla; } set { NombreTabla = value; } }
        /// <value> Gets and set la lista de datos de la tabla .</value>
        public List<string> _datos { get { return datos; } set { datos = value; } }
    }
}
