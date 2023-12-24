# Product Management Application

This ASP.NET Core web application performs basic CRUD (Create, Read, Update, Delete) operations for managing products.

## Project Structure

- **Controllers:** Contains controller classes that handle HTTP requests.
- **DBOperations:** Contains classes responsible for database operations.
- **Common:** Includes commonly used classes.
- **ProductOperations:** Contains command, query, and model classes for product operations.
- **Models:** Includes data model classes for the application.
- **Services:** Contains business logic services.

## Database

The application represents a SQL Server database using Entity Framework Core. The `ProductDbContext` class manages the database connection and includes the `Products` table. Additionally, the `DataGenerator` class seeds initial data into the database.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- Dependency Injection
- RESTful API

## How to Run

1. Clone this repository to your machine.
2. Open the project using an IDE such as Visual Studio or Visual Studio Code.
3. Run the application. (Since InMemoryDatabase is used, no database update process is required.)