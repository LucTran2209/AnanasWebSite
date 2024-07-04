using Ananas.Infrastructure;
using Ananas.Services.Common.Mapper;
using Ananas.Services.Interfaces;
using Ananas.Services.Services.CategoryService;
using Ananas.Services.Services.CollectionService;
using Ananas.Services.Services.ColorService;
using Ananas.Services.Services.DiscountService;
using Ananas.Services.Services.MarketService;
using Ananas.Services.Services.SexService;
using Ananas.Services.Services.SizeService;
using Ananas.Services.Services.StyleService;

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
            // DI Service
            builder.Services.AddScoped<IColorService, ColorService>();
            builder.Services.AddScoped<IMarketService, MarketService>();
            builder.Services.AddScoped<ICollectionService, CollectionService>();
            builder.Services.AddScoped<IStyleService, StyleService>();
            builder.Services.AddScoped<ISexService, SexService>();
            builder.Services.AddScoped<ISizeService, SizeService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IDiscountService, DiscountService>();
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