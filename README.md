# Bookkeeping Admin Panel 

A robust, standalone C# Windows Forms desktop application designed for managing book inventory, processing customer rentals, and tracking store analytics. 

> **Project Status: Standalone Phase (Epics 1-3 Complete)**
> This application currently operates completely offline using local JSON data persistence. Epic 4 (Team Web API Integration) is scheduled next to transition this desktop client into a connected frontend.

## Current Features

* **Inventory Management:** Add new books, track stock quantities (`AvailableCopies` / `TotalCopies`), and prevent duplicate entries.
* **Rental System:** Process book rentals and returns. Enforces a strict 5-book limit per customer and calculates dynamic late fees using a decoupled fee service.
* **Store Analytics Dashboard:** A dedicated dashboard featuring lifetime metrics and a custom GDI+ rendered bar chart of the top 5 most popular books.
* **Dark Mode:** A fully recursive UI toggle that seamlessly transitions all nested controls, data grids, and input fields into a sleek dark theme.
* **Time Simulation Testing:** A built-in developer "Time Machine" toggle that allows QA/Graders to simulate future dates to test the late-fee mathematical logic without waiting for real-time expiration.
* **Responsive UI:** DPI-aware automatic scaling and dynamic anchoring for seamless window resizing.

## Architecture & Tech Stack

* **Framework:** .NET 8.0 / C# 12
* **UI:** Windows Forms (WinForms)
* **Data Storage:** Local JSON serialization (`books.json`, `rentals.json`, `history.json`).
* **Design Patterns:** 
  * Dependency Injection (Constructor Injection)
  * Interface-driven Repositories (`IBookRepository`, `IRentalRepository`)
  * SOLID Principles (Decoupled time and fee calculation services)

## Getting Started

1. Clone this repository.
2. Open `BookkeepingApp.sln` in **Visual Studio 2022**.
3. Press `F5` to build and run the application. 
4. *Note: Mock data (`books.json`, `rentals.json`, `history.json`) is already seeded in the `bin/Debug/...` directory for immediate testing.*

## Roadmap (Next Steps)
- [ ] **Epic 4:** Refactor Repositories to replace local JSON file usage with `HttpClient` calls to the Team's .NET Web API.
- [ ] Move business logic (rental limits, stock checking) out of the UI/Client and onto the backend server.
