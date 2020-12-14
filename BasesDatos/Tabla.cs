﻿using System.Collections.Generic;

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

        /// <param name="nombre">Nombre de la tabla a crear.</param>
        public Tabla(string nombre)
        {
            NombreTabla = nombre;
            atributos = new List<Atributo>();
            datos = new List<string>();
        }
        public Tabla()
        {

            atributos = new List<Atributo>();
            datos = new List<string>();
        }

        public string[] lista_nombre_atributos()
        {
            string[] nombres_atributos = new string[atributos.Count];

            for (int i = 0; i < nombres_atributos.Length; i++)
                nombres_atributos[i] = atributos[i]._NombreAtributo;

            return nombres_atributos;
        }

        /// <value> Gets and set la lista de atributos de la tabla .</value>
        public List<Atributo> _Atributos { get { return atributos; } set { atributos = value; } }
        /// <value>Gets and set el nombre de la tabla</value>
        public string _NombreTabla { get { return NombreTabla; } set { NombreTabla = value; } }
        public List<string> _datos { get { return datos; } set { datos = value; } }
    }
}
