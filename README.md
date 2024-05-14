# Customer Feedback Management System web api

## Overview

The Customer Feedback Management System is a robust web API built in C# using .NET 7. It serves as a backend MVP solution for managing customer feedback data. Leveraging the power of Microsoft Azure Cosmos NoSQL Database and Entity Framework Core for ORM, it offers a scalable and flexible architecture to handle large volumes of customer feedback data with ease in future. 

## Architecture Choice and Motivation

The decision to build the Customer Feedback Management System MVP on .NET 7 using Entity Framework Core for ORM and Microsoft Azure Cosmos NoSQL Database as the backend datastore was motivated by several factors:

Scalability: Azure Cosmos NoSQL Database offers horizontal scalability, allowing the system to seamlessly handle large volumes of customer feedback data as the user base grows.

Flexibility: Entity Framework Core simplifies data access and manipulation, providing a flexible and intuitive ORM solution that abstracts away the complexities of database interactions.

Cloud-Native Architecture: Leveraging Microsoft Azure services ensures a cloud-native architecture that enables seamless deployment, scalability, and reliability in a cloud environment.

Performance: Azure Cosmos NoSQL Database provides low-latency data access and high throughput, ensuring optimal performance for customer feedback data storage and retrieval operations.

## Usage
The Customer Feedback Management System Web API exposes a set of endpoints for interacting with customer feedback data. Detailed documentation on how to use the API endpoints can be found in the Swagger documentation provided.

## Steps to Run the Application

1. Clone the repository:
   ```
   git clone https://github.com/sid-succeeds/customer-feedback.git
   ```
2. Navigate to the project directory:
   ```
   cd project-directory
   ```
3. Restore dependencies:
   ```
   dotnet restore
   ```
4. Build the project:
   ```
   dotnet build
   ```
5. Run the application:
   ```
   dotnet run
   ```
6. The application will start, and it will assign a dynamic port number. Make note of the port number displayed in the console.
7. Open a web browser and navigate to `http://localhost:<port>` where `<port>` is the port number assigned to the application.

### Using Swagger

1. Once the application is running, navigate to `http://localhost:<port>/swagger` in your web browser.
2. Swagger UI will be displayed, allowing you to interactively test the API endpoints.
3. Explore the available versions, endpoints, input parameters, and responses.
4. Test the endpoints by sending requests directly from Swagger UI.

## Additional Notes

- **Sensitive Information**: Please note that the `appsettings.json` file containing sensitive information such as database connection strings has been intentionally left in the repository to run and test the application smoothly. They point to sandbox environments. You do not need to create your own `appsettings.json` file and configure it with the necessary settings to run the application.


