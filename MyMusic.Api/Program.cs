using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyMusic.Api.Extensions;
using MyMusic.Core;
using MyMusic.Core.Models.Auth;
using MyMusic.Core.Services;
using MyMusic.Data;
using MyMusic.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<MyMusicDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
    sqlOptions => sqlOptions.MigrationsAssembly("MyMusic.Data")));
builder.Services.AddTransient<IMusicService, MusicService>();
builder.Services.AddTransient<IArtistService, ArtistService>();

// Add identities to the container.
builder.Services.AddIdentity<User, Role>(options => {
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
    options.Lockout.MaxFailedAccessAttempts = 5;
})
    .AddEntityFrameworkStores<MyMusicDbContext>()
    .AddDefaultTokenProviders();
// Add Jwt to the container.
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
// Add Authentication to the container.
var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();
builder.Services.AddAuth(jwtSettings);
// Enable automapper to the container.
builder.Services.AddAutoMapper(typeof(Program));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen
(
    options =>
    {
        options.SwaggerDoc
        (
            "v1", new OpenApiInfo 
            {
                Title = "My Music",
                Version = "v1" 
            }
        );
        options.AddSecurityDefinition
        ("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT containing userid claim",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
            }
        );
        var security = new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    },
                    UnresolvedReference = true
                },
                new List<string>()
            }
        };
        options.AddSecurityRequirement(security);
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI
    (
        c =>
        {
            c.RoutePrefix = "";
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Music V1");
        }
    );
}

app.UseHttpsRedirection();

app.UseAuth();

app.MapControllers();

app.Run();
