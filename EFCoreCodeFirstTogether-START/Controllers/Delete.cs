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
        public ApplicationDbContext _dbContext { get; set; }

        public Delete(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void RunDelete()
        {
            // ==================================================================
            // 19: DELETE DELETE DELETE DELETE DELETE DELETE DELETE DELETE DELETE
            
                Console.WriteLine("(D)ELETE en befintlig person");
                Console.WriteLine("=====================");

                // Vilken person ska raderas?
                foreach (var person in _dbContext.Person)
                {
                    Console.WriteLine($"Id: {person.Id}");
                    Console.WriteLine($"Namn: {person.Name}");
                    Console.WriteLine("====================");
                }

                Console.WriteLine("Välj Id på den Person som du vill radera");
                var personIdToDelete = Convert.ToInt32(Console.ReadLine());
                var personToDelete = _dbContext.Person.First(p => p.Id == personIdToDelete);
                _dbContext.Person.Remove(personToDelete);

                _dbContext.SaveChanges();
        }
    }
}
