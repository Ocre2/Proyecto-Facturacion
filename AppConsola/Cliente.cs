using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacionApp
{
    public class Cliente
    {
        private int idCliente;
        private string nombre;
        private string direccion;
        private double saldoDeuda;

        public Cliente(int idCliente, string nombre, string direccion)
        {
            this.idCliente = idCliente;
            this.nombre = nombre;
            this.direccion = direccion;
            saldoDeuda = 0;
        }
        public int getIdCliente()
        {
            return idCliente;
        }
        public string getNombre()
        {
            return nombre;
        }
        public string getDireccion()
        {
            return direccion;
        }
        public double getSaldoDeuda()
        {
            return saldoDeuda;
        }
        public void agregarDeuda(double monto)
        {
            saldoDeuda += monto;
        }
        public void abonarDeuda(double monto)
        {
            saldoDeuda -= monto;
        }
        public double obtenerSaldoActualizado()
        {
            double saldoActualizado = saldoDeuda;

            return saldoActualizado;
        }
    }
}