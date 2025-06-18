using Microsoft.EntityFrameworkCore;
using TLSPL_ProdutBackEnd.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//  Allow all CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//  Use the "AllowAll" CORS policy
app.UseCors("AllowAll");

app.UseSwagger();
app.UseSwaggerUI();

// Optional: disable if you're only using HTTP for local dev
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

