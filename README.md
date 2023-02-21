What is the VictoryRestaurant.Foods?
=====================
The service is responsible for providing access to food.

It is part of the [restaurant automation system](https://github.com/VictoryRestaurant).

## Give a Star! :star:
If you liked my work - give a :star: ))

<details open="">

 <summary><b>Database</b></summary>
  
  ```mermaid

classDiagram
    class foods {
        +uuid id
        +timestamp created_date
        +text name
        +text description
        +decimal cost
        +text image_path
        +uuid food_type_id
    }

    class food_types {
        +uuid id
        +text name
    }
    
    foods <| -- food_types

```
  
</details>

## Technologies implemented:

- .NET 8
- ASP.NET Web API
- Docker Compose
- Swagger UI
- Entity Framework
- PostgreSQL
- Microsoft DependencyInjection
- Serilog
- MediatR
- xUnit
- Bogus
- FluentAssertions
- Moq

## Architecture:

- Clean architecture
- CQRS (Commands & Queries)
- Repositories
