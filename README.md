# 🧩 Prueba Full Stack - .NET Clean Architecture

Proyecto de ejemplo para una prueba técnica de desarrollo full stack, utilizando .NET 8, Entity Framework Core, MySQL y siguiendo los principios de **Arquitectura Limpia**. Incluye casos de uso para CRUD de tareas, estructura modular y documentación automática con Swagger.

---

## 📁 Estructura del Proyecto

```plaintext
Src/
├── Api/
│ └── Controllers/
│ └── Program.cs
├── Application/
│ ├── Interfaces/
│ │ ├── ICreateTask.cs
│ │ ├── IDeleteTask.cs
│ │ ├── IGetAllTasks.cs
│ │ ├── ITaskRepository.cs
│ │ └── IUpdateTask.cs
│ └── UseCases/
│ ├── CreateTask/
│ │ └── CreateTask.cs
│ ├── DeleteTask/
│ │ └── DeleteTask.cs
│ ├── GetAllTasks/
│ │ └── GetAllTasks.cs
│ └── UpdateTask/
│ └── UpdateTask.cs
├── Domain/
│ └── Entities/
│ └── Task.cs
├── Infrastructure/
│ ├── Data/
│ │ └── AppDbContext.cs
│ └── Repositories/
│ └── TaskRepository.cs

```

Esta estructura permite mantener una separación clara de responsabilidades, facilitando el mantenimiento y la escalabilidad del proyecto.

---

## 🚀 Tecnologías Utilizadas

- **.NET 8** (ASP.NET Core Web API)
- **Entity Framework Core**
- **MySQL** (como base de datos relacional)
- **Swagger** (documentación de API)
- **Arquitectura limpia** (Clean Architecture)
- **Inyección de dependencias** (`Microsoft.Extensions.DependencyInjection`)
- **C# 11**

---

## 🧠 Características Principales

- CRUD completo de tareas (`Task`)
  - Crear tarea
  - Obtener todas las tareas
  - Marcar como completada
  - Actualizar tarea
  - Eliminar tarea
- Casos de uso desacoplados de la infraestructura
- Inversión de dependencias mediante interfaces
- Configuración de EF Core con base de datos In-Memory (para pruebas) y MySQL
- Documentación del API con Swagger UI

---

## ⚙️ Configuración

### 1. Requisitos Previos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [MySQL Server](https://www.mysql.com/)
- Visual Studio o VS Code
- Postman o navegador para probar el API

---

### 2. Clonar el Repositorio

```bash
git clone https://github.com/dmeloH/Prueba-fullstack.git
cd Prueba-fullstack
```

---

### 3. Configuración de la Base de Datos

Agrega tu cadena de conexión a MySQL en el archivo `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TasksDb;User=root;Password=tu_contraseña;"
}
```

---

### 4. Ejecutar migraciones (si se usa MySQL)

```bash
dotnet ef migrations add InitialCreate --project Src/Infrastructure
dotnet ef database update --project Src/Infrastructure
```

---

### 5. Ejecutar la Aplicación

```bash
dotnet run --project Src/Api
```

---

## 🔍 Swagger UI

Una vez ejecutado el proyecto, accede a la documentación interactiva en:

```
https://localhost:7277/swagger
```

O donde esté corriendo tu servidor.

---

## 🧪 Endpoints disponibles

| Método | Ruta                  | Descripción                 |
|--------|------------------------|-----------------------------|
| GET    | `/api/tasks`           | Obtener todas las tareas   |
| POST   | `/api/tasks`           | Crear una nueva tarea      |
| PUT    | `/api/tasks/{id}`      | Actualizar una tarea       |
| PUT    | `/api/tasks/{id}/complete` | Marcar tarea como completada |
| DELETE | `/api/tasks/{id}`      | Eliminar una tarea         |

---

## 👩‍💻 Autoría

**Daniela Melo**  
_Desarrolladora Full Stack_

📅 Versión: `0.2`  
📌 Fecha: `03/07/2025`

---

## 📄 Licencia

Este proyecto es solo para fines educativos o de evaluación técnica.
