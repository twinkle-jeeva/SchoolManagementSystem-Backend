School Management System (Backend)

This is the backend of a School Management System built using .NET 8 (ASP.NET Core Web API).
The project is designed using real-world backend architecture with Repository + Service patterns, DTO validation, and secure JWT authentication.

It supports full management of Students, Teachers, Courses, Subjects, Parents, and Emergency Contacts.

🛠️ Technologies Used
.NET 8 / ASP.NET Core Web API
Entity Framework Core (SQL Server)
AutoMapper
Repository & Service Pattern
DTOs with Validation
Swagger (API Documentation & Testing)
JWT Authentication
Custom Middleware
🚀 Features
👨‍🎓 Core Modules
Full CRUD operations for Students, Teachers, Parents, Courses, Subjects
Emergency Contact Management
Proper Entity Relationships (One-to-Many, Many-to-One)
⚡ Advanced API Features
Pagination for large datasets
Sorting and Filtering support
Optimized API responses
Clean and scalable architecture
🔐 Security Features
JWT Authentication implemented
Role-based Authorization (Admin / Teacher / Student / Parent)
Custom JWT middleware for request validation
Protected API endpoints using Bearer Token
📘 API Documentation
Swagger UI enabled for testing all endpoints
🔐 Authentication

After successful login, use the JWT token in API requests:

Authorization: Bearer <your_token>
📁 Project Structure
StudentDemoAPI/
│
├── Controllers/        # API Controllers
├── DTOs/               # Data Transfer Objects
├── Models/             # Entity Models
├── Repositories/       # Repository Layer
├── Services/           # Business Logic Layer
├── Middleware/         # Custom JWT Middleware
├── Helpers/            # AutoMapper Profiles, Extensions
├── Migrations/         # EF Core Migrations
├── appsettings.json    # Configuration
├── Program.cs          # Application Startup
└── StudentDemoAPI.csproj
⚙️ How to Run Locally
1. Clone Repository
git clone https://github.com/twinkle-jeeva/StudentDemoAPI.git
cd StudentDemoAPI
2. Open Project

Use Visual Studio 2022 or VS Code

Make sure .NET 8 SDK is installed.

3. Configure Database

Update appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Your-SQL-Server-Connection-String"
}
4. Run Migrations
dotnet ef database update
5. Run Application
dotnet run
💻 API Documentation

Swagger UI is available at:

https://localhost:{PORT}/swagger
📊 Project Highlights
Clean Architecture (Controller → Service → Repository)
Scalable backend design
Secure authentication system
Efficient data handling with pagination & sorting
Production-ready API structure
📈 Learning Outcomes

This project helped in mastering:

ASP.NET Core Web API development
JWT authentication & middleware
Entity Framework Core relationships
DTO design and validation
Scalable backend architecture
👩‍💻 Author

Twinkle Joy

📄 License

This project is for educational and portfolio purposes.