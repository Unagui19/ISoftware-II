// TiendaTests.cs

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TP1_IS;

namespace Test
{
    [TestFixture]
    public class TiendaTests
    {
        [Test]
        public void buscarProductoPorNombre_meTieneDevolverProductoDelNombreSolicitado()
        {
            // Arrange
            List<Producto> productos = new List<Producto>();
          
            productos.Add(new Producto("Teclado", 50000, "Electronica"));
            productos.Add(new Producto("Laptop", 1100000, "Electrónica"));
            productos.Add(new Producto("Silla gamer", 450000, "Mobiliario"));
            var tienda = new Tienda(productos);

            Producto productoEsperado = productos[1];  

            // Act            
            var productoActual = tienda.BuscarProducto("Laptop");

            // Assert
            Assert.IsInstanceOf(typeof(Producto),productoActual);
            Assert.AreEqual(productoEsperado,productoActual);
        }

        [Test]
        public void eliminarProducto_meTieneDevolverTrue()
        {
            // Arrange
            List<Producto> productos = new List<Producto>();

            productos.Add(new Producto("Teclado", 50000, "Electronica"));
            productos.Add(new Producto("Laptop", 1100000, "Electrónica"));
            productos.Add(new Producto("Silla gamer", 450000, "Mobiliario"));
            var tienda = new Tienda(productos);
            bool esperado = true; 

            // Act            
            var actual = tienda.EliminarProducto("Laptop");

            // Assert
            Assert.AreEqual(actual, esperado);

        }

        [Test]
        public void agregarProducto_verificoContandolistaYbuscandolo()
        {
            // Arrange
            List<Producto> productos = new List<Producto>();

            productos.Add(new Producto("Teclado", 50000, "Electronica"));
            productos.Add(new Producto("Laptop", 1100000, "Electrónica"));
            productos.Add(new Producto("Silla gamer", 450000, "Mobiliario"));
            var tienda = new Tienda(productos);
            int cantidadEsperada = 4;
            Producto nuevoProducto = new Producto("Mesa", 78000, "Mobiliario");
            tienda.AgregarProducto(nuevoProducto);

            // Act            
            int cantidadActual = tienda.cantidadProductos();

            // Assert
            Assert.AreEqual(cantidadActual, cantidadEsperada);

        }

        [Test]
        public void BuscarProducto_NoExisteProducto_DeberiaLanzarArgumentException()
        {
            // arrange 
            List<Producto> productos = new List<Producto>();

            productos.Add(new Producto("Teclado", 50000, "Electronica"));
            productos.Add(new Producto("Laptop", 1100000, "Electrónica"));
            productos.Add(new Producto("Silla gamer", 450000, "Mobiliario"));
            var tienda = new Tienda(productos);

            // Act
            try
            {

                tienda.BuscarProducto("productoInexistente");
                Assert.Fail("Se esperaba una excepción ArgumentException, pero no se lanzó ninguna.");
            }
            catch (ArgumentException ex)
            {
                // Assert
                Assert.AreEqual(ex.Message,"No existe el producto");
            }
        }

        [Test]
        public void EliminarProducto_NoExisteProducto_DeberiaLanzarArgumentException()
        {
            // arrange 
            List<Producto> productos = new List<Producto>();

            productos.Add(new Producto("Teclado", 50000, "Electronica"));
            productos.Add(new Producto("Laptop", 1100000, "Electrónica"));
            productos.Add(new Producto("Silla gamer", 450000, "Mobiliario"));
            var tienda = new Tienda(productos);

            // Act
            try
            {

                tienda.EliminarProducto("productoInexistente");
                Assert.Fail("Se esperaba una excepción ArgumentException, pero no se lanzó ninguna.");
            }
            catch (ArgumentException ex)
            {
                // Assert
                Assert.AreEqual(ex.Message, "No existe el producto");
            }
        }


        [Test]
        public void ActualizarPrecio_precioEsNegativo_DeberiaLanzarArgumentException()
        {
            // arrange 

            Producto nuevoProducto = new Producto("Mesa", 78000, "Mobiliario");

            // Act
            try
            {

                nuevoProducto.ActualizarPrecio(-1);
                Assert.Fail("Se esperaba una excepción ArgumentException, pero no se lanzó ninguna.");
            }
            catch (ArgumentException ex)
            {
                // Assert
                Assert.AreEqual(ex.Message, "El precio no puede ser negativo.");
            }
        }

    }
}
