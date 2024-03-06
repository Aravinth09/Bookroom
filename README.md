**Bookroom Project**

The Bookroom project is a web application designed to manage a bookroom with user authentication and JWT-based authorization. It utilizes ASP.NET Core with Entity Framework Core for database interactions and token-based authentication for secure user access. and for user authetication it is using emailservices which restricts the contents to the respective users.

**Technologies Used:**

•	ASP.NET Core: Bookroom is built on the ASP.NET Core framework, which provides a cross-platform, high-performance environment for building modern web applications.

•	Entity Framework Core (EF Core): EF Core is used for data access and database management. It allows developers to work with data using .NET objects and provides a way to interact with various database systems.

•	ASP.NET Core Identity: ASP.NET Core Identity is used for user authentication and authorization. It provides a robust framework for managing user accounts, roles, and permissions within the application.

•	JWT (JSON Web Tokens): JWT is used for token-based authentication. It provides a secure way to transmit authentication data between the client and server, enabling stateless authentication and improved security.

•	SQLite: SQLite is a lightweight and embedded database engine that is used as the database backend for the Bookroom project. It offers simplicity and ease of use, making it suitable for small to medium-sized applications.

•	Swagger (Swashbuckle): Swagger is used for API documentation and testing. It automatically generates interactive API documentation based on the application's code, making it easier for developers to understand and use the available endpoints.

•	Microsoft.Extensions.Configuration: This component is used for configuration management in ASP.NET Core applications. It allows developers to read configuration settings from various sources, such as JSON files or environment variables.

•	Microsoft.Extensions.DependencyInjection: Dependency injection is used throughout the project to manage object dependencies and promote modular design. It helps improve the testability and maintainability of the codebase.

•	Newtonsoft.Json: Newtonsoft.Json is a popular JSON serialization library for .NET. It is used to serialize and deserialize JSON data within the application, facilitating communication between the client and server.

•	The project is written in C#, which is a widely used programming language for developing web applications, especially those built on the Microsoft.NET platform.

SQLite: A lightweight, file-based database engine used for local development.


**EndPoints Used:**

Basic Operations like CRUD(Create, Read, Update, Delete) have been performed

http://localhost:5235/weatherforecast  -Testing link for the project

CustomerController:GET - http://localhost:5235/api/customer

RolesController: GET - http://localhost:5235/api/roles

BookingOrderController: GET - http://localhost:5235/api/bookingorder

LocationController: - GET - http://localhost:5235/api/location

RoomtypeController: - GET - http://localhost:5235/api/roomtype

**Controller Setup**

The AccountController is an API controller ([ApiController]) with a base route of "api/[controller]" specified by the [Route] attribute. It injects dependencies such as UserManager, SignInManager, EmailService, and IConfiguration via constructor injection.

**Prerequisites:**


Before running the application, ensure you have the following installed:

.NET SDK 5.0 or later
SQLite (for local development)

**Configuration:**

Database Connection String: You can configure the database connection string in the appsettings.json file.

JWT Token Settings: JWT token settings such as issuer, audience, and key can be configured in the appsettings.json file.

**Authentication and Authorisation:**

http://localhost:5235/api/account/register -- Register the user

ASP.NET Core Identity:

ASP.NET Core Identity is used for user management, including user registration, login, and roles.
The AddIdentity<IdentityUser, IdentityRole>() method is called during service registration to configure Identity.

User Registration: Users can register for an account using the provided registration endpoint. ASP.NET Core Identity handles user creation and password hashing.

Role-Based Authorization: ASP.NET Core Identity supports role-based authorization. Users can be assigned to different roles, and access to specific API endpoints can be restricted based on these roles.

JWT (JSON Web Token) Authentication:

JWT is used for securing API endpoints by providing authentication tokens.
The application uses the AddJwtBearer() method to configure JWT authentication.

Access Control: JWT tokens are included in the headers of subsequent requests to protected API endpoints. The server verifies the tokens' authenticity and checks the user's claims to determine if they have the necessary permissions to access the requested resource.


DBContext:

DbContext used for interacting with the database is named BookroomContext. This context is responsible for managing the entity models and their interactions with the underlying database.

The BookroomContext class inherits from IdentityDbContext<IdentityUser>. This allows it to include the necessary tables for managing users and roles provided by ASP.NET Core Identity.

It declares DbSet properties for each entity model that needs to be stored in the database. In this example, there is a Books DbSet for managing book entities.

The OnModelCreating method can be overridden to provide additional configuration for the entity models, such as defining relationships or setting up constraints.

**Additional Notes:**

The roles will be assinged by the Admin based on the Roles the Users are restricted with certain actions which stands as best example for Authorisation and Authentication which adds up Security measures.

Azure Deployment Link:

https://bookroomapiuow.azurewebsites.net/weatherforecast











