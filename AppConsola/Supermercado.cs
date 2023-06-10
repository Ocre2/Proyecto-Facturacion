using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacionApp
{
    public class Supermercado
    {
        private List<Sucursal> sucursales;
        private List<Proveedor> proveedores;
        private List<Empleado> empleados;
        private Inventario inventario;
        private List<Venta> ventas;

        public Supermercado()
        {
            sucursales = new List<Sucursal>();
            proveedores = new List<Proveedor>();
            empleados = new List<Empleado>();
            inventario = new Inventario();
        }
        public void agregarSucursal(Sucursal sucursal)
        {
            sucursales.Add(sucursal);
        }
        public void eliminarSucursal(Sucursal sucursal)
        {
            sucursales.Remove(sucursal);
        }

        public void agregarProveedor(Proveedor proveedor)
        {
            proveedores.Add(proveedor);
        }
        public void eliminarProveedor(Proveedor proveedor)
        {
            proveedores.Remove(proveedor);
        }

        public void agregarEmpleado(Empleado empleado)
        {
            empleados.Add(empleado);
        }
        public void eliminarEmpleado(Empleado empleado)
        {
            empleados.Remove(empleado);
        }

        public double obtenerVentasTotales()
        {
            double totalVentas = 0;

            foreach (Sucursal sucursal in sucursales)
            {
                totalVentas += sucursal.obtenerVentasTotales();
            }
            return totalVentas;
        }

        public List<Producto> obtenerProductosAgotados()
        {
            List<Producto> productosAgotados = new List<Producto>();

            foreach (Sucursal sucursal in sucursales)
            {
                List<Producto> productos = sucursal.obtenerProductosAgotados();
                productosAgotados.AddRange(productos);
            }
            return productosAgotados;
        }

        public void generarInformeVentas()
        {
            Console.WriteLine("Generando informe de ventas del supermercado...");
            List<Sucursal> sucursales = obtenerSucursales();

            double totalVentas = 0;
            int totalFacturas = 0;

            foreach (Sucursal sucursal in sucursales)
            {
                List<Factura> ventas = sucursal.obtenerVentas(fechaInicio, fechaFin);

                foreach (Factura venta in ventas)
                {
                    double totalVenta = venta.calcularTotal();

                    totalVentas += totalVenta;

                    totalFacturas++;
                }
            }
            Console.WriteLine($"Total de ventas del supermercado: ${totalVentas}");
            Console.WriteLine($"Numero de facturas: {totalFacturas}");
        }
        public void generarInformeInventario()
        {
            Console.WriteLine("generando informe de inventario del supermercado...");

            List<Sucursal> sucursales = obtenerSucursales();

            List<Producto> productosAgotados = new List<Producto>();


            foreach (Sucursal sucursal in sucursales)
            {
                List<Producto> agotados = sucursal.obtenerProductosAgotados();
                productosAgotados.AddRange(agotados);
            }

            Console.WriteLine("Productos agotados del supermercado: ");
            foreach (Producto producto in productosAgotados)
            {
                Console.WriteLine(producto.getDescripcion());
            }

        }

        public void generarInformeProveedores()
        {
            Console.WriteLine("Generando informe de proveedores del supermercado...");

            List<Proveedor> proveedores = obtenerProveedores();

            foreach (Proveedor proveedor in proveedores)
            {
                Console.WriteLine($"Proveedor {proveedor.getNombre()}");
                Console.WriteLine($"Direccion {proveedor.getDireccion()}");
                Console.WriteLine("Productos: ");

                List<Producto> productos = proveedor.listarProductos();
                foreach (Producto producto in productos)
                {
                    Console.WriteLine($"- {producto.getDescripcion()}");
                }
                Console.WriteLine("-----------------------------------");
            }
        }
        public void generarInformeEmpleados()
        {
            Console.WriteLine("Generando informacion de empleados del supermercado...");

            List<Empleado> empleados = obtenerEmpleados();

            foreach (Empleado empleado in empleados)
            {
                Console.WriteLine($"Empleado: {empleado.getNombre()}");
                Console.WriteLine($"ID: {empleado.getIdEmpleado()}");
                Console.WriteLine($"Sucursal: {empleado.getSucursal().getNumeroSucursal()}");
                Console.WriteLine("--------------------------------------------------------");
            }
        }
        public List<Sucursal> obtenerSucursales()
        {
            return sucursales;
        }
        public List<Empleado> obtenerEmpleados()
        {
            return empleados;
        }
        public List<Venta> obtenerVentasEnRangoDeFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Venta> ventasEnRangio = new List<Venta>();

            foreach (Venta venta in ventas)
            {
                if (venta.Fecha >= fechaInicio && venta.Fecha <= fechaFin)
                {
                    ventasEnRangio.Add(venta);
                }
            }
            return ventasEnRangio;
        }
    }
}