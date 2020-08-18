using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasesDatos
{
    public class Tabla
    {
        private string NombreTabla;
        private List<Atributo> atributos;

        public Tabla(string nombre) {
            NombreTabla = nombre;
            atributos = new List<Atributo>();
        }


        public List<Atributo> _Atributos { get { return atributos; } set { atributos = value; } }
        public string _NombreTabla { get { return NombreTabla; } set { NombreTabla = value; } }
    }
}
