using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacionApp
{
    public class Fecha
    {
        private int dia;
        private int mes;
        private int anio;

        public Fecha()
        {
            dia = DateTime.Now.Day;
            mes = DateTime.Now.Month;
            anio = DateTime.Now.Year;
        }

        public int getDia()
        {
            return dia;
        }
        public int getMes()
        {
            return mes;
        }
        public int getAnio()
        {
            return anio;
        }
        public string getFecha()
        {
            return $"{dia}/{mes}/{anio}";
        }
    }
}