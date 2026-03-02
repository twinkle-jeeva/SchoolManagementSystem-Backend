School Management System (Backend)

This is the backend of a School Management System built using .NET 10 (ASP.NET Core Web API). The system is designed with real-world architecture in mind, following Repository + Service patterns, DTOs with validation, and ready for full-stack integration.

It includes management for Students, Teachers, Courses, Subjects, Parents, and Emergency Contacts.
🛠️ Technologies Used

.NET 10 / ASP.NET Core Web API

Entity Framework Core (SQL Server)

AutoMapper

Repository & Service Pattern

DTOs with Validation

Swagger (API Documentation & Testing)

JWT Authentication (in progress)

✅ Features

Full CRUD operations for Students, Teachers, Parents, Courses, and Subjects

Emergency Contact Management

Proper Entity Relationships (One-to-Many, Many-to-One)

Partial Updates using PUT with optional fields

Pagination, Filtering, and Sorting on lists

Swagger API Documentation for testing

Ready for JWT Authentication and Role-Based Authorization

🔐 Planned Features

JWT Authentication & Secure Endpoints

Role-Based Access (Admin / Teacher / Student / Parent)

Full-Stack Integration with React + TypeScript frontend

Responsive dashboards

File uploads (Student & Teacher photos)

📁 Project Structure
StudentDemoAPI/
│
├── Controllers/          # API Controllers
├── DTOs/                 # Data Transfer Objects
├── Models/               # Entity Models
├── Repositories/         # Repository Interfaces & Implementations
├── Services/             # Business Logic Services
├── Helpers/              # AutoMapper Profiles
├── appsettings.json      # Configuration
├── Program.cs
└── StudentDemoAPI.csproj

⚡ How to Run Locally

Clone the repository:

git clone https://github.com/twinkle-jeeva/StudentDemoAPI.git
cd StudentDemoAPI

Open in Visual Studio 2022 or VS Code with .NET 10 SDK installed.

Update your appsettings.json with your local SQL Server connection string.

Apply migrations:

dotnet ef database update

Run the project:

dotnet run

Open Swagger UI:

https://localhost:{PORT}/swagger
💻 API Documentation
Swagger is included for testing all endpoints. You can view it by running the project and navigating to /swagger.

👩‍💻 Learning & Growth
This project helped me learn:
Clean Architecture for backend systems
Entity relationships & database design
DTO mapping and validation with AutoMapper
Preparing backend for JWT authentication and secure full-stack integration

DTO mapping and validation with AutoMapper

Preparing backend for JWT authentication and secure full-stack integration
