# Project Introduction

This project is a simple ASP.NET Core 6.0 Web API application which allows users to test SQL injection.
Please note that this project uses an in-memory SQLite database that is created and populated each time the application starts. 
Any changes made to the data will be lost when the application stops.

The API will start and listen on http://localhost:8080 and https://localhost:8081.

The UI will be available at http://localhost:8090 and https://localhost:8091.

# How It Works

The application is structured into several parts:

- `ProductEntity`: This is the data model that represents a product in the system. Each product has a `Name` and a `Price`.
- `ProductRepository`: This is the data access layer of the application. It uses Dapper to interact with an SQLite database. On initialization, it creates a temporary file to serve as the database, creates a `Products` table, and populates it with some initial data. It provides methods to retrieve all products and search for products by name.
- `ProductController`: This is the API layer of the application. It exposes HTTP endpoints that correspond to the methods provided by `ProductRepository`.
- `Program.cs`: This is the entry point of the application. It sets up the ASP.NET Core pipeline, including services like Swagger for API documentation, and maps the controllers.

# Requirements

To run this project, you need the .NET 6 SDK.
