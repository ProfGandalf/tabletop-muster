# Tabletop Muster

Aplikacja przeglądarkowa do tworzenia rozpisek armii do bitewnych gier figurkowych, inspirowana grą Warhammer 40,000. Pozwala budować armie z dostępnych jednostek, automatycznie liczy punkty, pilnuje ich limitu i umożliwia dodawanie własnych jednostek.

Projekt realizowany w ramach przedmiotu **Zespołowe Tworzenie Projektów IT** (Politechnika Opolska, semestr zimowy 2026/2027).

**Zespół:** Marcin Dziony, Przemysław Kowal

## Dokumentacja

- [Specyfikacja projektu](docs/project-specification.md): wizja, propozycja wartości, wymagania, user stories, MVP, backlog
- [Harmonogram](docs/schedule.md): wykres Gantta i etapy prac

## Technologie

C# (.NET 8), ASP.NET Core Razor Pages, Entity Framework Core, SQLite, ASP.NET Core Identity, Bootstrap

## Uruchomienie

```bash
dotnet run --urls http://0.0.0.0:5000
```

Aplikacja będzie dostępna pod adresem `http://localhost:5000`.
