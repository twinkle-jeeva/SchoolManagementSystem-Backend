using Microsoft.EntityFrameworkCore;
using StudentDemoAPI.Data;
using StudentDemoAPI.Repositories;
using StudentDemoAPI.Repositories.Interfaces;
using StudentDemoAPI.Services;
using StudentDemoAPI.Services.Interfaces;

using StudentDemoAPI.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//  Configure Database (reads from appsettings.json)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
        
    //  Register Repositories & Services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
//builder.Services.AddScoped<TeacherService>();

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ISubjectService, SubjectService>();


//builder.Services.AddScoped<AuthService>();  // JWT token generation service

// Add Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add Authorization
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();  // Read & validate JWT token
app.UseAuthorization();   // Check [Authorize] attributes

app.MapControllers();

app.Run();
