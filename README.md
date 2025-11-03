# TechAndSolve Web API - Servicio de Clientes

Un servicio API RESTful construido con .NET 9 para la gestión de clientes y autenticación de usuarios. Este proyecto implementa los principios de Clean Architecture con capas separadas para API, Aplicación, Dominio e Infraestructura.

## 🏗️ Arquitectura

El proyecto sigue **Clean Architecture** y está organizado en las siguientes capas:

- **Capa API** (`TechAndSolve.WBAPI.Clients.API`) - Controladores, middleware y configuración de la API
- **Capa de Aplicación** (`TechAndSolve.WBAPI.Clients.Application`) - Lógica de negocio, servicios, DTOs y validadores
- **Capa de Dominio** (`TechAndSolve.WBAPI.Products.Domain`) - Entidades, interfaces y modelos de dominio
- **Capa de Infraestructura** (`TechAndSolve.WBAPI.Clients.Infrastructure`) - Base de datos, repositorios y servicios externos

## 🚀 Tecnologías

- **.NET 9** (C# 13.0)
- **ASP.NET Core Web API**
- **Entity Framework Core** - ORM para operaciones de base de datos
- **SQL Server** - Proveedor de base de datos
- **FluentValidation** - Validación de solicitudes
- **JWT Bearer Authentication** - Autenticación segura
- **Scrutor** - Escaneo de ensamblados e inyección de dependencias
- **BCrypt** - Hash de contraseñas
- **OpenAPI** - Documentación de la API

## 📋 Requisitos Previos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/sql-server) (LocalDB, Express o versión completa)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) o [Visual Studio Code](https://code.visualstudio.com/)

## ⚙️ Configuración

### 1. Cadena de Conexión a la Base de Datos

Actualice el archivo `appsettings.json` en el proyecto `TechAndSolve.WBAPI.Clients.API`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TechAndSolveClientsDb;Trusted_Connection=true;TrustServerCertificate=true"
  }
}
```

### 2. Configuración de JWT

Agregue la configuración de JWT en `appsettings.json`:

```json
{
  "Jwt": {
    "Key": "su-clave-super-secreta-de-al-menos-32-caracteres",
    "Issuer": "TechAndSolve.API",
    "Audience": "TechAndSolve.Client",
  }
}
```

### 3. Migración de Base de Datos

Ejecute los siguientes comandos para crear y actualizar la base de datos:

```bash
# Navegue al directorio del proyecto API
cd TechAndSolve.WBAPI.Clients.API

# Crear migración (si es necesario)
dotnet ef migrations add InitialCreate --project ..\TechAndSolve.WBAPI.Clients.Infrastructure

# Actualizar base de datos
dotnet ef database update --project ..\TechAndSolve.WBAPI.Clients.Infrastructure
```

## 🏃 Ejecutar la Aplicación

### Usando Visual Studio 2022

1. Abra el archivo de solución (`.sln`)
2. Establezca `TechAndSolve.WBAPI.Clients.API` como proyecto de inicio
3. Presione `F5` o haga clic en "Ejecutar"

### Usando .NET CLI

```bash
cd TechAndSolve.WBAPI.Clients.API
dotnet run
```

La API estará disponible en:
- HTTPS: `https://localhost:7083`
- HTTP: `http://localhost:5050`

## 📚 Documentación de la API

La API proporciona la siguiente funcionalidad:

### Autenticación
- Registro de usuarios
- Inicio de sesión con generación de token JWT

### Gestión de Clientes
- Obtener todos los clientes
- Obtener cliente por ID
- Crear nuevo cliente
- Actualizar cliente existente
- Eliminar cliente

> **Nota:** Todos los endpoints de clientes requieren autenticación JWT. Incluya el token en el encabezado de autorización.

Para documentación detallada de la API y pruebas interactivas, acceda al endpoint de OpenAPI cuando se ejecute en modo de desarrollo:
- OpenAPI/Swagger: `https://localhost:7084/openapi/v1.json`

## 🛡️ Características de Seguridad

- **Autenticación JWT** - Autenticación segura basada en tokens
- **Hash de Contraseñas** - Algoritmo BCrypt para almacenamiento seguro de contraseñas
- **FluentValidation** - Validación de entrada para prevenir datos maliciosos
- **Filtro Global de Excepciones** - Manejo centralizado de errores
- **Aplicación de HTTPS** - Comunicación segura

