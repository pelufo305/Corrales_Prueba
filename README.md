# Prueba Jhonatan Gonzalez

# MicroServicio Siigo.Microservice.Corrales

Este proyecto esta creado con .NetCore 5  y principios SOLID

## Estilo Arquitectonico 

- Layers

## Diseño de Arquitectura 

- DDD (Domain Driven Design) 
- Microservicio


## Patrones de Diseño 

- Mediator
- AutoFact
- Command
- Inyección de Dependencias 

## Tecnologias
- .NetCore 5
- Fluent(Validaciones de los datos dentro de los comandos)
- Serilog(Centralizacion de Logs)
- Dapper (Mapeo de entidades y envio de datos ala base de datos )

## Archivos de configuración por Ambiente de despliegue 

- appsettings.Development.json
- appsettings.local.json
- appsettings.Testing.json
- appsettings.Production.json


## Token
- JWT (El token se encuentra seteado para que ejecute directamente sin configurar nada)

## Controladoras
> Corral

- Promedio(GET): http://localhost:5000/api/v1/corral/promedio/1
- Lista de Corrales(GET): http://localhost:5000/api/v1/corral
- Agregar Corral(POST): http://localhost:5000/api/v1/corral (Si el id es igual a 0 inserta si es mayor a 0 actualiza ese registro cone se id)
- Lista Tipo de animales(GET): http://localhost:5000/api/v1/corral/typeanimal (Este tipo es el que me relaciona  que animales puedne ir en el corral) 

> Animales
- Reporte o Lista de animales (GET): http://localhost:5000/api/v1/animal
- Agregar Animal (POST): http://localhost:5000/api/v1/animal (Si el id es igual a 0 inserta si es mayor a 0 actualiza ese registro cone se id)


## Base de datos

BAse de datos utilizada SQL Server el script ya cuenta con datos de prueba

## POSTMAN

Se envia los escenarios reséctivos para  ejecutar los metodos  aunque el proyecto viene con Swagger UI tambien


