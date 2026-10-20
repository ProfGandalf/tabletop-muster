# Tabletop Muster

A browser-based army list builder for tabletop miniature wargames, inspired by Warhammer 40,000. Build armies from the available units, get automatic point calculation and points limit checks, and add your own custom units.

Project developed for the course **Zespołowe Tworzenie Projektów IT** (Team IT Project Development) at Opole University of Technology, winter semester 2026/2027.

**Team:** Marcin Dziony, Przemysław Kowal

## Documentation

- [Project specification](docs/project-specification.md): vision, value proposition, requirements, user stories, MVP, backlog
- [Schedule](docs/schedule.md): Gantt chart and project stages

## Tech Stack

C# (.NET 8), ASP.NET Core Razor Pages, Entity Framework Core, SQLite, ASP.NET Core Identity, Bootstrap

## Running the app

```bash
dotnet run --urls http://0.0.0.0:5000
```

The app will be available at `http://localhost:5000`.
