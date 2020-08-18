﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasesDatos
{
    public class BaseDatos
    {
        private string NombreBD;
        private List<Tabla> tablas;

        public BaseDatos(string Nombre) {
            NombreBD = Nombre;
            tablas = new List<Tabla>();
        }

        public List<Tabla> Tablas { get { return tablas; } set{tablas=value; }}
        public string _NombreBD { get { return NombreBD; } set { NombreBD = value; } }



    }
}
