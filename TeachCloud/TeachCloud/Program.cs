using TeachCloud.Core.Repositories;
using TeachCloud.Core.Service;
using TeachCloud.Data;
using TeachCloud.Data.Repositories;
using TeachCloud.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DataContext>();//זה צריך להישאר רק לבנתיים אחר כך צריך למחוק ולשנות!!
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAdminService,AdminService>();
builder.Services.AddScoped<IAdminRepository,AdminRepository>();

builder.Services.AddScoped<ICourseService,CourseService>();
builder.Services.AddScoped<ICourseRepository,CourseRepository>();


builder.Services.AddSingleton<DataContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
