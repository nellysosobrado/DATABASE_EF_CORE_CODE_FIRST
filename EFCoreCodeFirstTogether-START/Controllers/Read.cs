using EFCoreCodeFirstTogether_START.Data;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstTogether_START.Controllers
{
    public class Read
    {
        public void RunRead()
        {
            // =====================================================================
            // READ READ READ READ READ READ READ READ READ READ READ READ READ READ
            using (var dbContext = new ApplicationDbContext(options.Options))
            {
                foreach (var person in dbContext.Person)
                {
                    Console.WriteLine($"Namn: {person.Name}");
                    Console.WriteLine($"Ålder: {person.Age}");
                    Console.WriteLine("====================");
                }

                // Hmmm varför ser inte jag någon information i 'County' ?
                // 17b: Jag måste nog köra INCLUDE för att få se datat....

                //foreach (var person in dbContext.Person.Include(c => c.County))
                //{
                //    Console.WriteLine($"Namn: {person.Name}");
                //    Console.WriteLine($"Ålder: {person.Age}");

                //    if (person.County != null)
                //    {
                //        Console.WriteLine($"County kontakperson: {person.County.ContactPerson}");
                //    }

                //    Console.WriteLine("====================");
                //}
            }

        }
    }
}
