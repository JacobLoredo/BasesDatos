using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasesDatos.Modulo_SQL
{
    class Select : Gramatica
    {
        public string resultado;
        private BaseDatos BD;
        public Select(BaseDatos bd)
        {
            resultado = "";
            this.BD = bd;
        }
        public string ejecuta_select_all()
        {
            
            foreach (Tabla t in BD.Tablas)
            {
                if(t._NombreTabla.Replace(" ", "") == tablaA)
                {
                    resultado = tablaA + "\r\n";
                    foreach(Atributo a in t._Atributos)
                    {
                        resultado += a._NombreAtributo + "\t";
                    }
                    resultado += "\r\n";
                    foreach (string s in t._datos)
                        resultado += s + "\r\n";
                }
            }
            return resultado;
        }
    }
}
