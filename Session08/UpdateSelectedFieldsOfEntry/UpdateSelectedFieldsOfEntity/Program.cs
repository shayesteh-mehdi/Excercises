using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UpdateSelectedFieldsOfEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            SeedDatabase();
            var _ctx1 = new MainDbContex();
            var person1 = _ctx1.People.AsNoTracking().SingleOrDefault(x => x.Email == "eml5");
            if (person1 != null)
            {

                person1.Phone = "09222222222";
                person1.address_Line1 = "ln1";
                person1.address_Line2 = "ln2";
                person1.address_Line3 = "ln3";


                var _ctx_new = new MainDbContex();
                _ctx_new.UpdateSelectedFields<Person>(person1, new List<string> { "Phone", "address_Line1", "address_Line2", "address_Line3" });
                _ctx_new.SaveChanges();
            }
            else
            {
                Console.WriteLine("Person Not Found!");
            }


            Console.WriteLine("Finished.");
            Console.ReadKey();
        }




        private static void SeedDatabase()
        {
            var _ctx0 = new MainDbContex();
            List<Person> lst_people = _ctx0.People.ToList();
            lst_people.ForEach(x => _ctx0.Remove(x));

            var person1 = new Person { firstName = "fn1", lastName = "ls1", Email = "eml1", Phone = "09121345678" };
            var person2 = new Person { firstName = "fn2", lastName = "ls2", Email = "eml2", Phone = "09122345678" };
            var person3 = new Person { firstName = "fn3", lastName = "ls3", Email = "eml3", Phone = "09123345678" };

            _ctx0.AddRange(person1, person2, person3);
            _ctx0.SaveChanges();
        }
    }






}
