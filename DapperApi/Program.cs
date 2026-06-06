using DapperApi.Repositories;
// using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Tạm thời tắt chuyển hướng HTTPS để chạy local mượt mà
// app.UseHttpsRedirection();
// Kích hoạt các Controller (StudentController)
app.MapControllers();

app.Run();
