# TP1 - Ingeniería de Software


## Integrantes

- Leal, Nicolás
- Bilkis, Emmanuel Nicolás
- Rodriguez Romano, Franco
- Salcedo, Cristian Facundo


--- 1 ----
Preguntas:
- ¿Puedes identificar pruebas de unidad y de integración en la práctica que realizaste?

- A primer criterio podemos observar que los siguientes test son pruebas unitarias ya que son pruebas muy pegadas al codigo y no se esta probando de - forma directa como se comporta la interaccion entre dos modulos o clases.

- Algunas pruebas de Unidad:
-   public void buscarProductoPorNombre_meTieneDevolverProductoDelNombreSolicitado()
-   public void eliminarProducto_meTieneDevolverTrue()
-   public void agregarProducto_verificoContandolistaYbuscandolo()
-   public void BuscarProducto_NoExisteProducto_DeberiaLanzarArgumentException()

- Sin embargo desde un punto de vista mas teórico podriamos decir que se identifican pruebas de integracion ya que no podria tener una tienda sin pruductos para realizar estas pruebas.

--- 2 ---
- Podría haber escrito las pruebas primero antes de modificar el código de la aplicación?
¿Cómo sería el proceso de escribir primero los tests?

Si se podría escribir primero Test antes de modificar el codigo de la aplicación. Esto se lograria a través 
de TDD que es una técnica de diseño y test, es decir, se basa en diseñar a traves de los test.

El proceso sigue tres pasos clave:

Escribir una prueba: Creas un test para una funcionalidad específica que aún no está implementada.
Hacer que el test falle: Ejecutas la prueba y, como no hay código implementado, esta falla.
Escribir el código: Escribes solo el código necesario para que la prueba pase.
Refactorizar: Luego mejoras el código manteniendo las pruebas verdes (es decir, que pasen exitosamente).
Este ciclo asegura que el software se construya con pruebas desde el principio, lo que mejora la calidad y la seguridad del código.

--- 3 ---
- En lo que va del trabajo práctico, ¿puedes identificar 'Controladores' y 'Resguardos'?
Como controlador pudimos identificar nuestro Framework de prueba, NUnit, ya que dirige la prueba, ejecuta y verifica si el comportamiento del código es el esperado. 

Como resguardos puedo identificar los mocks que realizamos en el práctico: 

    AplicarDescuento_ProductoExistente_ActualizaPrecio()
    AgregarProducto_ProductoValido_DeberiaAgregarAlInventario()
    BuscarProducto_ProductoExistente_DeberiaDevolverProducto()
    EliminarProducto_ProductoExistente_DeberiaEliminarProducto()

- ¿Qué es un mock? ¿Hay otros nombres para los objetos/funciones simulados?

Un mock es un objeto simulado que imita el comportamiento de objetos reales en un entorno controlado. Los mocks se utilizan principalmente en pruebas unitarias para aislar la unidad de código que se está probando de sus dependencias externas, como bases de datos, servicios web, o cualquier otro componente que no se desea incluir en la prueba
Los mocks permiten definir el comportamiento esperado de las dependencias externas. Por ejemplo, puedes especificar que un método de un mock debe devolver un valor específico cuando se le llama con ciertos parámetros. Esto te permite probar cómo tu código maneja diferentes escenarios sin necesidad de interactuar con las dependencias reales.

Otros nombres para objetos/funciones simulados, además de los mocks, s que se utilizan en pruebas unitarias:

    - Stubs: Son objetos que devuelven datos predefinidos y no tienen lógica adicional. Se utilizan para proporcionar datos a la unidad de prueba.

    - Spies: Son similares a los mocks, pero además de simular el comportamiento, también registran información sobre cómo se utilizaron (por ejemplo, cuántas veces se llamó a un método).
    
    - Fakes: Son implementaciones simplificadas de las dependencias reales. A diferencia de los mocks y stubs, los fakes tienen una lógica interna que puede ser utilizada en las pruebas.
    
    - Dummies: Son objetos que no se utilizan realmente en la prueba, pero que se pasan como parámetros porque la firma del método lo requiere.

--- 4 --- 

- Qué ventajas ve en el uso de fixtures? ¿Qué enfoque estaría aplicando?
    El uso de fixtures en pruebas unitarias y de integración tiene varias ventajas importantes. Un fixture es un conjunto de condiciones o datos predefinidos que se utilizan para preparar el entorno de pruebas antes de ejecutar los tests. Aquí te explico las ventajas y el enfoque que estarías aplicando:

    Ventajas de usar fixtures
    
        Consistencia en las pruebas:
            Los fixtures aseguran que cada prueba se ejecute en un entorno controlado y consistente, lo que ayuda a obtener resultados reproducibles y confiables1.
        
        Reducción de código duplicado:
            Al definir un fixture, puedes reutilizar la configuración y los datos en múltiples pruebas, lo que reduce la duplicación de código y facilita el mantenimiento2.
        
        Facilita la configuración y limpieza:
            Los fixtures permiten configurar el entorno de pruebas antes de cada test y limpiarlo después, asegurando que no haya interferencias entre pruebas3.
        
        Mejora la legibilidad y organización:
            Al separar la configuración del entorno de pruebas del código de las pruebas en sí, los tests se vuelven más legibles y fáciles de entender4.
        
Enfoque de uso de fixtures: ??

    - SetUp:
        Antes de cada prueba, se ejecuta un método de configuración (SetUp) que prepara el entorno de pruebas. Esto puede incluir la creación de objetos, la inicialización de datos y cualquier otra configuración necesaria.
    
    - TearDown:
        Después de cada prueba, se ejecuta un método de limpieza (TearDown) que restaura el entorno a su estado original. Esto puede incluir la eliminación de datos temporales, la liberación de recursos y cualquier otra limpieza necesaria.


--- 5 ---

- ¿Puede describir una situación de desarrollo para este caso en donde se plantee pruebas de
integración ascendente? Describa la situación.

En este caso deberiamos comenzar con pruebas atómicas de la clase producto usando drivers q realicen el papel de Tienda. Primero deberias probar las funcionalidades de Producto, como crearlo, aliminarlo, modificar precio. Luego habría que probar la clase Tienda y finalmente la integracion con la clase producto ya probada. 
Al seguir este enfoque, nos garantizamos que los módulos individuales funcionan bien antes de integrarlos y probar el sistema completo.  