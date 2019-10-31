# Proyecto Clinica NetCore MVC MSSQL

[![Build Status](https://dev.azure.com/UMGwebapp/Clinica%20NetCore/_apis/build/status/amenpunk.ClinicaMvc?branchName=azure-pipelines)](https://dev.azure.com/UMGwebapp/Clinica%20NetCore/_build/latest?definitionId=9&branchName=azure-pipelines)

## Configuraciones:

## Generar Modelos

```bash
dotnet ef dbcontext scaffold "Server=.;Database=DATABASE;user id=sa;password=PASSWORD;" Microsoft.EntityFrameworkCore.SqlServer -o Models

```
## Generar Vistas/Controladores

```bash

dotnet aspnet-codegenerator controller -name nombremodeloController -m nombremodelo -dc nombreDelContexto --relativeFolderPath Controllers

```
