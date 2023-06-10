using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacionApp
{
    public class Factura
    {
        private int numeroFactura;
        private Fecha fecha;
        private Cliente cliente;
        private List<ItemFactura> items;
        private Cajero cajero;

        public Factura(Cliente cliente, Cajero cajero)
        {
            this.cliente = cliente;
            this.cajero = cajero;
            items = new List<ItemFactura>();
            fecha = new Fecha();
            pagada = false;
        }
        public void agregarItem(ItemFactura item)
        {
            items.Add(item);
        }
        public void eliminarItem(ItemFactura item)
        {
            items.Remove(item);
        }
        public void eliminarItem(int indice)
        {
            items.RemoveAt(indice);
        }
        public double calcularSubtotal()
        {
            double subtotal = 0;

            foreach (ItemFactura item in items)
            {
                subtotal += item.calcularSubtotal();
            }
            return subtotal;
        }

        public double calcularImpuestos()
        {
            double impuestos = calcularSubtotal() * 0.19;
            return impuestos;
        }
        public double calcularTotal()
        {
            double subtotal = calcularSubtotal();
            double impuestos = calcularImpuestos();
            double total = subtotal + impuestos;
            return total;
        }
        public void imprimirFactura()
        {
            Console.WriteLine("Imprimiendo factura...");

            Console.WriteLine($"Numero de factura: {numeroFactura}");
            Console.WriteLine($"Fecha: {fecha.getFecha()}");
            Console.WriteLine($"Cliente: {cliente.getNombre()}");
            Console.WriteLine("Items: ");

            foreach (ItemFactura item in items)
            {
                Console.WriteLine($"Producto: {item.getProducto().getDescripcion()}");
                Console.WriteLine($"Cantidad: {item.getCantidad()}");
                Console.WriteLine($"Precio unitario: {item.getPrecioUnitario()}");
                Console.WriteLine($"Subtotal: {item.calcularSubtotal()}");
                Console.WriteLine("--------------------------------------");
            }
            Console.WriteLine($"Subtotal: {calcularSubtotal()}");
            Console.WriteLine($"Impuestos: {calcularImpuestos()}");
            Console.WriteLine($"Total: {calcularTotal()}");
        }
        public void generarInforme()
        {
            Console.WriteLine($"Generando informe de la factura...");

            Console.WriteLine($"Numero de facturas: {numeroFactura}");
            Console.WriteLine($"Fecha: {fecha.getFecha()}");
            Console.WriteLine($"Cliente: {cliente.getNombre()}");
            Console.WriteLine($"Items: ");

            foreach (ItemFactura item in items)
            {
                Console.WriteLine($"Producto: {item.getProducto().getDescripcion()}");
                Console.WriteLine($"Cantidad: {item.getCantidad()}");
                Console.WriteLine($"Precio unitario: {item.getPrecioUnitario()}");
                Console.WriteLine($"Subtotal: {item.calcularSubtotal()}");
                Console.WriteLine("------------------------------------------------");
            }
            Console.WriteLine($"Subtotal: {calcularSubtotal()}");
            Console.WriteLine($"Impuestos: {calcularImpuestos()}");
            Console.WriteLine($"Total: {calcularTotal()}");
        }
        public int getNumeroFactura()
        {
            return numeroFactura;
        }
        public Fecha getFecha()
        {
            return fecha;
        }
    }
}