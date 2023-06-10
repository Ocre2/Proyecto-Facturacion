using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacionApp
{
    public class Cajero
    {
        private int idCajero;
        private string nombre;
        private Sucursal sucursal;
        private List<Factura> facturas;

        public Cajero(int idCajero, string nombre, Sucursal sucursal)
        {
            this.idCajero = idCajero;
            this.nombre = nombre;
            this.sucursal = sucursal;
            facturas = new List<Factura>();
        }
        public Factura crearFactura(Cliente cliente)
        {
            Factura factura = new Factura(cliente, this);
            facturas.Add(factura);
            return factura;
        }
        public void agregarProducto(Factura factura, Producto producto, int cantidad)
        {
            factura.agregarItem(new ItemFactura(producto, cantidad, producto.getPrecio()));
        }
        public void anularFactura(Factura factura)
        {
            facturas.Remove(factura);
        }
        public List<Factura> consultarVentas(Fecha fechaInicio, Fecha fechaFin)
        {
            List<Factura> ventasPeriodo = new List<Factura>();

            foreach (Factura factura in facturas)
            {
                if (factura.Fecha >= fechaInicio && factura.Fecha <= fechaFin)
                {
                    ventasPeriodo.Add(factura);
                }
            }
            return ventasPeriodo;
        }
        public void generarInformeVentas()
        {
            Console.WriteLine("Generando informe de ventas del cajero...");

            foreach (Factura factura in facturas)
            {
                Console.WriteLine($"Numero de facturas: {factura.getNumeroFactura()}");
                Console.WriteLine($"Fecha: {factura.getFecha().getFecha()}");
                Console.WriteLine($"Cliente: {factura.getCliente().getNombre()}");
                Console.WriteLine("----------------------------------------------");
            }
        }
        public void generarInformeFacturas()
        {
            Console.WriteLine("Generando informe de facturas del cajero...");

            foreach (Factura factura in facturas)
            {
                Console.WriteLine($"Numero de facturas: {factura.getNumeroFactura()}");
                Console.WriteLine($"Fecha: {factura.getFecha().getFecha()}");
                Console.WriteLine($"Cliente: {factura.getCliente().getNombre()}");
                Console.WriteLine("----------------------------------------------");
            }
        }
        public double obtenerVentasTotales()
        {
            double totalVentas = 0;

            foreach (Factura factura in facturas)
            {
                totalVentas += factura.calcularTotal();
            }
            return totalVentas;
        }
        public List<Factura> obtenerFacturasPendientes()
        {
            List<Factura> facturasPendientes = new List<Factura>();

            foreach (Factura factura in facturas)
            {
                if (!factura.Pagada)
                {
                    facturasPendientes.Add(factura);
                }
            }
            return facturasPendientes;
        }
    }
}