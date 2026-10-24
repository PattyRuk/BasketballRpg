# Basketball RPG Engine

A dynamic, fully decoupled C# console simulation that blends team sports management with deep RPG mechanics. This project showcases clean architecture, high maintainability, and strict separation of concerns by utilizing core structural, creational, and behavioral design patterns.

---

## 🏀 Project Overview

The **Basketball Fantasy RPG Engine** allows franchise managers to draft distinct positional archetypes (or a bizarre legacy mascot species), dynamically apply gameplay skill upgrades (Badges) at runtime, manage front-office locker assets, and run possession simulations—all driven through an error-resilient console menu loop.

## 🛠️ Architecture & Design Patterns Applied

### 1. Global Game State (Singleton Pattern)
*   **Implementation:** `LeagueSimulation.cs`
*   **Purpose:** Ensures exactly one instance tracks global tournament details (Game Mode, Current Quarter), providing a single doorway (`LeagueSimulation.Instance`) without passing variables through every method argument.

### 2. Entity Generation (Factory Method & Builder Patterns)
*   **Implementation:** `PlayerFactory.cs` & `PlayerCustomizer.cs`
*   **Purpose:** Isolates object initialization from the client code. The factory handles string routing for positions, while the builder safely handles optional player card metadata (jersey numbers, hometowns) step-by-step.

### 3. Specialization Upgrades (Decorator Pattern)
*   **Implementation:** `BadgeDecorator.cs`, `SniperBadge.cs`, `LockdownBadge.cs`
*   **Purpose:** Avoids massive subclass inheritance chains. Enhancements (Badges) wrap around any active player interface object at runtime, dynamically boosting stats and updating court behavior (`Act()`, `Speak()`) on the fly.

### 4. Inventory Layer Isolation (Facade Pattern)
*   **Implementation:** `LockerRoom.cs`
*   **Purpose:** Packages list operations and filtering out of sight. The client engine requests operations through clean methods, remaining entirely unaware of internal data sorting logic.

### 5. Input Subsystem Facade (Facade Pattern Subsystem)
*   **Implementation:** `RpgInputEngine.cs`
*   **Purpose:** Extracted directly from the controller loop to achieve the Single Responsibility Principle. Centralizes all console writing, text formatting, error handling, and key parsing into a standalone presentation view worker.

### 6. Legacy Integration (Adapter Pattern)
*   **Implementation:** `SplorgAdapter.cs`
*   **Purpose:** Integrates an unmodifiable external class (`Splorg.cs`) safely. It maps unique bubble attributes (`BubbleMatterRemaining`, `BubbleDurability`, `Smarts`) onto the main `Player` interface without changing a single line of the legacy blueprint.

---

## Technical Requirements & Standards

*   **Runtime Framework:** .NET 8.0 Console Application
*   **C# Interface Compliance:** The core domain utilizes an interface architecture for `Player` interactions, forcing standard public structures and dropping heavy `override` requirements.
*   **Error Resilience:** All input menus use defensive parsing (`int.TryParse` and safe string handling) to prevent runtime menu loop crashes.

---

## Getting Started

1. Ensure you have the **.NET 8 SDK** installed.
2. Clone this repository to your local path directory.
3. Open a terminal path pointing to the project folder root and run:
   ```bash
   dotnet run
   ```
4. Use menu options **1-6** to test building, upgrading, stocking items, and running court match possessions.
