using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TP1_IS;
using Moq;

namespace Test
{
    [TestFixture]
    public class Tienda_Test_Mocks
    {
        [Test]
        public void AplicarDescuento_ProductoExistente_ActualizaPrecio()
        {
            // Arrange
            var mockProducto = new Mock<IProducto>();
            mockProducto.Setup(p => p.Nombre).Returns("Laptop");
            mockProducto.Setup(p => p.Precio).Returns(1000m);

            var productos = new List<IProducto> { mockProducto.Object };
            var tienda = new TiendaMocks(productos);

            // Act
            tienda.AplicarDescuento("Laptop", 10); // 10% Des

            // Assert
            mockProducto.Verify(p => p.ActualizarPrecio(900m), Times.Once); // nuevo precio 900
        }

        /*------------- opcionales ----------------*/

        [Test]
        public void AgregarProducto_ProductoValido_DeberiaAgregarAlInventario()
        {
            // Arrange
            var mockProducto = new Mock<IProducto>();
            mockProducto.Setup(p => p.Nombre).Returns("Teclado");
            mockProducto.Setup(p => p.Precio).Returns(50000m);
            mockProducto.Setup(p => p.Categoria).Returns("Electronica");

            var productos = new List<IProducto>();
            var tienda = new TiendaMocks(productos);

            // Act
            tienda.AgregarProducto(mockProducto.Object);

            // Assert
            Assert.That(tienda.cantidadProductos(), Is.EqualTo(1)); // inventario 1
            Assert.That(productos.Contains(mockProducto.Object)); // producto en la lista
        }

        [Test]
        public void BuscarProducto_ProductoExistente_DeberiaDevolverProducto()
        {
            // Arrange
            var mockProducto = new Mock<IProducto>();
            mockProducto.Setup(p => p.Nombre).Returns("Laptop");
            mockProducto.Setup(p => p.Precio).Returns(1000m);
            mockProducto.Setup(p => p.Categoria).Returns("Electrónica");

            var productos = new List<IProducto> { mockProducto.Object };
            var tienda = new TiendaMocks(productos);

            // Act
            var productoEncontrado = tienda.BuscarProducto("Laptop");

            // Assert
            Assert.IsNotNull(productoEncontrado); // El producto encontrado no debe ser nulo
            Assert.AreEqual(mockProducto.Object, productoEncontrado); // Debe devolver el producto correcto
        }

        [Test]
        public void EliminarProducto_ProductoExistente_DeberiaEliminarProducto()
        {
            // Arrange
            var mockProducto = new Mock<IProducto>();
            mockProducto.Setup(p => p.Nombre).Returns("Teclado");
            mockProducto.Setup(p => p.Precio).Returns(50000m);
            mockProducto.Setup(p => p.Categoria).Returns("Electronica");

            var productos = new List<IProducto> { mockProducto.Object };
            var tienda = new TiendaMocks(productos);

            // Act
            var resultado = tienda.EliminarProducto("Teclado");

            // Assert
            Assert.IsTrue(resultado); // Debe devolver true indicando que se eliminó
            Assert.AreEqual(0, tienda.cantidadProductos()); // El inventario debe estar vacío
        }


    }
}
