using System.Collections.Generic;

namespace BasesDatos
{
    /// <summary>
    /// Clase que crea una base de datos 
    /// </summary>
    public class BaseDatos
    {
        private string NombreBD;
        private List<Tabla> tablas;
        /// <summary>
        /// Constructor de la clase BD
        /// </summary>
        /// <param name="Nombre">Nombre de la base de datos</param>
        public BaseDatos(string Nombre)
        {
            NombreBD = Nombre;
            tablas = new List<Tabla>();
        }
       /// <summary>
       /// Funcion que obtiene una tabla en expecifico
       /// </summary>
       /// <param name="tabla"> Nombre de la tabla a buscar</param>
       /// <returns></returns>
        public Tabla obten_tabla(string tabla)
        {
            return Tablas.Find(t => t._NombreTabla == tabla);
        }
        public bool existe_tabla(string tabla)
        {
            return Tablas.Exists(t => t._NombreTabla == tabla);
        }
       /// <summary>
       /// Get and Set que regresa todas las tablas en la base de datos
       /// </summary>
        public List<Tabla> Tablas { get { return tablas; } set { tablas = value; } }
        
        /// <summary>
        /// Get and Set que regresa el nombre de la base de datos
        /// </summary>
        public string _NombreBD { get { return NombreBD; } set { NombreBD = value; } }
    }
}
