using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacionApp
{
    public class Empleado
    {
        private int idEmpleado;
        private string nombre;
        private Sucursal sucursal;

        public Empleado(int idEmpleado, string nombre, Sucursal sucursal)
        {
            this.idEmpleado = idEmpleado;
            this.nombre = nombre;
            this.sucursal = sucursal;
        }
        public int getIdEmpleado()
        {
            return idEmpleado;
        }
        public string getNombre()
        {
            return nombre;
        }
        public Sucursal getSucursal()
        {
            return sucursal;
        }
        public void generarInforme()
        {
            Console.WriteLine("Generando informe del empleado...");

            Console.WriteLine($"ID Empleado: {idEmpleado}");
            Console.WriteLine($"Nombre: {nombre}");
            Console.WriteLine($"Sucursal: {sucursal.getNumeroSucursal()}");
            Console.WriteLine("-----------------------------------------------");

        }
    }
}