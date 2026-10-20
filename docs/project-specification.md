# Tabletop Muster — Project Specification

**Course:** Zespołowe Tworzenie Projektów IT (Team IT Project Development)
**Team:** Marcin Dziony, Przemysław Kowal
**Repository:** [ProfGandalf/tabletop-muster](https://github.com/ProfGandalf/tabletop-muster)
**Document version:** 0.5

---

## 1. Product Vision

**Tabletop Muster** is a browser-based web application for building army lists for tabletop miniature wargames, inspired by Warhammer 40,000. Players assemble an army from the available units, the application keeps a running points total and enforces the points limit, and players can add their own custom units.

**Problem:** players build their armies in spreadsheets or on paper. Counting points by hand leads to mistakes, and official apps don't let players add their own units.

**Vision statement:**
> For tabletop wargame players who want to build armies quickly and without mistakes, Tabletop Muster is a simple army list builder that calculates points automatically and lets you create your own units.

## 2. Value Proposition

| Who | Problem | What we offer |
|---|---|---|
| New player | Makes mistakes counting points | Automatic point calculation and a warning when the limit is exceeded |
| Experienced player | Has many army lists | Saving and copying army lists in one place |
| Homebrew creator | No tool for custom units | A custom unit form; custom units work in army lists like any other unit |

**Unique Value Proposition (UVP):** a simple, free army builder that lets you add your own units.

## 3. Business Requirements

- **BR-01** Reduce the time needed to build a 2000-point army list to under 10 minutes.
- **BR-02** Eliminate point calculation errors.
- **BR-03** Allow users to add their own units.
- **BR-04** Run as a website in the browser, with nothing for the user to install.
- **BR-05** Zero cost: the application is hosted on the team's own computer, for demonstration purposes only.

## 4. User Stories

Format: *As a [role], I want [goal], so that [benefit].* Priorities: **M** = Must (MVP), **S** = Should, **C** = Could.

| ID | User story | Priority |
|---|---|---|
| US-01 | As a guest, I want to create an account so that I can save my army lists. | M |
| US-02 | As a user, I want to log in so that I can access my data. | M |
| US-03 | As a user, I want to browse factions and their units so that I know what I can build an army from. | M |
| US-04 | As a user, I want to create an army list with a chosen faction and points limit so that I can start building an army. | M |
| US-05 | As a user, I want to add units to and remove units from an army list so that I can compose my army. | M |
| US-06 | As a user, I want the points total to be calculated automatically so that I don't have to count by hand. | M |
| US-07 | As a user, I want to be warned when I exceed the points limit so that my army list is legal. | M |
| US-08 | As a user, I want to add a custom unit so that I can play with units outside the catalog. | M |
| US-09 | As a user, I want to save army lists and come back to them so that I don't lose my work. | M |
| US-10 | As a user, I want to set the number of models in a squad so that the army list matches my miniatures. | S |
| US-11 | As a user, I want to copy an army list so that I can quickly test variants. | S |
| US-12 | As a user, I want to print an army list so that I can take it to a game. | S |
| US-13 | As a user, I want to search units by name so that I can find them faster. | C |

### Acceptance Criteria (key stories)

**US-06 — automatic point calculation**
- When a unit is added, the total increases by its cost.
- When a unit is removed, the total decreases by its cost.

**US-07 — points limit warning**
- When the total exceeds the limit, a message shows how many points over the limit the list is.

**US-08 — custom unit**
- The form requires a name, a faction and a points cost.
- A saved unit is available when adding units to army lists of that faction.

## 5. MVP (Minimum Viable Product)

The MVP is the smallest version of the application that already solves the main problem: it lets users build an army list with automatic point calculation and custom units.

**In the MVP:** US-01 – US-09 (priority **M**)
**Outside the MVP:** US-10 – US-13

**The MVP is done when:**
- a user can create an account and log in,
- a user can build and save an army list, and points are calculated correctly,
- exceeding the points limit is signalled,
- a user can add a custom unit and use it in an army list.

## 6. Backlog

| ID | Task | User story | Stage |
|---|---|---|---|
| T-01 | Set up the ASP.NET Core Razor Pages project, folder structure, README with run instructions | — | 1 |
| T-02 | EF Core models, SQLite database migrations + seed data (a few factions and units) | — | 1 |
| T-03 | Registration, login and logout (ASP.NET Core Identity) | US-01, US-02 | 2 |
| T-04 | Faction and unit catalog page | US-03 | 2 |
| T-05 | Creating an army list and a "my army lists" page | US-04, US-09 | 3 |
| T-06 | Adding and removing units in an army list | US-05 | 3 |
| T-07 | Point calculation and points limit warning | US-06, US-07 | 3 |
| T-08 | Custom unit form | US-08 | 3 |
| T-09 | Number of models in a squad | US-10 | 4 |
| T-10 | Copying an army list and print view | US-11, US-12 | 4 |
| T-11 | Manual testing, fixes, documentation, presentation | — | 5 |

## 7. Non-Functional Requirements

- **NFR-01 Usability:** the interface is easy to read on desktop and mobile (ready-made CSS framework).
- **NFR-02 Security:** passwords are stored as hashes, and users can only see their own army lists.
- **NFR-03 Easy startup:** the server starts with a single command (`dotnet run --urls http://0.0.0.0:5000`).
- **NFR-04 Version control:** the code is kept in a Git repository on GitHub.
- **NFR-05 Compatibility:** the website works in current versions of Chrome, Firefox and Edge.

## 8. Tech Stack

| Layer | Technology | Purpose |
|---|---|---|
| Language | C# (.NET 8) | One language for all application logic |
| Framework | ASP.NET Core Razor Pages | Server-side rendered HTML pages, no separate frontend |
| Views | Razor (`.cshtml`): HTML with embedded C# | Displaying data and forms |
| Styling | Bootstrap (included in the project template) | Clean look without writing CSS |
| Scripts | JavaScript (optional) | Small UI improvements, e.g. delete confirmation |
| Database | SQLite + Entity Framework Core | Single-file database, accessed through C# classes instead of raw SQL |
| Authentication | ASP.NET Core Identity | Built-in registration, login and password hashing |
| Project management | GitHub (Issues, Projects, Milestones, Pull Requests) | All project management in one place |
| Hosting | Personal Linux Server (Cloudflare, Nginx) |

## 9. Data Model

- **User**: id, name, password hash
- **Faction**: id, name
- **Unit**: id, faction, name, cost, stats (text), author (empty = base unit)
- **ArmyList**: id, user, faction, name, points limit
- **ArmyListEntry**: id, army list, unit, number of models

## 10. Project Schedule

```mermaid
%%{init: {
  "theme": "base",
  "themeCSS": ".grid .tick line { stroke: #dee2e6; } .grid path { stroke-width: 0; }",
  "themeVariables": {
    "fontFamily": "Segoe UI, Helvetica, Arial, sans-serif",
    "fontSize": "14px",
    "sectionBkgColor": "#eef2f7",
    "altSectionBkgColor": "#ffffff",
    "sectionBkgColor2": "#eef2f7",
    "taskBkgColor": "#4c6ef5",
    "taskBorderColor": "#364fc7",
    "taskTextColor": "#ffffff",
    "taskTextLightColor": "#ffffff",
    "taskTextOutsideColor": "#212529",
    "taskTextDarkColor": "#212529",
    "activeTaskBkgColor": "#f59f00",
    "activeTaskBorderColor": "#e67700",
    "critBkgColor": "#e03131",
    "critBorderColor": "#c92a2a",
    "gridColor": "#ced4da",
    "lineColor": "#ced4da",
    "titleColor": "#212529"
  },
  "gantt": {
    "barHeight": 26,
    "barGap": 8,
    "topPadding": 60,
    "leftPadding": 170,
    "gridLineStartPadding": 40,
    "fontSize": 13,
    "sectionFontSize": 14,
    "numberSectionStyles": 2
  }
}}%%
gantt
    title Tabletop Muster - schedule (winter semester 2026/2027)
    dateFormat YYYY-MM-DD
    axisFormat %b %d
    tickInterval 1week
    todayMarker off

    section 1. Setup
    T-01 Project and README        :t01, 2026-10-20, 7d
    T-02 Database and seed         :t02, after t01, 7d

    section 2. Accounts and catalog
    T-03 Login and registration    :t03, after t02, 10d
    T-04 Unit catalog              :t04, after t03, 11d

    section 3. Army lists (MVP)
    T-05 Creating army lists       :active, t05, after t04, 7d
    T-06 Units in army list        :active, t06, after t05, 7d
    T-07 Points and limit          :active, t07, after t06, 7d
    T-08 Custom units              :active, t08, after t07, 6d
    MVP ready                      :milestone, crit, mvp, 2026-12-21, 0d

    section 4. Extensions
    T-09 Squad size                :t09, 2026-12-22, 9d
    T-10 Copy and print            :t10, after t09, 8d

    section 5. Finalization
    T-11 Testing and presentation  :t11, after t10, 10d
    Project submission             :milestone, crit, end, 2027-01-18, 0d
```

How to read the chart: blue bars are regular tasks, orange bars are the tasks the MVP depends on, and red diamonds mark the key moments of the project: MVP ready and final submission.

| Stage | Period | Tasks | Milestone |
|---|---|---|---|
| 1. Setup | Oct 20 – Nov 2, 2026 | T-01 – T-02 | Project runs locally |
| 2. Accounts and catalog | Nov 3 – Nov 23, 2026 | T-03 – T-04 | Login and unit catalog |
| 3. Army lists (MVP) | Nov 24 – Dec 21, 2026 | T-05 – T-08 | **MVP ready (Dec 21, 2026)** |
| 4. Extensions | Dec 22, 2026 – Jan 7, 2027 | T-09 – T-10 | Full version |
| 5. Finalization | Jan 8 – Jan 17, 2027 | T-11 | **Project submission (Jan 18, 2027)** |
