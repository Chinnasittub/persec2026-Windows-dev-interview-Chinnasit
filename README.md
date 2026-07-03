# Persec Assessment Solution

## Project Overview

PersecSln is a .NET 8 console application developed as a solution for the Persec Windows Developer pre-interview assessment. The project implements all six coding challenges from the assessment PDF using clean architecture principles, emphasizing readability, maintainability, testability, and SOLID design practices.

The solution consists of a console application that demonstrates each challenge and a dedicated xUnit test project that validates expected behavior, edge cases, and overall correctness.

## Project Structure

- Persec.Console
  - Core/Interfaces
  - Core/Models
  - Core/Constants
  - Services
  - Helpers
  - Program.cs
- Persec.Tests
  - Unit tests for each service

## Architecture

The application follows a simple clean-architecture-inspired layout:

- Core contains interfaces and domain-oriented abstractions.
- Services contain concrete implementations of those abstractions.
- Helpers contain orchestration for console demonstrations.
- Program.cs handles dependency injection setup and startup.

## Design Decisions

- Dependency injection is used throughout the application.
- Each service has a single responsibility and is focused on one assessment item.
- Input validation is explicit and throws meaningful exceptions for invalid data.
- The implementation favors readability and maintainability over unnecessary abstraction.

## Design Patterns Used

- Service pattern for encapsulating business logic.
- Dependency injection for object composition.

## How to Build

```bash
dotnet build PersecSln.sln
```

## How to Run

```bash
dotnet run --project Persec.Console/Persec.Console.csproj
```

## How to Run Tests

```bash
dotnet test PersecSln.sln
```
