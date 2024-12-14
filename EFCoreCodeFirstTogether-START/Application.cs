﻿using EFCoreCodeFirstTogether_START.Data;
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
    public class Application
    {
        public void Run()
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

            // =========================================================================
            // 18: UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE UPDATE
            using (var dbContext = new ApplicationDbContext(options.Options))
            {
                Console.WriteLine("(U)PDATE en befintlig person");
                Console.WriteLine("=====================");

                // Vilken person ska uppdateras?
                foreach (var person in dbContext.Person)
                {
                    Console.WriteLine($"Id: {person.Id}");
                    Console.WriteLine($"Namn: {person.Name}");
                    Console.WriteLine("====================");
                }

                Console.WriteLine("Välj Id på den Person som du vill uppdatera");
                var personIdToUpdate = Convert.ToInt32(Console.ReadLine());
                var personToUpdate = dbContext.Person.First(p => p.Id == personIdToUpdate);

                // Uppdatera korrekt person
                Console.WriteLine("Ange namn: ");
                var nameUpdate = Console.ReadLine();

                Console.WriteLine("Ange ålder: ");
                var ageUpdate = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ange skostorlek: ");
                var shoeSizeUpdate = Convert.ToInt32(Console.ReadLine());

                foreach (var county in dbContext.County)
                {
                    Console.WriteLine($"{county.Id} - {county.Name}");
                }
                Console.WriteLine("Ange Id på County");
                var countyIdUpdate = Convert.ToInt32(Console.ReadLine());
                var countyUpdate = dbContext.County.First(c => c.Id == countyIdUpdate);

                // Mappar input info till rätt person
                personToUpdate.Age = ageUpdate;
                personToUpdate.Name = nameUpdate;
                personToUpdate.ShoeSize = shoeSizeUpdate;
                personToUpdate.County = countyUpdate;
                dbContext.SaveChanges();
            }

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
