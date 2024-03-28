
using LibraryDAL.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Library.IOC
{
    public static  class ConfigurationProgram
    {
        internal static void AddSwaggerAuthentication( this IServiceCollection service )
        {
            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Library Management System",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Autheorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Here Enter Token bearer formate like Bearer[space] token"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                     {
                    {
                          new OpenApiSecurityScheme
                           {
                            Reference = new OpenApiReference
                             {
                             Type = ReferenceType.SecurityScheme,
                             Id = "Bearer"
                             }
                     },
                     new List<string>() 
                    }
                 });
            });
        }
        internal  static void AddLibraryContext(this IServiceCollection service, IConfiguration congiration)
        {
            service.AddDbContext<LibraryDbContext>(
    opt => opt.UseSqlServer(congiration.GetConnectionString("Dbconnection")));
        }
        internal static void AddLibraryAuthentication(this IServiceCollection service, IConfiguration congiration)
        {
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(congiration["JwtToken:key"]))
        };
    }
    );
        }
    }
}
