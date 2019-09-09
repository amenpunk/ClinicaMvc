# Proyecto Clinica NetCore MVC MSSQL

## Configuraciones:

## Generar Modelos

```bash

dotnet ef dbcontext scaffold "Server=.;Database=DATABASE;user id=sa;password=PASSWORD;" Microsoft.EntityFrameworkCore.SqlServer -o Models

```
## Generar Vistas/Controladores

```bash

dotnet aspnet-codegenerator controller -name nombremodeloController -m nombremodelo -dc nombreDelContexto --relativeFolderPath Controllers

```