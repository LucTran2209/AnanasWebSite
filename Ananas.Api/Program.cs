
using Ananas.Infrastructure;
using Ananas.Infrastructure.Mapper;
using Ananas.Services.Common.Mapper;
using Ananas.Services.Interfaces;
using Ananas.Services.Services.ColorService;
using Ananas.Services.Services.MarketService;
using Ananas.Services.Services.ProductService;

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
            builder.Services.AddSwaggerGen();

            // Add services to the container.
            builder.Services.AddDIServices(builder.Configuration);
            builder.Services.AddAutoMapperProfiles();
            builder.Services.AddAutoMapperInfastructure();
            // DI Service
            builder.Services.AddScoped<IColorService, ColorService>();
            builder.Services.AddScoped<IMarketService, MarketService>();
            builder.Services.AddScoped<IProductService, ProductService>();

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
        }
    }
}