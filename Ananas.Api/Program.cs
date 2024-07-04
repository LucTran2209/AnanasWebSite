
using Ananas.Infrastructure;
using Ananas.Infrastructure.Mapper;
using Ananas.Services.Common.Mapper;
using Ananas.Services.Interfaces;
using Ananas.Services.Services.AuthenticationService;
using Ananas.Services.Services.ColorService;
using Ananas.Services.Services.MarketService;
using Ananas.Services.Services.ProductService;
using Microsoft.OpenApi.Models;

namespace Ananas.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                //options.SwaggerDoc("V1", new OpenApiInfo
                //{
                //    Version = "v1",
                //    Title = "Demo_JWT",
                //    Description = "Product API"
                //});
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.Http
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                  {
                    new OpenApiSecurityScheme {
                                Reference = new OpenApiReference {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                  }
                    },
                         new List < string > ()
                  }
                });
            });

            // Add services to the container.
            builder.Services.AddServices(builder.Configuration);
            builder.Services.AddAutoMapperProfiles();
            builder.Services.AddAutoMapperInfastructure();

            // DI Service
            builder.Services.AddScoped<IColorService, ColorService>();
            builder.Services.AddScoped<IMarketService, MarketService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}