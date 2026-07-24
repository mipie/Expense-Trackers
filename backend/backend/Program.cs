using backend.Data;
using backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

const string CorsPolicyName = "AllowAngular";

builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsPolicyName, policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    });
});

// Add services to the controllers
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the database
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=expensetrackerdb;Username=postgres;Password=secret_password;"));

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TransactionService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ⚠️ L'ORDRE D'EXÉCUTION DES MIDDLEWARES EST CRUCIAL ICI :
app.UseRouting(); // 1. Résout la route de la requête
app.UseCors(CorsPolicyName); // 2. Applique le CORS sur la route trouvée
app.UseAuthorization(); // 3. Gère l'autorisation
app.MapControllers(); // 4. Exécute le contrôleur

app.Run();

