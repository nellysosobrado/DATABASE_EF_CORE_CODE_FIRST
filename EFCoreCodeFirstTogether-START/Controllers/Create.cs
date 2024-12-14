using EFCoreCodeFirstTogether_START.Data;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstTogether_START.Controllers
{
    public class Create
    {
        public void RunCreate()
        {
            // ==================================================================
            // 15: CREATE CREATE CREATE CREATE CREATE CREATE CREATE CREATE CREATE
            using (var dbContext = new ApplicationDbContext(options.Options))
            {
                Console.WriteLine("(C)REATE en ny person");
                Console.WriteLine("=====================");

                Console.WriteLine("Ange namn: ");
                var nameInput = Console.ReadLine();

                Console.WriteLine("Ange ålder: ");
                var ageInput = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ange skostorlek: ");
                var shoeSizeInput = Convert.ToInt32(Console.ReadLine());

                foreach (var county in dbContext.County)
                {
                    Console.WriteLine($"{county.Id} - {county.Name}");
                }
                Console.WriteLine("Ange Id på County");
                var countyId = Convert.ToInt32(Console.ReadLine());
                var countyInput = dbContext.County.First(c => c.Id == countyId);

                dbContext.Person.Add(new Person
                {
                    Age = ageInput,
                    Name = nameInput,
                    ShoeSize = shoeSizeInput,
                    County = countyInput
                });
                dbContext.SaveChanges();
            }

        }
    }
}
