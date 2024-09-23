using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit;
using TP1_IS;

namespace TestProject
{
    [TestFixture] //indica que es una clase de prueba
    internal class test_producto
    {
        //inicio de atributos
        
        private Mock<IProducto> _productoMock; //mock
        private Producto? _producto; //objeto
        
        //getter y setter

        public Producto producto { get => _producto; set => _producto = value; }

        //inicio de metodos

        [SetUp] //se ejecuta antes de inicializar el proyecto
        public void setup() {
            _productoMock = new Mock<IProducto>();
            producto = new Producto(_productoMock.Object); //le paso el mock que simula ser un objeto
        }

        [Test] //prueba de actualizar precio test
        public void ActualizarPrecio_test()
        {
            //verificar la excepcion al ser negativo
            Assert.Throws<ArgumentException>(() => producto.ActualizarPrecio(-23));
        }
    
    }
}
