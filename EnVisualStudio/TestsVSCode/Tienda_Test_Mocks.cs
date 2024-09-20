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

    }
}
