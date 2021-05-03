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

## Token
- JWT

## Controladoras
> Corral

- Promedio(GET): http://localhost:5000/api/v1/corral/promedio/1
- Lista de Corrales(GET): http://localhost:5000/api/v1/corral
- Agregar Corral(POST): http://localhost:5000/api/v1/corral
- Lista Tipo de animales(GET): http://localhost:5000/api/v1/corral/typeanimal (Este tipo es el que me relaciona  que animales puedne ir en el corral) 

> Animales
- Reporte o Lista de animales (GET): http://localhost:5000/api/v1/animal
- Agregar Animal (POST): http://localhost:5000/api/v1/animal


## Base de datos

BAse de datos utilizada SQL Server



