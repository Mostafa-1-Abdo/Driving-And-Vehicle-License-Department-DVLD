# Driving & Vehicle Licensing Department (DVLD)

A desktop management system built using C# .NET Windows Forms and Microsoft SQL Server, implementing a 3-Tier Architecture to streamline the administration of driver licensing, vehicle registrations, driving tests, and user permissions.

---

## Architecture & Engineering Standards

* **3-Tier Architecture:** Strict decoupling between Data Access Layer (`DVLD.Data`), Business Logic Layer (`DVLD.Logic`), and Presentation Layer (`DVLD.UI`).
* **Passive View UI Pattern:** User Controls handle rendering and display logic only, delegating response workflows and notifications to parent forms.
* **Domain Modeling Principles:**
  * **Composition for Roles:** Clear separation between core identity (`clPerson`) and system accounts (`clUser`).
  * **Inheritance for Specialization:** Clean Table-Per-Type (TPT) inheritance for application pipelines (`clLocalDrivingLicenseApplication` inheriting from `clApplication`).
* **Centralized Messaging:** Unified UI messaging via `clUIMessages` to maintain consistent dialogs, confirmations, and alerts throughout the application.
* **Data Integrity & Security:** Parameterized SQL queries to eliminate injection risks, alongside safe disposal patterns for database connections.

---

## Tech Stack

* **Programming Language:** C#
* **Framework:** .NET Windows Forms
* **Database:** Microsoft SQL Server
* **Key Design Patterns & OOP:** 3-Tier Layering, Passive View, Composition over Inheritance, Object Specialization

---

## Core Modules & Progress

* [x] **People Management:** Full CRUD operations, dynamic filtering, image file handling, and national identification tracking.
* [x] **User Management:** Authentication handling, account status toggles, composition-based person linking, and password update workflows.
* [x] **License Classes:** Lookup configuration, validity length constraints, and direct data-binding models.
* [ ] **Applications Pipeline (In Progress):**
  * [ ] Base `Application` core (DAL, BLL, lifecycle, fee handling, and status transitions).
  * [ ] `LocalDrivingLicenseApplications` specialization and business validations.
* [ ] **Tests & Appointments:** Management of vision, written, and practical driving test appointments and results.
* [ ] **Drivers & Licenses:** Driver record creation, international and local license issuance, renewals, and replacements.

---

## Current Status

Implementing the core `Applications` engine with TPT-based inheritance, establishing business lifecycle rules, and connecting base application workflows with localized driving license requests.
