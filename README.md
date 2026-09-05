# Driving & Vehicle Licensing Department (DVLD)

A desktop management system built using C# .NET Windows Forms and Microsoft SQL Server, implementing a 3-Tier Architecture to streamline the administration of driver licensing, vehicle registrations, driving tests, and user permissions.

---

## Architecture & Engineering Standards

* **3-Tier Architecture:** Strict decoupling between Data Access Layer (`DVLD.Data`), Business Logic Layer (`DVLD.Logic`), and Presentation Layer (`DVLD.UI`).
* **Passive View UI Pattern:** User Controls handle rendering and display logic only, delegating response workflows and notifications to parent forms.
* **Centralized Messaging:** Unified UI messaging via `clUIMessages` to maintain consistent dialogs, confirmations, and alerts throughout the application.
* **Data Integrity & Security:** Parameterized SQL queries to eliminate injection risks, alongside safe disposal patterns for database connections.

---

## Tech Stack

* **Programming Language:** C#
* **Framework:** .NET Windows Forms
* **Database:** Microsoft SQL Server
* **Key Design Patterns:** 3-Tier Layering, Passive View, Helper/Utility Services

---

## Core Modules

* **People Management:** Full CRUD operations, dynamic filtering, image file handling, and national identification tracking.
* **User Management:** Authentication handling, account status toggles, user-person link constraints, and password update workflows.
* **Tests & Applications:** Configuration of test types, fees management, and processing pipelines for driving license applications.
* **Reusable UI Components:** Generic data view controls (`ctrlManageData`), compound search filters, and information cards (`ctrlPersonCard`, `ctrlUserCard`).

---

## Current Status

Active refactoring phase focused on architecture standardization, code cleanup, consistent naming conventions, and decoupling presentation logic.
