# StudySync – A Study Planning Application

**StudySync** is a cross-platform mobile application for study planning that was constructed with **.NET MAUI**.  It assists students in maintaining organization, effectively managing their assignments, monitoring their progress, and accomplishing their academic objectives.  This program was created with simplicity and productivity in mind, specifically for high school and college students who are juggling several classes.
---

## Features

- Add, edit, and delete tasks  
- Organize tasks by course  
- Set and manage weekly and long-term goals  
- Track task progress with visual graphs  
- Get personalized study tips  
- View what’s due today and upcoming tasks  
- Daily motivational quotes  
- Cross-platform support (Android/iOS)

---

## Target Audience

Primarily aimed at:

- University students  
- High school students  

This application is especially beneficial for students managing multiple courses and deadlines, helping them stay on top of their academic responsibilities.

---

## Screenshots

> *(Screenshots are below for example what it's going to looklike)*


<img width="2138" height="1118" alt="image" src="https://github.com/user-attachments/assets/26e19907-4712-4ffe-8959-ea710e5944f4" />

<img width="2136" height="1108" alt="image" src="https://github.com/user-attachments/assets/35f4361c-a2a5-4a47-b628-e55f8f98c168" />

<img width="2134" height="1118" alt="image" src="https://github.com/user-attachments/assets/debb6e28-a82a-4220-a068-508323045c1b" />

## How to Use the App

- **Launch the app** – View today's tasks, upcoming deadlines, and a motivational quote.
- **Add a Task** – Use the `+` button to add a new task with course and due date.
- **Manage Tasks** – Tap on a task to edit, mark as complete, or delete it.
- **Track Progress** – Navigate to the **Progress** page to view completion stats via interactive charts.
- **Set Goals**
  - **Weekly Goal** – Define short-term goals for the week.
  - **Major Milestone** – Use the calendar to create long-term academic goals.

---

## Tech Stack & NuGet Packages

- **.NET MAUI** – Multi-platform App UI framework  
- **C#**, **XAML**, **MVVM architecture**
- **SQLite** – Local persistent data storage
- **ObservableCollection** – Reactive task list handling
- **Microcharts** – Chart and graph visualization
- **CommunityToolkit.MVVM** – MVVM enhancements  
- **CommunityToolkit.Maui** – UI helpers and extensions

---

## Team Members

| Name             | Role                              |
|------------------|-----------------------------------|
| **Shamak Patel** | UI Designer & Frontend Developer  |
| **Silas Curry**  | Backend Integration & Developer   |
| **Dharmin Patel**| Developer & Documentation         |

---

## Task Responsibilities

### Shamak Patel
- UI design using .NET MAUI
- Built the Homepage and Goals page
- Implemented navigation structure
- Created task list with CollectionView
- Integrated SQLite for data storage

### Silas Curry
- Developed task scheduling logic
- Built Checklist page and task model
- Implemented MVVM structure and logic validation
- Designed Progress tracking system

### Dharmin Patel
- Managed GitHub repo, pull requests, and documentation
- Assisted with ViewModel logic and task modeling
- Created Progress page and wired up navigation
- Integrated Microcharts for visual feedback

---

## Installation & Run (Dev Setup)

1. Clone the repository:
   
    `git clone https://github.com/yourusername/StudySync.git`
   
3. Open the solution in Visual Studio 2022 or later with the .NET MAUI workload installed.

4. Build and deploy the app on an Android/iOS emulator or physical device.

