using Microsoft.EntityFrameworkCore;
using ProjectApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AddTaskAPIDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AddtaskApiConnectionString")));
builder.Services.AddDbContext<ProjectsAPIDbcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AddprojectApiConnectionString")));
builder.Services.AddDbContext<UserAPIDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AdduserApiConnectionString"))); ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin() );
app.UseAuthorization();

app.MapControllers();

app.Run();
