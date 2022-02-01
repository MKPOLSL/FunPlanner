using FunPlannerApi.Automapper;
using FunPlannerApi.Controllers;
using FunPlannerApi.Data;
using FunPlannerShared.Controllers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Profiles));

builder.Services.AddDbContext<Context>(options =>
       options.UseSqlServer("Data Source=VUZIX-KOMPUTR\\MSSQL_FUNPLANNER;Initial Catalog=funplanner;Integrated Security=True"));

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddScoped<PersonController>();

var app = builder.Build();

app.UseCors("CorsPolicy");

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
