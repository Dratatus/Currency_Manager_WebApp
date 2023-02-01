using CurrencyManager.Data.Configutation;
using CurrencyManager.Data.Entities;
using CurrencyManager.Data.Repositories;
using CurrencyManager.Logic.Services.CurrencyProvider;
using CurrencyManager.Logic.Services.ExchangeRates;
using CurrencyManager.Logic.Services.ExchangeRatesProvider;
using CurrencyManager.WebApp.Models.Services.Converter;
using CurrencyManager.WebApp.Models.Services.Profile;
using CurrencyManager.WebApp.Services.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace CurrencyManager.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<ICurrencyProviderService, ApiCurrencyProviderService>();
            builder.Services.AddTransient<IExchangeRateProviderService, ApiExchangeRatesProviderService>();
            builder.Services.AddTransient<IExchangeRatesService, ExchangeRatesService>();
            builder.Services.AddTransient<IProfileService, ProfileService>();
            builder.Services.AddTransient<IConverterService, ConverterService>();


            builder.Services.AddSingleton<IUserService, UserService>();

            builder.Services.AddTransient<IRepositoryBase<User>, RepositoryBase<User>>();
            builder.Services.AddSingleton<CurrencyManagerDbContext>();
            

            var app = builder.Build();

            var currencyManagerDbContext = app.Services.GetService<CurrencyManagerDbContext>();

            currencyManagerDbContext.Database.EnsureCreated();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Ustawianie domyœlnej strony (po uruchomieniu apki)
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Login}");

            app.Run();
        }
    }
}