# Guía Práctica: Implementación de Funcionalidades para la Entidad Empleado (Actividad Final)

## Introducción

En esta guía, se detallará el proceso para implementar funcionalidades CRUD (Crear, Leer, Actualizar y Eliminar) para la entidad `Empleado`. Los pasos seguirán el mismo enfoque utilizado para la entidad `Cliente` en los commits #ef6a7c6 y #4440d0b. Esta guía servirá como evaluación final y debe ser seguida atentamente para completar la tarea.
Esta construcción deberá ser en base a la rama EFCore, deben realizar un FORK.

## Objetivos

- Crear una interfaz y clase de servicio para la entidad `Empleado`.
- Integrar el servicio en la página `Empleados.razor`.
- Configurar dependencias en el contenedor de servicios.
- Añadir migraciones y actualizar la base de datos.
- Modificar el menú de navegación para incluir la gestión de empleados.

## Pasos

### 1. Crear la Interfaz y Clase de Servicio para Empleado

#### 1.1 Crear la Interfaz `IEmpleadoService`

Debes crear una interfaz que defina los métodos necesarios para manejar las operaciones de CRUD de la entidad `Empleado`. Esta interfaz debe incluir métodos para obtener todos los empleados, obtener un empleado por su ID, agregar un nuevo empleado, actualizar un empleado existente y eliminar un empleado por su ID.

#### 1.2 Crear la Clase `EmpleadoService`

Implementa la interfaz `IEmpleadoService` en una clase de servicio. Esta clase será responsable de realizar las operaciones CRUD utilizando un cliente HTTP para interactuar con la API. Asegúrate de implementar todos los métodos definidos en la interfaz.

### 2. Integrar el Servicio en la Página `Empleados.razor`

#### 2.1 Crear la Página `Empleados.razor`

Crea una nueva página en tu proyecto llamada `Empleados.razor`. Esta página debe permitir a los usuarios ver una lista de empleados, agregar nuevos empleados, editar empleados existentes y eliminar empleados. Utiliza el servicio `EmpleadoService` para realizar las operaciones necesarias.

### 3. Configurar Dependencias en el Contenedor de Servicios

Abre el archivo de configuración de tu aplicación y registra el `EmpleadoService` en el contenedor de dependencias. Esto permitirá que el servicio sea inyectado en la página `Empleados.razor` y en cualquier otro lugar donde sea necesario.


### 4. Modificar el Menú de Navegación

Abre el archivo de menú de navegación de tu proyecto y añade un enlace para la página `Empleados.razor`. Esto permitirá a los usuarios acceder fácilmente a la página de gestión de empleados desde cualquier lugar de la aplicación.

## Conclusión

Siguiendo estos pasos, habrás implementado las funcionalidades CRUD para la entidad `Empleado`, replicando el enfoque utilizado para la entidad `Cliente`. Asegúrate de probar cada funcionalidad y verificar que todo funcione correctamente. Esta guía debe servir como una evaluación final para tus estudiantes.
