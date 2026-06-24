# 🛡️ Challenge N5 — API de Permisos

Solución al challenge técnico de **N5**: una API para gestionar **permisos de empleados** (solicitar, modificar y consultar), construida con **arquitectura limpia en .NET** y un **frontend en React**, todo containerizado con Docker.

## 🚀 Funcionalidades

La API expone las tres operaciones del challenge sobre la entidad `Permiso`:

| Operación | Método | Endpoint |
|---|---|---|
| Solicitar permiso | `POST` | `/RequestPermission` |
| Modificar permiso | `PUT`  | `/ModifyPermission/{id}` |
| Listar permisos | `GET`  | `/GetPermissions` |

Cada `Permiso` tiene: nombre y apellido del empleado, tipo de permiso (`TipoPermiso`) y fecha.

## 🏗️ Arquitectura

Backend en **Clean Architecture**, separando responsabilidades por capas (cada una en su propio proyecto):

```
Back End/WebApi/
├── WebApi/                    # API / Controllers (capa de presentación)
├── WebApi.Aplication/         # Casos de uso / lógica de aplicación
├── WebApi.Services/           # Servicios de dominio
├── WebApi.Repository/         # Acceso a datos (repositorios)
├── WebApi.Infraestructure/    # EF Core, entidades de dominio (Permiso, TipoPermiso)
├── WebApi.Models/             # DTOs y modelos
└── WebApi.Test/               # Tests unitarios
```

Las capas internas no dependen de las externas y los servicios se resuelven por **inyección de dependencias** (`IPermissionServices`).

## 🛠️ Stack

- **Backend:** .NET (ASP.NET Core Web API), Entity Framework Core
- **Frontend:** React (`Front End/n5front`)
- **Infra:** Docker (la imagen del backend se llama `WebApi.Aplication`)

## ▶️ Cómo correrlo

**Backend (Docker):**
```bash
cd "Back End/WebApi"
docker build -t webapi.aplication .
docker run -p 8080:8080 webapi.aplication
```

**Frontend:**
```bash
cd "Front End/n5front"
npm install
npm start
```

## 🖼️ Arquitectura / capturas

![image](https://github.com/francososa97/Challenge-N5/assets/48955963/d7d60a62-4480-4d08-9787-aebfb0aa4839)
![image](https://github.com/francososa97/Challenge-N5/assets/48955963/ccf71aac-9048-4ceb-b98e-86f64f4d1137)
![image](https://github.com/francososa97/Challenge-N5/assets/48955963/d2aaecac-724c-4305-9053-f08dd6c8c32a)
![image](https://github.com/francososa97/Challenge-N5/assets/48955963/979fba95-35b6-46a7-9705-f3f11a27421e)

---

> Resuelto por [Franco Sosa](https://github.com/francososa97) como challenge técnico de N5.
