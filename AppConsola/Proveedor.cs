using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacionApp
{
    public class Proveedor
    {
        private int idProveedor;
        private string nombre;
        private string direccion;
        private List<Producto> productos;

        public Proveedor(int idProveedor, string nombre, string direccion, List<Producto> productos)
        {
            this.idProveedor = idProveedor;
            this.nombre = nombre;
            this.direccion = direccion;
            this.productos = productos;
        }

        public int getIdProveedor()
        {
            return idProveedor;
        }
        public string getNombre()
        {
            return nombre;
        }
        public string getDireccion()
        {
            return direccion;
        }
        public void generarInforme()
        {
            Console.WriteLine("Generando informe del proveedor...");

            Console.WriteLine($"ID del proveedor {idProveedor}");
            Console.WriteLine($"Nombre: {nombre}");
            Console.WriteLine($"Direccion: {direccion}");
            Console.WriteLine("Productos Suministrados");

            foreach (Producto producto in productos)
            {
                Console.WriteLine($"Codigo: {producto.getCodigo()}");
                Console.WriteLine($"Descripcion: {producto.getDescripcion()}");
                Console.WriteLine($"Precio: {producto.getPrecio()}");
                Console.WriteLine("------------------------------------------");
            }

        }
    }
}