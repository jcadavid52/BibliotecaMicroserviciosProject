# 📚 Biblioteca Microservicios Project

Este proyecto contiene dos microservicios (el de **cuentas** y **libros**) que pueden ejecutarse en contenedores Docker mediante **docker-compose**.

---

## 🚀 Instrucciones de ejecución

### 1️⃣ Clonar el repositorio

```bash
git clone https://github.com/jcadavid52/BibliotecaMicroserviciosProject.git
```

---

### 2️⃣ Ubicarse en el directorio del archivo `docker-compose.yml`

```bash
cd BibliotecaMicroserviciosProject
```

---

### 3️⃣ Construir y levantar los contenedores

Ejecuta el siguiente comando:

```bash
docker-compose up --build
```

Esto descargará las imágenes necesarias y levantará los microservicios junto con la base de datos SQL Server.

---

### 4️⃣ Configurar las propiedades (opcional)

Si deseas ajustar los puertos o credenciales, abre el archivo:

```
docker-compose.yml
```

y modifica las propiedades de los servicios según tus necesidades.

---

### 5️⃣ Conexión a la base de datos

Por defecto, la base de datos se expone en el puerto **1436**.

Puedes conectarte desde SQL Server Management Studio (SSMS) o Azure Data Studio usando:

```
Servidor: localhost,1436
Usuario: sa
Contraseña: suPassword
```

---

### 6️⃣ Migraciones de los microservicios

Una vez levantado el entorno, debes **agregar la migración de cada microservicio**, asegurándote de que la cadena de conexión apunte a:

```
Server=localhost,1436;
```

---

### 7️⃣ Script adicional para el microservicio de Cuentas

El microservicio de **Cuentas** requiere una tabla adicional llamada **RefreshToken**.  
Ejecuta el siguiente script dentro de la base de datos `SistemaCuentasDb`:

```sql
USE [SistemaCuentasDb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RefreshToken](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Token] [varchar](200) NOT NULL,
    [IsRevoked] [bit] NOT NULL,
    [CreateAt] [datetime2](7) NOT NULL,
    [ExpiresAt]  AS (dateadd(day,(3),[CreateAt])) PERSISTED NOT NULL,
    [UserId] [nvarchar](450) NOT NULL,
PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (
    PAD_INDEX = OFF, 
    STATISTICS_NORECOMPUTE = OFF, 
    IGNORE_DUP_KEY = OFF, 
    ALLOW_ROW_LOCKS = ON, 
    ALLOW_PAGE_LOCKS = ON, 
    OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RefreshToken] ADD DEFAULT (sysdatetime()) FOR [CreateAt]
GO

ALTER TABLE [dbo].[RefreshToken] WITH CHECK ADD CONSTRAINT [FK_RefreshToken_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[AccountUsers] ([Id])
GO

ALTER TABLE [dbo].[RefreshToken] CHECK CONSTRAINT [FK_RefreshToken_User]
GO
```

---

## 🧩 Depuración local

Si deseas **depurar** los microservicios en tu máquina local:

1. Crea las migraciones de cada microservicio manualmente (sin usar Docker).
2. Para el microservicio de **Cuentas**, recuerda también crear la tabla `RefreshToken` usando el script anterior.

---

## ⚠️ Importante

Para evitar conflictos al depurar localmente, **comenta el siguiente fragmento de código** en el archivo `Program.cs` de cada microservicio:

```csharp
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8090);
});
```

Esto evita que el servidor intente escuchar en puertos reservados mientras ejecutas la aplicación desde Visual Studio o VS Code.

---

## 🧠 Notas finales

- Este proyecto utiliza **Docker**, **.NET 8** y **SQL Server**.  
- Puedes modificar los puertos o credenciales desde el archivo `docker-compose.yml`.  
- Si tienes errores al conectarte a la base de datos, asegúrate de que el contenedor de SQL Server esté corriendo:

```bash
docker ps
```

---

✉️ **Autor:** [@jcadavid52](https://github.com/jcadavid52)

