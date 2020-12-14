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

        public BaseDatos(string Nombre)
        {
            NombreBD = Nombre;
            tablas = new List<Tabla>();
        }
        public BaseDatos()
        {
            NombreBD = "";
            tablas = new List<Tabla>();

        }
        public Tabla obten_tabla(string tabla)
        {
            return Tablas.Find(t => t._NombreTabla == tabla);
        }
        public bool existe_tabla(string tabla)
        {
            return Tablas.Exists(t => t._NombreTabla == tabla);
        }
        public List<Tabla> Tablas { get { return tablas; } set { tablas = value; } }
        public string _NombreBD { get { return NombreBD; } set { NombreBD = value; } }




    }
}
