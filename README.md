# 🌍 ASP.NET Project - BucketListTravel

> A travel catalog and personal bucket list: browse destinations, save the ones you want to visit and track your plans.

![.NET Version](https://img.shields.io/badge/.NET-8.0-purple)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-8.0-blue)
![SQL Server](https://img.shields.io/badge/SQL_Server-Express-red)

---

## 📋 Table of Contents

- [About the Project](#-about-the-project)
- [Technologies Used](#-technologies-used)
- [Prerequisites](#-prerequisites)
- [Getting Started](#-getting-started)
- [Project Structure](#-project-structure)
- [Features](#-features)
- [Usage](#-usage)
- [Database Setup](#-database-setup)
- [Configuration](#-configuration)
- [Known Limitations](#-known-limitations)
- [Contact](#-contact)

---

## 📖 About the Project

BucketListTravel is an ASP.NET Core MVC web application for people who collect travel dreams. It offers a catalog of destinations grouped by category, a page with the details of each place, and a personal bucket list where every saved destination gets a status (want to visit, planned or visited), an optional planned date and notes. Every user has their own private bucket list, and the catalog can be extended by registered users: anyone can add destinations, but each user can edit and delete only the destinations they created.

The project was built as part of the *ASP.NET Fundamentals* course. It demonstrates MVC architecture, Entity Framework Core with SQL Server, dependency injection, a service layer, validation and Razor layouts, partial views and sections.

---

## 🛠️ Technologies Used

| Technology                | Version | Purpose                                      |
|---------------------------|---------|----------------------------------------------|
| ASP.NET Core MVC          | 8.0     | Web framework                                |
| Entity Framework Core     | 8.0     | ORM / database access (Code First)           |
| SQL Server (Express)      | -       | Database                                     |
| ASP.NET Core Identity     | 8.0     | Registration, login, per-user data ownership |
| Bootstrap                 | 5.3     | Responsive frontend styling                  |
| jQuery Validation         | -       | Client-side form validation                  |
| Razor Views               | -       | Server-side HTML (layout, partials, sections)|

---

## ✅ Prerequisites

Make sure you have the following installed before running the project:

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Git](https://git-scm.com/)
- [Visual Studio 2022/2026](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/) (optional, you can also run from the terminal)

---

## 🚀 Getting Started

Follow these steps to get the project running locally.

### 1. Clone the repository

```bash
git clone https://github.com/kristiqnc2104/ASP.NET-Project---BucketListTravel.git
cd ASP.NET-Project---BucketListTravel
```

### 2. Restore dependencies

```bash
dotnet restore BucketListTravel.csproj
```

### 3. Check the connection string

By default the app connects to the local `.\SQLEXPRESS` instance with Windows authentication.

### 4. Run the application

```bash
dotnet run --project BucketListTravel.csproj
```

The database, its tables and the starter catalog are created automatically on the first start, so there is no need to apply migrations manually. The console prints the address of the app (with the default launch profile it is `https://localhost:7021`).

> Running from Visual Studio works the same way: open the project and press **F5**.

---

## 📁 Project Structure

```
ASP.NET-Project---BucketListTravel/
│
├── Areas/Identity/       # Scaffolded Login and Register pages
├── Common/               # Shared enums and validation / UI constants
├── Controllers/          # MVC controllers (Home, Destination, BucketList)
├── Data/
│   ├── Models/           # Entities: Category, Destination, BucketListEntry
│   ├── Configurations/   # EF Core entity configuration and catalog seed data
│   └── BucketListTravelDbContext.cs
├── Migrations/           # EF Core migrations
├── Services/
│   ├── Interfaces/       # IDestinationService, IBucketListService
│   └── DTOs/             # Data passed between services and controllers
├── ViewModels/           # Models for views and forms (with validation attributes)
├── Views/                # Razor views, layout and partial views
├── wwwroot/              # Static files (CSS, JS, libraries)
├── appsettings.json      # App configuration
└── Program.cs            # App entry point, dependency injection and middleware
```

**Architecture in short:**

- Controllers stay thin: they call a service and choose a view.
- Services are registered through interfaces (dependency injection) and are the only place that talks to the database.
- Entities never leave the service layer. Services return DTOs, and controllers map them to view models for the views.
- Validation lives in the view models, so the same rules run on the server and, through jQuery Validation, in the browser.

---

## ✨ Features

- [x] Destination catalog with categories and a details page
- [x] Full CRUD for destinations: create, edit, details and delete (several of your own destinations at once from the **Manage** page)
- [x] Personal bucket list per user: add a destination from the catalog or its details page and remove it again (each user sees only their own list)
- [x] Ownership rules: registered users can create destinations and edit or delete only the ones they created
- [x] Update a bucket list entry: status (Want to visit / Planned / Visited), planned date and notes
- [x] Protection against adding the same destination  twice to the same bucket list
- [x] Input validation (server-side and client-side), including a rule that a planned date is required and cannot be in the past when the status is *Planned*
- [x] User registration and login (ASP.NET Core Identity)
- [x] Responsive UI with Bootstrap, custom CSS, shared layout, partial views and sections

---

## 💻 Usage

```
1. Open the Home page and choose "Explore destinations" or "Find your destination" (or use the Destinations link in the menu).
2. Browse the catalog and open "Details" for any destination.
3. Register or log in, then click "Add to list" to save a destination. The button turns into "Remove from list" once it is saved.
4. Open "My Bucket List" or "View my bucket list" to see your saved destinations and use "Edit" to set the status, planned date and notes.
5. Use "Manage Destinations" (button on the Destinations page) to add destinations and to edit or delete the ones you created.
> **Note:** the starter catalog destinations have no owner, so they cannot be edited or deleted. Browsing the catalog works without an account, but saving to a bucket list and managing destinations require login.
```

> **Registering:** go to `/Identity/Account/Register`, enter a username, an email and a password with at least 6 characters, an uppercase letter, a lowercase letter and a digit (for example `Test123`). Email confirmation is not required, so you are signed in right after registering.

---

## 🗄️ Database Setup

The project uses **Entity Framework Core** with a Code First approach and SQL Server.

The data model:

```
Category 1:N Destination
Destination 1:N BucketListEntry
User(owner) 1:N Destination
User 1:N BucketListEntry
```

- `Category`: a destination type (for example beaches, cities, nature).
- `Destination`: a place in the catalog with name, country, description, image URL, category and an optional owner (the user who created it; starter destinations have none that's why it's optional).
- `BucketListEntry`: a saved destination belonging to one user, with status, planned date, notes and the date it was added. A user can save a destination only once (unique per user and destination).

Migrations are applied automatically when the application starts (`Database.Migrate()` in `Program.cs`). The same step creates the database `BucketListTravel` and fills it with the categories and the starter destinations (`CatalogSeedConfiguration`).

To start again from a clean database, delete the `BucketListTravel` database (for example from SQL Server Management Studio) and run the app again.

If you prefer to apply the migrations by hand, install the EF Core tool once and run:

```bash
dotnet tool install --global dotnet-ef
dotnet ef database update --project BucketListTravel.csproj
```

---

## ⚙️ Configuration

The project needs no passwords, API keys or environment variables. The only setting is the database connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.\\SQLEXPRESS;Database=BucketListTravel;Trusted_Connection=true;Encrypt=False"
}
```

---

## 🚧 Known Limitations

- The *Planned* date rule is checked only on the server (the other validation rules also run in the browser).
- An entry with the status *Planned* whose date has already passed cannot be saved until its date or status is changed, even if only the notes are edited.
- The catalog list has no pagination.
- Destination images are referenced by URL, so they need an internet connection to be displayed.
- There is no admin role yet, so starter destinations can't be changed from the app.

Ideas for the *ASP.NET Advanced* module: new entity Reviews and needed controller and actions for it, pagination, roles (an admin who can manage all destinations), a REST API and image upload.

---

## 📬 Contact

**Kristiyan** – [@kristiqnc2104](https://github.com/kristiqnc2104)

Project Link: [https://github.com/kristiqnc2104/ASP.NET-Project---BucketListTravel](https://github.com/kristiqnc2104/ASP.NET-Project---BucketListTravel)

---

*Built as part of the **ASP.NET Fundamentals** course.*