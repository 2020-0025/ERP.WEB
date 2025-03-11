# ERP.Web

## Descripción
ERP.Web es un proyecto Blazor que proporciona una solución de planificación de recursos empresariales (ERP) para gestionar clientes, productos y pedidos.

## Instalación
Para instalar y ejecutar este proyecto localmente, sigue estos pasos:

1. Clona el repositorio:
`git clone https://github.com/fbenzan/BlazorServerHolaMundo.git`
## Uso
Una vez que la aplicación esté en funcionamiento, puedes acceder a ella en tu navegador web en `https://localhost:7165`. La aplicación incluirá las siguientes funcionalidades:

- **Gestión de Clientes**: Añadir, editar y eliminar clientes.
- **Gestión de Empleados**: Añadir, editar y eliminar empleados.

## Contribución
Si deseas contribuir a este proyecto, por favor sigue estos pasos:

1. Haz un fork del repositorio.
2. Crea una nueva rama (`git checkout -b feature/nueva-funcionalidad`).
3. Realiza tus cambios y haz commit (`git commit -am 'Añadir nueva funcionalidad'`).
4. Sube tus cambios a tu rama (`git push origin feature/nueva-funcionalidad`).
5. Abre un Pull Request.

## Licencia
Este proyecto está licenciado bajo una licencia pública. Consulta el archivo [LICENSE](LICENSE) para más detalles.

## Gestión de Migraciones de EF Core
Para gestionar las migraciones de Entity Framework Core en la carpeta `Data/Migrations`, sigue estos pasos:

0. **Instatalar la herramienta de línea de comandos de EF Core**:
`dotnet tool install --global dotnet-ef`
1. **Crear una nueva migración**:
`dotnet ef migrations add NombreDeLaMigracion -o Data/Migrations`
2. **Aplicar las migraciones a la base de datos**:
`dotnet ef database update`
3. **Eliminar la última migración (si es necesario)**:
`dotnet ef migrations remove`
 