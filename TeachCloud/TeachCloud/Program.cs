
//using Microsoft.EntityFrameworkCore;
//using TeachCloud.Core.Repositories;
//using TeachCloud.Core.Service;
//using TeachCloud.Data;
//using TeachCloud.Data.Repositories;
//using TeachCloud.Service;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;

//var builder = WebApplication.CreateBuilder(args);

//// ✅ קונפיגורציית CORS
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll", policy =>
//    {
//        policy.AllowAnyOrigin()
//              .AllowAnyMethod()
//              .AllowAnyHeader();
//    });
//});

//// ✅ שירותי מערכת
//builder.Services.AddControllers();
//builder.Services.AddAutoMapper(typeof(DtoMappingProfile).Assembly);
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//// ✅ Repository & Services Dependency Injection
//builder.Services.AddScoped<IAdminService, AdminService>();
//builder.Services.AddScoped<IAdminRepository, AdminRepository>();

//builder.Services.AddScoped<ICourseService, CourseService>();
//builder.Services.AddScoped<ICourseRepository, CourseRepository>();

//builder.Services.AddScoped<IGroupService, GroupService>();
//builder.Services.AddScoped<IGroupRepository, GroupRepository>();

//builder.Services.AddScoped<ILessonService, LessonService>();
//builder.Services.AddScoped<ILessonRepository, LessonRepository>();

//builder.Services.AddScoped<IFileService, FileService>();
//builder.Services.AddScoped<IFileRepository, FileRepository>();

//builder.Services.AddScoped<IStudentService, StudentService>();
//builder.Services.AddScoped<IStudentRepository, StudentRepository>();

//builder.Services.AddScoped<ITeacherService, TeacherService>();
//builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

//// ✅ מסד נתונים
//builder.Services.AddDbContext<DataContext>(options =>
//    options.UseMySql(
//        builder.Configuration.GetConnectionString("DefaultConnection"),
//        new MySqlServerVersion(new Version(8, 0, 41)),
//        mysqlOptions => mysqlOptions.EnableRetryOnFailure()
//    ));

//// ✅ לוגים
//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();

//var app = builder.Build();

//// ✅ שימוש ב־CORS לפני כל שימוש ב־HTTPS או Routing
//app.UseCors("AllowAll");

//// ✅ הפניה ל־HTTPS
//app.UseHttpsRedirection();

//// ✅ Swagger (בפיתוח)
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseAuthorization();

//app.MapControllers();

//app.Run();


using Microsoft.EntityFrameworkCore;
using TeachCloud.Core.Repositories;
using TeachCloud.Core.Service;
using TeachCloud.Data;
using TeachCloud.Data.Repositories;
using TeachCloud.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ✅ קונפיגורציית CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// ✅ שירותי מערכת
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(DtoMappingProfile).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Repository & Services Dependency Injection
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();

builder.Services.AddScoped<ILessonService, LessonService>();
builder.Services.AddScoped<ILessonRepository, LessonRepository>();

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IFileRepository, FileRepository>();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

// ✅ מסד נתונים
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 41)),
        mysqlOptions => mysqlOptions.EnableRetryOnFailure()
    ));

// ✅ JWT Authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});

// ✅ לוגים
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// ✅ שימוש ב־CORS
app.UseCors("AllowAll");

// ✅ הפניה ל־HTTPS
app.UseHttpsRedirection();

// ✅ שימוש באימות (Authentication) והרשאות (Authorization)
app.UseAuthentication();
app.UseAuthorization();

// ✅ Swagger (רק בפיתוח)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
