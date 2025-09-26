using Azure.Identity;
using Business_Layer.DTO;
using Business_Layer.Service;
using Data_Access_Layer.Data;
using Data_Access_Layer.Models;
using Data_Access_Layer.Repositorys;
using Microsoft.EntityFrameworkCore;
using Student_Management;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Microsoft.Extensions.Azure;
using static System.Collections.Specialized.BitVector32;
using Newtonsoft.Json;
using Azure.Security.KeyVault.Secrets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddAutoMapper(typeof(MappingConfig));

//var keyVaultEndPoint = new Uri("https://kv-system12.vault.azure.net/");
//builder.Configuration.AddAzureKeyVault(keyVaultEndPoint, new DefaultAzureCredential());
//var secret = builder.Configuration.GetSection("ConnectionStrings-AzureConnection");
//string jsonString = JsonConvert.SerializeObject(secret, Formatting.Indented);

string connectionString = builder.Configuration.GetConnectionString("AzureConnection");

// Configure DbContext to use the retrieved database connection string
builder.Services.AddDbContext<StudentDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
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
