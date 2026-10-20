# Tabletop Muster — Project Schedule

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
