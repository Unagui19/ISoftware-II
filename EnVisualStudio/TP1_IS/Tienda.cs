using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_IS
{
    using System;
    using System.Collections.Generic;

    public class Tienda
    {
        private List<Producto> inventario;

        public Tienda()
        {
            inventario = new List<Producto>();
        }

        public Tienda(List<Producto> inventario)
        {
            this.inventario = inventario;
        }



        public void AgregarProducto(Producto producto)
        {
            inventario.Add(producto);
        }

        public int cantidadProductos()
        {
            return inventario.Count;
        }

        public Producto BuscarProducto(string nombre)
        {

            foreach (var producto in inventario)
            {
                if (producto.Nombre == nombre)
                {
                    return producto;
                }
            }

            throw new ArgumentException("No existe el producto");

        }

        public bool EliminarProducto(string nombre)
        {
            var producto = BuscarProducto(nombre);
            if (producto != null)
            {
                inventario.Remove(producto);
                return true;
            }

            throw new ArgumentException("No existe el producto");

        }

        public void AplicarDescuento(string nombreProducto, decimal porcentaje)
        {
            var producto = BuscarProducto(nombreProducto);
            if (producto != null)
            {
                var nuevoPrecio = producto.Precio - (producto.Precio * porcentaje / 100);
                producto.ActualizarPrecio(nuevoPrecio);
            }
        }


    }

}
