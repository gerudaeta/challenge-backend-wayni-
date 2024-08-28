# WAYNI CHALLENGE - SOLUCIÓN

### ¡Hola, bienvenidos!

Paso a comentar un poco sobre la solución que he implementado para el desafío propuesto.

### Solución
- Se refactorizó la clase FormaGeometrica para que sea más fácil de extender y mantener.
- Se implementó los principios de POO para que la clase FormaGeometrica sea más flexible y extensible.
- Se implementó el patrón de diseño Factory Method para la creación de instancias de las formas geométricas.
- Se implementó un proyecto WebAPI para la exposición de los métodos CalcularPerimetro y CalcularArea.
- Se implementó un proyecto de pruebas unitarias para probar la funcionalidad del servicio y factory creado, utilizando la librería NUnit y Moq para mockear los objetos necesarios.
- Se implementó Inyeccion de dependencia
- Se implementó el uso de interfaces para la implementación de los servicios
- Se implementó Swagger para documentar la API
- Se implementó la libreria FluentValidation en el proyecto de WebAPI para validar los datos de entrada

#### Se trato de seguir los principios SOLID y buenas prácticas de programación, asi como tambien se implementó un diseño limpio y fácil de entender.
#### DRY (Don't Repeat Yourself) y KISS (Keep It Simple, Stupid) fueron principios que se tuvieron en cuenta al momento de implementar la solución.
YANGI (You Aren't Gonna Need It) fue un principio que se tuvo en cuenta para no implementar funcionalidades que no se necesitan en el momento.

### Tecnologías utilizadas
- .NET 8
- C#
- WebAPI
- NUnit
- Moq
- FluentValidation
- Swagger
- Middleware (a medias) utilizando ProblemDetails para manejar errores y tener un estandard en las respuestas de la API en caso de error.

### Instrucciones para ejecutar el proyecto
1. Clonar el repositorio
2. Abrir la solución en Visual Studio
3. Compilar la solución
4. Establecer el proyecto WebAPI como proyecto de inicio
5. Ejecutar la solución

### Instrucciones para ejecutar las pruebas unitarias
1. Abrir la solución en Visual Studio
2. Compilar la solución
3. Establecer el proyecto de pruebas unitarias como proyecto de inicio
4. Ejecutar la solución
5. Verificar que todas las pruebas pasen

### Sobre el pedido de disponibilizar un endpoint que calcule el area y perimetro
- Se creo un servicio que aplica el patron factory para la creacion de las formas geometricas y asi puede devolver el area y perimetro de las formas geometricas
- Se implementó un endpoint en la API que recibe un objeto JSON con los datos necesarios para calcular el área y perímetro de una forma geométrica.
- Dicho endpoint se encuentra en la ruta /api/ReporteFormasController/calcular
- Se implementó un middleware para manejar los errores y devolver un estandard en las respuestas de la API en caso de error.
- Devuelve un objeto con el tipo de forma, el area y el perimetro.