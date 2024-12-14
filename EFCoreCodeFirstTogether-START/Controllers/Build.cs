using EFCoreCodeFirstTogether_START.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstTogether_START
{
    public class Build
    {
        public ApplicationDbContext BuildApp()
        {
            // 4: Create json builder (boiler plate code)
            // Skapar en ConfigurationBuilder som hjälper till att läsa inställningar
            // från JSON-filen "appsettings.json".
            var builder = new ConfigurationBuilder()
                // .AddJsonFile() anger filens namn, och de två sista argumenten betyder:
                // - true: tillåt att filen saknas utan att ge felmeddelande.
                // - true: ladda om konfigurationen automatiskt om filen ändras.
                .AddJsonFile($"appsettings.json", true, true);
            // Bygger configurationen och laddar in inställningarna från filen så
            // att vi kan använda dem i programmet.
            var config = builder.Build();

            // 6: Create DBContext(boiler plate code).
            // Skapar en DbContextOptionsBuilder som hjälper till att konfigurera
            // alternativ för ApplicationDbContext.
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Hämtar anslutningssträngen "DefaultConnection" från inställningarna i
            // config-objektet.
            var connectionString = config.GetConnectionString("DefaultConnection");

            // Använder anslutningssträngen för att konfigurera SQL Server som
            // databas för ApplicationDbContext.
            options.UseSqlServer(connectionString);

            // 7a: Kör i console add-migration "Initial migration"
            // 7b: Migrate DbSets to SQL tabeller
            // Om inte databasen redan finns... så skapas den nu.

            // Skapar en instans av ApplicationDbContext och använder de konfigurerade
            // alternativen(options).
            using (var dbContext = new ApplicationDbContext(options.Options))
            {
                var dataInitiaizer = new DataInitializer();
                dataInitiaizer.MigrateAndSeed(dbContext);

                // Migrate har flyttats till dataInitializer class (BEST PRACTISE)
                // dbContext.Database.Migrate();
            }

            var dbContextReturned = new ApplicationDbContext(options.Options);
            return dbContextReturned;

            
        }
    }
}
