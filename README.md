# 📚 SmartLibrary Management System

A Library Management System built using **ASP.NET Core Web API** and **Entity Framework Core**.

SmartLibrary provides functionality to manage books, authors, categories, and library borrowing operations. Users can borrow available books and return borrowed books.

## 🚀 Features

### 📖 Book Management
- Add, update, delete, and retrieve books.
- View book details by ID.
- Track available book copies.

### ✍️ Author Management
- Manage book authors.
- Associate authors with books.

### 📂 Category Management
- Manage book categories.
- Organize books by category.

### 🔄 Borrowing Management
- Borrow available books.
- Prevent users from borrowing the same book multiple times simultaneously.
- Track borrowing dates and due dates.
- Return borrowed books.
- Update available book copies automatically.

### 🔐 Authentication and Authorization
- User authentication.
- Current logged-in user identification.
- Protected borrowing operations.

### ⚠️ Global Exception Handling
- Centralized exception handling using custom middleware.
- User-friendly error responses.

## 🛠️ Technologies Used

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- LINQ
- JWT Authentication
- Repository Pattern
- Service Layer Architecture
- DTOs (Data Transfer Objects)
- Git and GitHub

## 🏗️ Project Architecture

The project follows a layered architecture:

- **Controllers** – Handle HTTP requests.
- **Services** – Implement business logic.
- **Repositories** – Handle database operations.
- **Models** – Define application entities.
- **DTOs** – Transfer data between application layers.
- **Data** – Contains database context.
- **Middleware** – Handles global exceptions.

## ⚙️ Installation and Setup

### 1. Clone the Repository

```bash
git clone https://github.com/YOUR_USERNAME/SmartLibrary.git
```

### 2. Open the Project

Open `SmartLibrary.slnx` using Visual Studio.

### 3. Restore Dependencies

```bash
dotnet restore
```

### 4. Configure Database Connection

Create your own `appsettings.json` file in the ASP.NET Core project directory.

Use `appsettings.example.json` as a reference and configure your SQL Server connection string.

### 5. Configure JWT Settings

Configure your JWT settings and secret key in `appsettings.json`, if required.

Never upload real credentials or secret keys to GitHub.

### 6. Apply Database Migrations

```bash
dotnet ef database update
```

### 7. Run the Application

```bash
dotnet run
```

## 🧪 API Testing

You can test the API endpoints using:

- Postman
- Swagger UI (if enabled)

## 👨‍💻 Author

**Your Name**

GitHub: https://github.com/YOUR_USERNAME

---

