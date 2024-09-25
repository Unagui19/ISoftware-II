using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TP1_IS;
using Moq;
using Microsoft.VisualBasic;

namespace Test
{

    [TestFixture] //
    public class Tienda_Test_Integracion
    {
        private Mock<IProducto> _mockProductoLaptop; 
        private Mock<IProducto> _mockProductoTeclado; 
        private List<IProducto> _productos;
        private TiendaMocks _tienda;

        [SetUp]
        public void SetUp(){
            //inicializo dos productos
            _mockProductoLaptop = new Mock<IProducto>();
            _mockProductoLaptop.Setup(p => p.Nombre).Returns("Laptop");
            _mockProductoLaptop.Setup(p => p.Precio).Returns(1000m);
            _mockProductoLaptop.Setup(p => p.Categoria).Returns("Electrónica");

            _mockProductoTeclado = new Mock<IProducto>();
            _mockProductoTeclado.Setup(p => p.Nombre).Returns("Teclado");
            _mockProductoTeclado.Setup(p => p.Precio).Returns(50000m);
            _mockProductoTeclado.Setup(p => p.Categoria).Returns("Electrónica");

            //
            _productos = new List<IProducto>(){};
            _tienda = new TiendaMocks(_productos);

        }
        // [TearDown] //Para limpiar los datos despues de cada prueba
        // public void TearDown(){
        //     _mockProductoLaptop=null;
        //     _mockProductoTeclado=null;
        //     _productos=null;
        //     _tienda=null;
        // }


        [Test]
        public void AplicarDescuento_ProductoExistente_ActualizaPrecio()
        {
            // _mockProducto.Setup(p => p.Nombre).Returns("Laptop");
            // _mockProducto.Setup(p => p.Precio).Returns(1000m);

            _productos.Add(_mockProductoLaptop.Object); // Inicialización de la lista con el producto mockeado
            // Act
            _tienda.AplicarDescuento("Laptop", 10); // 10% Des

            // Assert
            _mockProductoLaptop.Verify(p => p.ActualizarPrecio(900m), Times.Once); // nuevo precio 900
        }

        /*------------- opcionales ----------------*/

        [Test]
        public void AgregarProducto_ProductoValido_DeberiaAgregarAlInventario()
        {
            // Arrange
            

            // Act
            _tienda.AgregarProducto(_mockProductoLaptop.Object);

            // Assert
            // Assert.That(_tienda.cantidadProductos(), Is.EqualTo(1)); // inventario 1
            Assert.That(_productos.Contains(_mockProductoLaptop.Object)); // producto en la lista
        }

        [Test]
        public void BuscarProducto_ProductoExistente_DeberiaDevolverProducto()
        {
            // Arrange
            _productos.Add(_mockProductoLaptop.Object);


            // Act
            var productoEncontrado = _tienda.BuscarProducto("Laptop");

            // Assert
            Assert.IsNotNull(productoEncontrado); // El producto encontrado no debe ser nulo
            Assert.That(productoEncontrado, Is.EqualTo(_mockProductoLaptop.Object)); // Debe devolver el producto correcto
        }

        // [Test]
        // public void EliminarProducto_ProductoExistente_DeberiaEliminarProducto()
        // {
        //     // Arrange
        //     _mockProducto.Setup(p => p.Nombre).Returns("Teclado");
        //     _mockProducto.Setup(p => p.Precio).Returns(50000m);
        //     _mockProducto.Setup(p => p.Categoria).Returns("Electronica");

        //     _productos.Add(_mockProducto.Object);

        //     // Act
        //     var resultado = _tienda.EliminarProducto("Teclado");

        //     // Assert
        //     Assert.IsTrue(resultado); // Debe devolver true indicando que se eliminó
        //     Assert.AreEqual(0, _tienda.cantidadProductos()); // El inventario debe estar vacío
        // }

        
        [Test]
        public void Calcular_total_carrito_debeDevolverUnValor()
        {
            // Arrange
            _productos.Add(_mockProductoLaptop.Object);
            _productos.Add(_mockProductoTeclado.Object);


            // Act
            decimal total = _tienda.CalcularTotalCarrito();

            // Assert
            // Assert.IsNotNull(productoEncontrado); // El producto encontrado no debe ser nulo
            Assert.That(total, Is.EqualTo(_mockProductoLaptop.Object.Precio+_mockProductoTeclado.Object.Precio)); // Debe devolver el producto correcto
        }
    }
}
