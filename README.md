# FitoplantonAPI

Una REST API con arquitectura limpia para gestionar datos de fitoplancton.  
Construida con ASP.NET Core, MySQL y aprovechando MediatR, FluentValidation y el patrón Repository.

---

## 🚀 Características

- **CRUD** para especies de fitoplancton y sus clasificaciones  
- Validación con **FluentValidation**  
- CQRS / Mediator con **MediatR**  
- Abstracción de acceso a datos con **IRepositoryAsync\<T\>**  
- Persistencia en MySQL vía Entity Framework Core  
- Manejo uniforme de respuestas con un wrapper `Response<T>`  
- Arquitectura limpia (Clean Architecture)

---

## 🛠 Tecnologías

- **.NET 8.0** 
- **ASP.NET Core Web API**  
- **Entity Framework Core** (provider MySQL)  
- **MediatR** para comandos/consultas y behaviors  
- **FluentValidation** para validación de DTOs  
- **MySQL** como motor de base de datos  

---

## 📋 Configurar 

Configura la cadena de conexión en appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=FitoplantonDb;User=root;Password=TuContraseña;"
}


## 🗂 Estructura del Proyecto

| Proyecto       | Responsabilidad                                          |
| -------------- | -------------------------------------------------------- |
| Application    | Handlers CQRS, DTOs, validaciones, interfaces            |
| Domain         | Entidades de negocio y contratos de dominio              |
| Infrastructure | DbContext, repositorios EF, migrations, implementaciones |
| Host           | Controladores, middlewares, configuración ASP.NET Core   |



## 🔑 Patrones y Librerías Clave

- Clean Architecture: separa UI, lógica de negocio y acceso a datos

- MediatR: patrón Mediator para comandos/consultas + behaviors

- FluentValidation: validación declarativa de DTOs

- Repository: IRepositoryAsync<T> para abstracción de EF Core

- Response Wrapper: Response<T> para respuestas uniformes

---

## 🏗 Arquitectura y Estructura de Carpetas

```text
FitoplantonAPI/
│
├─ src/
│   ├─ Application/        ← Lógica de negocio, Handlers CQRS, DTOs, Interfaces
│   │   ├─ Behaviours      ← Behaviors de MediatR (Validación, Logging…)
│   │   ├─ DTOs            ← Modelos de petición/respuesta
│   │   ├─ Exceptions      ← Excepciones personalizadas
│   │   ├─ Features        ← Commands, Queries y Handlers
│   │   ├─ Interfaces      ← IRepositoryAsync<T>, otros contratos
│   │   ├─ Wrappers        ← Response<T>, estructuras de resultado
│   │   └─ ServiceExtensions.cs ← Extensión para registrar servicios DI
│   │
│   ├─ Domain/             ← Entidades y contratos del dominio
│   │   ├─ Entities        ← Entidades (Phytoplankton, Classification…)
│   │   └─ Contracts       ← Interfaces de dominio (si aplica)
│   │
│   ├─ Infrastructure/     ← Implementaciones concretas, EF Core, repositorios
│   │   ├─ Persistence/    ← DbContext, migrations, repositorios EF
│   │   └─ ServiceExtensions.cs ← Extensión para registrar DI de Infrastructure
│   │
│   └─ Host/               ← Proyecto ASP.NET Core Web API
│       ├─ Controllers     ← Controladores (delgados, llaman a MediatR)
│       ├─ Middlewares     ← Manejo de excepciones, logging, etc.
│       ├─ appsettings.json← Configuración (ConnectionStrings, Logging…)
│       └─ Program.cs      ← Punto de entrada, configuración de DI y pipeline
└─ FitoplantonAPI.sln

