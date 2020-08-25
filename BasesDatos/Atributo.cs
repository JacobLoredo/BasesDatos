namespace BasesDatos
{
    public class Atributo
    {
        private string NombreAtributo;
        private char TipoDato;
        private int TipoLlave;

        public Atributo(string Nombre, char TDato, int TLlave)
        {
            NombreAtributo = Nombre;
            TipoDato = TDato;
            TipoLlave = TLlave;
        }
        public Atributo()
        {

        }
        public string _NombreAtributo { get { return NombreAtributo; } set { NombreAtributo = value; } }
        public char _TipoDato { get { return TipoDato; } set { TipoDato = value; } }
        public int _TipoLLave { get { return TipoLlave; } set { TipoLlave = value; } }
    }
}
