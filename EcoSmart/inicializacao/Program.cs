using EcoSmart.Persistencia;
using EcoSmart.Repository;
using EcoSmart.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers(); // 添加控制器
builder.Services.AddEndpointsApiExplorer(); // 启用终端点探索
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "EcoSmart API",
        Version = "v1",
        Description = "API for managing sustainable energy processes"
    });
}); // 添加 Swagger 文档支持

// Database configuration
builder.Services.AddDbContext<EcoSmartDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleFIAP"))); // 替换为正确的数据库连接字符串

// Dependency Injection for repository and service layers
builder.Services.AddScoped<IEnergyRecordRepository, EnergyRecordRepository>();
builder.Services.AddScoped<IEnergyRecordService, EnergyRecordService>();

// Add Google Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
}).AddGoogle(options =>
{
    options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EcoSmart API v1"));
}

app.UseHttpsRedirection();
app.UseAuthentication(); // 添加身份验证中间件
app.UseAuthorization();

app.MapControllers();

app.Run();
