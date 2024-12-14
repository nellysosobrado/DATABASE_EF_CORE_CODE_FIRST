using EFCoreCodeFirstTogether_START.Data;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstTogether_START.Controllers
{
    public class Delete
    {
        public RunDelete()
        {
            // ==================================================================
            // 19: DELETE DELETE DELETE DELETE DELETE DELETE DELETE DELETE DELETE
            using (var dbContext = new ApplicationDbContext(options.Options))
            {
                Console.WriteLine("(D)ELETE en befintlig person");
                Console.WriteLine("=====================");

                // Vilken person ska raderas?
                foreach (var person in dbContext.Person)
                {
                    Console.WriteLine($"Id: {person.Id}");
                    Console.WriteLine($"Namn: {person.Name}");
                    Console.WriteLine("====================");
                }

                Console.WriteLine("Välj Id på den Person som du vill radera");
                var personIdToDelete = Convert.ToInt32(Console.ReadLine());
                var personToDelete = dbContext.Person.First(p => p.Id == personIdToDelete);
                dbContext.Person.Remove(personToDelete);

                dbContext.SaveChanges();
            }
        }
    }
}
