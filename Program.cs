using incidentMgtSystem.API.Models;
using incidentMgtSystem.API.Respositories;
using incidentMgtSystem.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//add dependency for token -->transient , scope , singleton?
//added as scope --> for every api call create new instance of classes
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<AccountRepo>();

builder.Services.AddScoped<IncidentService>();
builder.Services.AddScoped<IncidentRepo>();


//along with this for jwt token creation 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secretkey"]))
    }
    ) ;; 

builder.Services.AddDbContext<IncidentDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
