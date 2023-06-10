using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacionApp
{
    public class ItemFactura
    {
        private Producto producto;
        private int cantidad;
        private double precioUnitario;

        public ItemFactura(Producto producto, int cantidad, double precioUnitario)
        {
            this.producto = producto;
            this.cantidad = cantidad;
            this.precioUnitario = precioUnitario;
        }
        public double calcularSubtotal()
        {
            return cantidad * precioUnitario;
        }
        public Producto getProducto()
        {
            return producto;
        }
        public int getCantidad()
        {
            return cantidad;
        }
        public double getPrecioUnitario()
        {
            return precioUnitario;
        }

    }
}