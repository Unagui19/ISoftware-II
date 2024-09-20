using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_IS
{
    public class TiendaMocks
    {
        private List<IProducto> inventario;

        public TiendaMocks()
        {
            inventario = new List<IProducto>();
        }

        public TiendaMocks(List<IProducto> inventario)
        {
            this.inventario = inventario;
        }


        public void AgregarProducto(IProducto producto)
        {
            inventario.Add(producto);
        }

        public int cantidadProductos()
        {
            return inventario.Count;
        }

        public IProducto BuscarProducto(string nombre)
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
