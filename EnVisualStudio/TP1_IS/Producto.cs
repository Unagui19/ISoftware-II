using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_IS
{
    public class Producto : IProducto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }

        private readonly IProducto _producto;

        public Producto(IProducto producto)
        {
            _producto = producto;
        }



        public Producto(string nombre, decimal precio, string categoria)
        {
            Nombre = nombre;
            Precio = precio;
            Categoria = categoria;
        }

        public void ActualizarPrecio(decimal nuevoPrecio)
        {
            if (nuevoPrecio < 0)
            {
                throw new ArgumentException("El precio no puede ser negativo.");
            }

            Precio = nuevoPrecio;
        }
    }

}
