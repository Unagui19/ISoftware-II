# TP1 - Ingeniería de Software


## Integrantes

- Leal, Nicolás
- Bilkis, Emmanuel Nicolás
- Rodriguez Romano, Franco
- Salcedo, Cristian Facundo


--- 1 ----
Preguntas:
- ¿Puedes identificar pruebas de unidad y de integración en la práctica que realizaste?

- Algunas pruebas de Unidad:
-   public void buscarProductoPorNombre_meTieneDevolverProductoDelNombreSolicitado()
-   public void eliminarProducto_meTieneDevolverTrue()
-   public void agregarProducto_verificoContandolistaYbuscandolo()
-   public void BuscarProducto_NoExisteProducto_DeberiaLanzarArgumentException()


--- 2 ---
- Podría haber escrito las pruebas primero antes de modificar el código de la aplicación?
¿Cómo sería el proceso de escribir primero los tests?


Se puede esscribir las pruebas primero antes de modificar el código de la aplicación. Esta es una práctica conocida como
Desarrollo basado en pruebas (TDD), el cuak consiste en que los desarrolladores crean pruebas para verificar los requisitos funcionales de un programa antes de crear el código completo. Al escribir primero las pruebas, el código se puede verificar al instante en función de los requisitos, una vez que se realiza la codificación y se ejecutan las pruebas.

Proceso de TDD
- Escribir una prueba fallida:
    Primero, escribes una prueba que defina una nueva funcionalidad o mejora que deseas implementar. Esta prueba inicialmente fallará porque la funcionalidad aún no está implementada.

- Escribir el código mínimo necesario:
    Luego, escribes el código mínimo necesario para hacer que la prueba pase. Este código no tiene que ser perfecto ni completo, solo lo suficiente para que la prueba pase.
- Refactorizar:
    Una vez que la prueba pasa, refactorizas el código para mejorar su estructura y eliminar duplicaciones, asegurándote de que todas las pruebas sigan pasando.

--- 3 ---
- En lo que va del trabajo práctico, ¿puedes identificar 'Controladores' y 'Resguardos'?



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

