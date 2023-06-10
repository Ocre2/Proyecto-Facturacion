using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacionApp
{
    public class Sucursal
    {
        private int numeroSucursal;
        private string direccion;
        private List<Cajero> cajeros;
        private Inventario inventario;
        private List<Factura> ventas;
        private List<Empleado> empleados;

        public Sucursal(int numeroSucursal, string direccion)
        {
            this.numeroSucursal = numeroSucursal;
            this.direccion = direccion;
            cajeros = new List<Cajero>();
            inventario = new Inventario();
            ventas = new List<Factura>();
            empleados = new List<Empleado>();
        }

        public void agregarCajero(Cajero cajero)
        {
            cajeros.Add(cajero);
        }
        public void eliminarCajero(Cajero cajero)
        {
            cajeros.Remove(cajero);
        }
        public Cajero buscarCajero(int idCajero)
        {
            return cajeros.Find(cajero => cajero.IdCajero == idCajero);
        }
        public Producto buscarProducto(int codigo)
        {
            return inventario.BuscarProducto(codigo);
        }
        public void realizarVenta(Factura factura)
        {
            ventas.Add(factura);
        }
        public List<Factura> obtenerVentas(Fecha fechaInicio, Fecha fechaFin)
        {
            List<Factura> ventasPeriodo = new List<Factura>();

            foreach (Factura factura in ventas)
            {
                if (factura.Fecha >= fechaInicio && factura.Fecha <= fechaFin)
                {
                    ventasPeriodo.Add(factura);
                }
            }
            return ventasPeriodo;
        }
        public void generarInformeInventario()
        {
            Console.WriteLine("Generando informe de inventario de la sucursal...");

            List<Producto> productos = inventario.listarProductos();

            foreach (Producto producto in productos)
            {
                Console.WriteLine($"Producto: {producto.getDescripcion()}");
                Console.WriteLine($"Codigo: {producto.getCodigo()}");
                Console.WriteLine($"Precio: {producto.getPrecio()}");
                Console.WriteLine($"Stock: {producto.getStock()}");
                Console.WriteLine("----------------------------------");
            }

        }
        public void generarInformeCajeros()
        {
            Console.WriteLine("Generando informe de cajeros de la sucursal...");
            foreach (Cajero cajero in cajeros)
            {
                Console.WriteLine($"ID del cajero: {cajero.getIdCajero()}");
                Console.WriteLine($"Nombre: {cajero.getNombre()}");
                Console.WriteLine("-------------------------------------");
            }
        }
        public void generarInformeVentas()
        {
            Console.WriteLine("Generando informe de ventas de la sucursal...");

            foreach (Factura factura in ventas)
            {
                Console.WriteLine($"Numero de Facturas: {factura.getNumeroFactura()}");
                Console.WriteLine($"Fecha: {factura.getFecha().getFecha()}");
                Console.WriteLine($"Cliente: {factura.getCliente().getNombre()}");
                Console.WriteLine("--------------------------------------------------");
            }
        }
        public int getNumeroSucursal()
        {
            return numeroSucursal;
        }

        public List<Producto> obtenerProductosAgotados()
        {
            List<Producto> productosAgotados = new List<Producto>();

            foreach (Producto producto in inventario.listarProductos())
            {
                if (producto.getStock() == 0)
                {
                    productosAgotados.Add(producto);
                }
            }
            return productosAgotados;
        }
    }
}