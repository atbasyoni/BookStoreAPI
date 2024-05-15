# Book Store API
# Project Overview

Book Store API built using ASP.NET Core Web API. The project incorporates the principles of Inversion of Control (IoC) and Dependency Injection (DI) for a modular and maintainable codebase. It also includes features like JWT and Refresh Token for secure authentication and authorization. AutoMapper is utilized for efficient object mapping, and the API exposes three controllers: Book, Author, and Genre.

## Getting Started

To get started with the Football API project, follow these steps:

1. Clone or download the project repository to your local machine.
2. Open the project in your preferred development environment.
3. Configure the project settings, including database connection strings, JWT token settings, and other environment-specific configurations.
4. Run the project and access the API endpoints to retrieve information about football leagues, clubs, and players.

### Prerequisites

Book Store API (Endpoints) is designed to be user-friendly and intuitive, making it easy for healthcare providers and patients to navigate. Here's a step-by-step guide on how to use the Endpoints effectively:

- You will need the latest Visual Studio 2022 and the latest .NET Core 8.
- You will need  an MS SQL Server
- Make sure from the configuration in the **AppSettings.json** file that meets the application features :
    (**JWT** for Authentication and Authorization)

### JWT Configuration Section

```json
"JWT": {
    "ValidIssuer": "",
    "ValidAudiance": "",
    "Key": "",
    "DurationInMintues": 
  },
```
- And you can make Your key from here  'https://8gwifi.org/jwsgen.jsp'

- Install Packages from **NuGet Package Manager** Or **Package Manager Console**
```
    Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection
    Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore
    Install-Package Microsoft.EntityFrameworkCore
    Install-Package Microsoft.EntityFrameworkCore.Tools
    Install-Package Microsoft.EntityFrameworkCore.SqlServer
    Install-Package Microsoft.AspNetCore.Authentication.JwtBearer
    Install-Package Swashbuckle.AspNetCore
```

- In **Package Manager Console** make Db migration using command

```cmd
Add-Migration InitialMigration
```
- Write another command to update the database

```cmd
Update-Database
```
- Change the connection string (SQL Server, username & password )

```json
 "ConnectionStrings": {
    "DefaultConnection": "Data Source=[Server Name];Initial Catalog=[DataBase Name];User ID=[Sql server Username];Password=[Sql server Password];Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"
  }
```
