# JobTracker API

A production-ready RESTful API built with **ASP.NET Core 8** and **Entity Framework Core**, featuring JWT authentication and full CRUD operations for job application tracking.

## 🚀 Tech Stack

- **Backend:** ASP.NET Core 8 Web API
- **ORM:** Entity Framework Core 9
- **Database:** SQLite (dev) / PostgreSQL (prod)
- **Authentication:** JWT Bearer Tokens + BCrypt
- **Documentation:** Swagger / OpenAPI
- **Language:** C# 12

## ✨ Features

- 🔐 User registration and login with JWT authentication
- 🔒 BCrypt password hashing
- 📋 Full CRUD for job applications (Create, Read, Update, Delete)
- 👤 User-specific data isolation — users only see their own data
- 📄 Swagger UI for API documentation and testing
- 🏗️ Clean architecture with Controllers, Models and DTOs
- 🔄 Code-first database migrations with EF Core

## 📁 Project Structure

JobTrackerAPI/
├── Controllers/
│   ├── AuthController.cs      # Register & Login endpoints
│   └── JobsController.cs      # CRUD endpoints for job applications
├── Models/
│   ├── User.cs                # User entity
│   ├── Job.cs                 # Job application entity
│   └── AppDbContext.cs        # EF Core database context
├── DTOs/
│   └── AuthDtos.cs            # Data transfer objects
├── Program.cs                 # App configuration & middleware
└── appsettings.json           # JWT & database settings

## 🔌 API Endpoints

### Authentication
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/auth/register` | Register a new user |
| POST | `/api/auth/login` | Login and receive JWT token |

### Job Applications (🔒 Requires JWT)
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/jobs` | Get all jobs for authenticated user |
| GET | `/api/jobs/{id}` | Get a specific job |
| POST | `/api/jobs` | Create a new job application |
| PUT | `/api/jobs/{id}` | Update a job application |
| DELETE | `/api/jobs/{id}` | Delete a job application |

## ⚡ Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [Git](https://git-scm.com/)

### Installation

```bash
# Clone the repository
git clone https://github.com/hakkivatansever/JobTrackerAPI.git
cd JobTrackerAPI

# Restore dependencies
dotnet restore

# Apply database migrations
dotnet ef database update

# Run the application
dotnet run
```

### Access Swagger UI
http://localhost:5041/swagger

## 🔐 Authentication Flow

POST /api/auth/register  →  Create account
POST /api/auth/login     →  Receive JWT token
Add token to requests    →  Authorization: Bearer {token}
Access protected routes  →  GET/POST/PUT/DELETE /api/jobs


## 🗄️ Data Models

### User
```json
{
  "id": 1,
  "fullName": "John Doe",
  "email": "john@example.com",
  "createdAt": "2026-04-26T00:00:00Z"
}
```

### Job Application
```json
{
  "id": 1,
  "companyName": "Google",
  "position": ".NET Developer",
  "status": "Interview",
  "appliedDate": "2026-04-26T00:00:00Z",
  "notes": "Had a great first call",
  "userId": 1
}
```

## 🔮 Roadmap

- [ ] PostgreSQL production deployment
- [ ] Email notifications
- [ ] Application statistics endpoint
- [ ] Docker containerisation
- [ ] Azure deployment

## 👨‍💻 Author

**Hakka Halmiev**
- GitHub: [@hakkivatansever](https://github.com/hakkivatansever)
- LinkedIn: [linkedin.com/in/hakkivatansever](https://linkedin.com/in/hakkivatansever)

---