## 📁 Estructura del Proyecto

```
TechAndSolve.WBAPI/
├── TechAndSolve.WBAPI.Clients.API/
│   ├── Controllers/
│   │   ├── AuthController.cs
│   │   └── ClientsController.cs
│   ├── Extensions/
│   │   └── ServiceCollectionExtensions.cs
│   ├── Filters/
│   │   └── ExceptionFilter.cs
│   └── Program.cs
├── TechAndSolve.WBAPI.Clients.Application/
│   ├── Auth/
│   │   ├── Dtos/
│   │   ├── Mappings/
│   │   ├── Requests/
│   │   ├── Services/
│   │   └── Validators/
│   └── Clients/
│       ├── Mappings/
│       ├── Requests/
│     ├── Responses/
│       ├── Services/
│       └── Validators/
├── TechAndSolve.WBAPI.Products.Domain/
│   ├── Bases/
│   ├── Clients/
│   ├── Interfaces/
│   └── Users/
└── TechAndSolve.WBAPI.Clients.Infrastructure/
    ├── Persistence/
    │   ├── Repositories/
    │   └── UnitOfWork/
    └── Services/
        └── Identity/
```

## 🔧 Características Principales

- **Patrón Repository** - Abstracción de acceso a datos
- **Unit of Work** - Gestión de transacciones
- **Inyección de Dependencias** - Registro automático de servicios con Scrutor
- **Validación de Solicitudes** - FluentValidation con mensajes de error detallados en español
- **Extensiones de Mapeo** - Mapeo limpio de objetos entre capas
- **Manejo Global de Excepciones** - Respuestas de error consistentes
- **Constructores Primarios** - Sintaxis moderna de C# 13.0

## 📝 Reglas de Validación

### Validación de Cliente
- **Nombre**: Requerido, máximo 100 caracteres
- **Apellido**: Requerido, máximo 100 caracteres
- **Email**: Requerido, formato de email válido
- **Teléfono**: Requerido, máximo 9 caracteres, solo numérico
- **Dirección**: Requerido, máximo 200 caracteres

### Validación de Usuario
- **Email**: Requerido, formato de email válido
- **Contraseña**: Requerido, mínimo 6 caracteres

## 🔨 Guías de Desarrollo

### Agregar una Nueva Entidad

1. Crear la entidad en la capa de Dominio
2. Crear la interfaz del repositorio en Dominio
3. Implementar el repositorio en Infraestructura
4. Crear DTOs de solicitud/respuesta en Aplicación
5. Crear validadores usando FluentValidation
6. Implementar el servicio en Aplicación
7. Crear el controlador en API

### Estilo de Código

- Use características de **C# 13.0** (tipos record, constructores primarios, etc.)
- Siga los principios de **Clean Architecture**
- Use **async/await** para todas las operaciones de I/O
- Implemente **manejo de errores** y validación adecuados
- Escriba **mensajes de commit significativos**
- Use **español** para mensajes de validación y errores orientados al usuario

### Construir el Proyecto

```bash
# Restaurar dependencias
dotnet restore

# Compilar la solución
dotnet build

# Ejecutar pruebas (si están disponibles)
dotnet test

# Ejecutar la aplicación
dotnet run --project TechAndSolve.WBAPI.Clients.API
```

## 🧩 Dependencias

### Proyecto API
- Microsoft.AspNetCore.OpenApi
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.EntityFrameworkCore.Tools
- Scrutor

### Proyecto Application
- FluentValidation
- FluentValidation.DependencyInjectionExtensions

### Proyecto Infrastructure
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- BCrypt.Net-Next

## 🤝 Contribuir

1. Haga un fork del repositorio
2. Cree una rama de características (`git checkout -b feature/CaracteristicaIncreible`)
3. Confirme sus cambios (`git commit -m 'Agregar alguna CaracteristicaIncreible'`)
4. Empuje a la rama (`git push origin feature/CaracteristicaIncreible`)
5. Abra un Pull Request

## 📄 Licencia

Este proyecto es parte de TechAndSolve y está destinado a fines de entrevista y de demostración.

## 👥 Autores

- **Equipo TechAndSolve** - [GitHub](https://github.com/sebasmm12/tech-and-solve-WBAPI)
  
---

**Rama:** `qa-WBAPI`  
**Repositorio:** [tech-and-solve-WBAPI](https://github.com/sebasmm12/tech-and-solve-WBAPI)
