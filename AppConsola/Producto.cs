using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacionApp
{
    public class Producto
    {
        private int codigo;
        private string nombre;
        private string descripcion;
        private double precio;
        private int stock;

        public Producto(int codigo, string nombre, double precio, int stock)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.precio = precio;
            this.stock = stock;
        }
        public int getCodigo()
        {
            return codigo;
        }
        public string getNombre()
        {
            return nombre;
        }
        public double getPrecio()
        {
            return precio;
        }
        public int getStock()
        {
            return stock;
        }
        public void reducirStock(int cantidad)
        {
            stock -= cantidad;
        }
        public void aumentarStock(int cantidad)
        {
            stock += cantidad;
        }
        public string getDescripcion()
        {
            return descripcion;
        }
        public Producto(string descripcion)
        {
            this.descripcion = descripcion;
        }
    }
}