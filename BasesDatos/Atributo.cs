namespace BasesDatos
{
    public class Atributo
    {
        private string NombreAtributo;
        private char TipoDato;
        private int TipoLlave;
        private string NombreFK;
        private int Tam;

        public Atributo(string Nombre, char TDato, int TLlave,int tam)
        {
            NombreAtributo = Nombre;
            TipoDato = TDato;
            TipoLlave = TLlave;
            NombreFK = "";
            Tam = tam;
        }
        public Atributo(string Nombre, char TDato, int TLlave,string FK,int tam)
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
        public string _NombreAtributo { get { return NombreAtributo; } set { NombreAtributo = value; } }
        public char _TipoDato { get { return TipoDato; } set { TipoDato = value; } }
        public int _TipoLLave { get { return TipoLlave; } set { TipoLlave = value; } }
        public int _Tam { get { return Tam; } set { Tam = value; } }
        public string _NombreFK { get { return NombreFK; } set { NombreFK = value; } }

    }
}
