using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TP1_IS;
using Microsoft.VisualBasic;

namespace Test
{

    [TestFixture] //
    public class Tienda_Test_Integracion_Real
    {
        private IProducto? _productoLaptop; 
        private IProducto? _productoTeclado; 
        private List<IProducto>? _productos;
        private TiendaMocks? _tienda;

        [SetUp]
        public void SetUp(){
            //inicializo dos productos
            _productoLaptop = new Producto("Laptop", 1000m, "Electrónica");
            _productoTeclado = new Producto("Teclado", 5000m, "Electrónica");

            //
            _productos = new List<IProducto>(){ _productoLaptop, _productoTeclado };
            _tienda = new TiendaMocks(_productos);

        }
        [TearDown] //Para limpiar los datos despues de cada prueba
        public void TearDown(){
            _productoLaptop=null;
            _productoTeclado=null;
            _productos=null;
            _tienda=null;
        }


        // Prueba de integración que verifica el flujo completo de agregar, modificar y calcular el total del carrito.
        [Test]
        public void PruebaDeIntegracion_FlujoCompleto()
        {
            // 1. Verificar que la tienda tiene 2 productos al inicio.
            Assert.That(_tienda.cantidadProductos(), Is.EqualTo(2));
            
            // 2. Aplicar descuento a un producto y verificar que el precio se actualiza.
            _tienda.AplicarDescuento("Laptop", 10); // 10% descuento
            Assert.That(_productoLaptop.Precio, Is.EqualTo(900m)); // El precio debería ser 900 después del descuento.

            // 3. Agregar un nuevo producto a la tienda.
            var mouse = new Producto("Mouse", 200m, "Electrónica");
            _tienda.AgregarProducto(mouse);
            Assert.That(_tienda.cantidadProductos(), Is.EqualTo(3)); // La tienda ahora debería tener 3 productos.
            
            // 4. Buscar un producto en la tienda.
            var productoEncontrado = _tienda.BuscarProducto("Mouse");
            Assert.IsNotNull(productoEncontrado); // Debería encontrar el nuevo producto agregado.
            Assert.That(productoEncontrado.Precio, Is.EqualTo(200m)); // Verificar el precio del producto encontrado.

            // 5. Eliminar un producto de la tienda.
            var resultadoEliminar = _tienda.EliminarProducto("Teclado");
            Assert.IsTrue(resultadoEliminar); // Verificar que el producto fue eliminado correctamente.
            Assert.That(_tienda.cantidadProductos(), Is.EqualTo(2)); // Ahora debería haber 2 productos en la tienda.

            // 6. Calcular el total del carrito (Laptop + Mouse).
            decimal totalCarrito = _tienda.CalcularTotalCarrito();
            Assert.That(totalCarrito, Is.EqualTo(1100m)); // Laptop (900) + Mouse (200) = 1100
        }
    }
}


