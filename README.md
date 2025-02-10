# MauiWebApp

MauiWebApp is a budgeting application that includes solutions for both a Blazor web app and a .NET MAUI multi-platform app. This application helps users manage their expenses and track their budget across different platforms.

## Project Structure

The repository is organized into the following main directories:

- `MauiWebApp/`: Contains the main .NET MAUI application.
- `MauiWebApp.Domain/`: Contains domain models and business logic.
- `MauiWebApp.Shared/`: Contains shared components and services used by both the Blazor web app and the .NET MAUI app.
- `MauiWebApp.Web/`: Contains the Blazor web application.

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) with the following workloads:
  - .NET Multi-platform App UI development
  - ASP.NET and web development

## Building and Running the Projects

### .NET MAUI Application

1. Open the solution file `MauiWebApp.sln` in Visual Studio 2022.
2. Set `MauiWebApp` as the startup project.
3. Select the target platform (Android, iOS, Windows, etc.) from the platform selector.
4. Click on the "Run" button or press `F5` to build and run the application.

### Blazor Web Application

1. Open the solution file `MauiWebApp.sln` in Visual Studio 2022.
2. Set `MauiWebApp.Web` as the startup project.
3. Click on the "Run" button or press `F5` to build and run the application.

## Project Details

### MauiWebApp

The .NET MAUI application is located in the `MauiWebApp/` directory. It includes platform-specific code and resources for Android, iOS, Windows, and MacCatalyst.

### MauiWebApp.Domain

The `MauiWebApp.Domain/` directory contains the domain models and business logic used by the application. This includes models for expenses and budgeting.

### MauiWebApp.Shared

The `MauiWebApp.Shared/` directory contains shared components and services that are used by both the Blazor web app and the .NET MAUI app. This includes Razor components, services, and other shared resources.

### MauiWebApp.Web

The Blazor web application is located in the `MauiWebApp.Web/` directory. It includes the Blazor components and services needed to run the web version of the budgeting app.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.
