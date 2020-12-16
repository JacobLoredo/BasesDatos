namespace BasesDatos
{
    /// <summary>
    /// Clase que crea un atributo con sus elementos 
    /// principales, nombre, tipo de dato, tipo de llave, 
    /// si contiene alguna referencua a otra tabla y el 
    /// tamaño que ocupa en memoria
    /// </summary>
    public class Atributo
    {
        private string NombreAtributo;
        private char TipoDato;
        private int TipoLlave;
        private string NombreFK;
        private int Tam;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="Nombre">Nombre del atributo</param>
        /// <param name="TDato">Tipo de datos (entero, flotante, cadena)</param>
        /// <param name="TLlave">Tipo de llave PK, FK o ninguna</param>
        /// <param name="tam">Tamaño del atributo que ocupara en memoria</param>
        public Atributo(string Nombre, char TDato, int TLlave, int tam)
        {
            NombreAtributo = Nombre;
            TipoDato = TDato;
            TipoLlave = TLlave;
            NombreFK = "";
            Tam = tam;
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="Nombre">Nombre del atributo</param>
        /// <param name="TDato">Tipo de datos (entero, flotante, cadena)</param>
        /// <param name="TLlave">Tipo de llave PK, FK o ninguna</param>
        /// <param name="FK">Nombre de la tabla a la que hace referencia</param>
        /// <param name="tam">Tamaño del atributo que ocupara en memoria</param>
        public Atributo(string Nombre, char TDato, int TLlave, string FK, int tam)
        {
            NombreAtributo = Nombre;
            TipoDato = TDato;
            TipoLlave = TLlave;
            NombreFK = FK;
            Tam = tam;
        }
        public Atributo()
        {

        }
        
        /// <summary>
        /// Funcion que regresa y cambia el nombre del atributo.
        /// 
        /// </summary>
        public string _NombreAtributo { get { return NombreAtributo; } set { NombreAtributo = value; } }
        /// <summary>
        /// Funcion que regresa y cambia el tipo del atributo.
        /// </summary>
        public char _TipoDato { get { return TipoDato; } set { TipoDato = value; } }
        /// <summary>
        /// Funcion que regresa y cambia el tipo de llave del atributo.
        /// </summary>
        public int _TipoLLave { get { return TipoLlave; } set { TipoLlave = value; } }
        /// <summary>
        /// Funcion que regresa y cambia el tamaño del atributo.
        /// </summary>
        public int _Tam { get { return Tam; } set { Tam = value; } }
        /// <summary>
        /// /Funcion que regresa y cambia el nombre de la tabla con la cual se esta relacionada.
        /// </summary>
        public string _NombreFK { get { return NombreFK; } set { NombreFK = value; } }
    }
}
