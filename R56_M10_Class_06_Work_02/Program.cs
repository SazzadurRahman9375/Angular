using Microsoft.EntityFrameworkCore;
using R56_M10_Class_06_Work_02.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EmployeeDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCors",
                          policy =>
                          {
                              policy.WithOrigins("http://127.0.0.1:5084",
                                                  "http://127.0.0.1:4200", 
                                                  "http://localhost:4200",
                                                  "http://localhost:5084")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});
builder.Services.AddControllers()
    .AddNewtonsoftJson(op =>
    {
        op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
        op.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
    });
var app = builder.Build();

app.UseStaticFiles();
app.UseCors("EnableCors");
app.MapDefaultControllerRoute();
app.Run();
