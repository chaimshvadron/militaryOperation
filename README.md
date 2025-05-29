
# militaryOperation

## Overview
**militaryOperation** is a modular C#/.NET 9.0 simulation system for managing and executing military operations. The project simulates real-world military workflows, including intelligence gathering, force management, command and control, and attack execution. It features an interactive console menu for simulating operational decisions and is ideal for educational, research, or demonstration purposes.

---

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Project Structure](#project-structure)
- [Installation & Running](#installation--running)
- [Usage Example](#usage-example)
- [Technologies](#technologies)
- [Authors](#authors)
- [Notes & Future Work](#notes--future-work)

---

## Features
- **Intelligence Module (Aman):** Collects and analyzes intelligence on hostile organizations and terrorists, prioritizing threats based on available data and danger level.
- **Database Simulation:** In-memory storage for terrorists, organizations, and intelligence reports, supporting dynamic updates during simulation.
- **Force Management:** Models military assets (artillery, drones, fighter jets) with ammunition and fuel tracking, and assigns them to organizations.
- **Command and Control:** Central logic for analyzing intelligence, prioritizing targets, and managing operational status.
- **Attack Management:** Selects appropriate assets and executes simulated strikes on targets, updating the system state accordingly.
- **Interactive Console Menu:** Allows users to perform intelligence analysis, check attack availability, prioritize targets, execute attacks, and review the operational database.
- **Extensible Structure:** The codebase is organized for easy expansion, allowing new modules, assets, or intelligence types to be added with minimal effort.

---

## Main Features
- **Intelligence Gathering:** Simulates the collection and analysis of intelligence data on hostile organizations and terrorists.
- **Force Management:** Models military assets such as artillery, drones, and fighter jets, including their ammunition and fuel management.
- **Command and Control:** Central system for managing operations, prioritizing targets, and executing attacks.
- **Attack Management:** Handles the logic for selecting appropriate assets and executing strikes on targets based on intelligence.
- **Interactive Menu:** Console-based user interface for running intelligence analysis, checking attack availability, prioritizing targets, executing attacks, and viewing the database.
- **Database Simulation:** In-memory storage of terrorists, organizations, and intelligence reports.
- **Extensible Structure:** Modular codebase allows for easy addition of new features, assets, or intelligence types.

## Project Structure
```
militaryOperation/
│
├── Amen/                # Intelligence module (Aman, IntelInformation)
├── Database/            # In-memory database management
├── Idf/                 # IDF assets: forces, attack systems, drones, fighter jets, artillery
├── Initialization/      # System initialization and data generation
├── Menu/                # Menus, printing, and user interface
├── modul/               # Organizations and terrorists (Organization, Terrorist)
├── Attack_Management.cs # Attack management logic
├── Control_system.cs    # Command and control system
├── Http.cs              # HTTP communication (future use)
├── Program.cs           # Main entry point
└── militaryOperation.csproj
```

## Installation & Running
1. Make sure you have .NET 9.0 installed on your machine.
2. Open a terminal in the project directory.
3. Run the project:
   ```powershell
   dotnet run --project militaryOperation/militaryOperation.csproj <API_KEY>
   ```
   (You must provide an API key as a command-line argument for demonstration purposes.)

## Example Usage
After running the program, you will see a main menu with the following options:
- Intelligence Analysis
- Attack Availability
- Target Prioritization
- Attack Execution
- Status Database
- Exit

Each option allows you to interact with the simulation, analyze intelligence, manage forces, and execute simulated attacks.

## Technologies
- C#
- .NET 9.0

## Authors
- [Insert your name or contributors here]

## Notes
- The system is designed to be easily extended with new modules and features.
- Future improvements: graphical interface, integration with external systems, enhanced security, and more realistic simulation logic.
