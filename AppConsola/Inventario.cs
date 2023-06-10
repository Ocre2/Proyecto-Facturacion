using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacionApp
{
    public class Inventario
    {
        private List<Producto> productos;

        public Inventario()
        {
            productos = new List<Producto>();
        }
        public void agregarProducto(Producto producto)
        {
            productos.Add(producto);
        }
        public void eliminarProducto(Producto producto)
        {
            productos.Remove(producto);
        }
        public Producto buscarProducto(int codigo)
        {
            return productos.Find(producto => producto.getCodigo() == codigo);
        }
        public List<Producto> listarProducto()
        {
            return productos;
        }
    }
}