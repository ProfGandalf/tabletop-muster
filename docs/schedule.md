# Tabletop Muster — harmonogram produkcji

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
    title Tabletop Muster - harmonogram (semestr zimowy 2026/2027)
    dateFormat YYYY-MM-DD
    axisFormat %d.%m
    tickInterval 1week
    todayMarker off

    section 1. Przygotowanie
    T-01 Projekt i README          :t01, 2026-10-20, 7d
    T-02 Baza danych i seed        :t02, after t01, 7d

    section 2. Konta i katalog
    T-03 Logowanie i rejestracja   :t03, after t02, 10d
    T-04 Katalog jednostek         :t04, after t03, 11d

    section 3. Rozpiski (MVP)
    T-05 Tworzenie rozpisek        :active, t05, after t04, 7d
    T-06 Jednostki w rozpisce      :active, t06, after t05, 7d
    T-07 Punkty i limit            :active, t07, after t06, 7d
    T-08 Własne jednostki          :active, t08, after t07, 6d
    MVP gotowe                     :milestone, crit, mvp, 2026-12-21, 0d

    section 4. Rozszerzenia
    T-09 Liczba modeli w oddziale  :t09, 2026-12-22, 9d
    T-10 Kopiowanie i druk         :t10, after t09, 8d

    section 5. Finalizacja
    T-11 Testy i prezentacja       :t11, after t10, 10d
    Oddanie projektu               :milestone, crit, end, 2027-01-18, 0d
```

Jak czytać wykres: niebieskie paski to zwykłe zadania, pomarańczowe to te, bez których nie ma MVP, a czerwone romby oznaczają najważniejsze momenty projektu, czyli gotowe MVP i oddanie.

| Etap | Okres | Zadania | Kamień milowy |
|---|---|---|---|
| 1. Przygotowanie | 20.10 – 02.11.2026 | T-01 – T-02 | Projekt uruchamia się lokalnie |
| 2. Konta i katalog | 03.11 – 23.11.2026 | T-03 – T-04 | Logowanie i katalog jednostek |
| 3. Rozpiski (MVP) | 24.11 – 21.12.2026 | T-05 – T-08 | **MVP gotowe (21.12.2026)** |
| 4. Rozszerzenia | 22.12.2026 – 07.01.2027 | T-09 – T-10 | Pełna wersja |
| 5. Finalizacja | 08.01 – 17.01.2027 | T-11 | **Oddanie projektu (18.01.2027)** |
