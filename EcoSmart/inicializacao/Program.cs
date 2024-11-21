using EcoSmart.Persistencia;
using EcoSmart.Repository;
using EcoSmart.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers(); // 添加控制器支持
builder.Services.AddEndpointsApiExplorer(); // 启用终端点 API 探索
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
    // 确保 appsettings.json 中包含正确的 Google 客户端 ID 和密钥
    options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // 启用 Swagger 文档和 UI 在开发环境中
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EcoSmart API v1"));
}

app.UseHttpsRedirection(); // 强制使用 HTTPS
app.UseAuthentication(); // 启用身份验证中间件
app.UseAuthorization(); // 启用授权中间件

app.MapControllers(); // 映射控制器路由

app.Run(); // 运行应用程序
