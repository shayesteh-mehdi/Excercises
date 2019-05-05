using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveAll
{
    class Program
    {
        static void Main(string[] args)
        {
            var _ctx = new MainDbContex();
            var person1 = new Person { FirstName = "f1", LastName = "l1", Email = "a1@mail.com" };
            person1.jobTitles.Add(new JobTitle { name = "jt1" });
            person1.jobTitles.Add(new JobTitle { name = "jt2" });
            person1.jobTitles.Add(new JobTitle { name = "jt3" });
            person1.jobTitles.Add(new JobTitle { name = "jt4" });
            person1.jobTitles.Add(new JobTitle { name = "jt5" });

            var person2 = new Person { FirstName = "f2", LastName = "l2", Email = "a2@mail.com" };
            person2.jobTitles.Add(new JobTitle { name = "jt0" });

            var person3 = new Person { FirstName = "f3", LastName = "l3", Email = "a3@mail.com" };
            var person4 = new Person { FirstName = "f4", LastName = "l4", Email = "a4@mail.com" };
            var person5 = new Person { FirstName = "f5", LastName = "l5", Email = "a5@mail.com" };

            _ctx.People.AddRange(person1, person2, person3, person4, person5);
            _ctx.SaveChanges();



            Console.WriteLine();
            Console.WriteLine("Truncate Table JobTitle...");
            var _ctx2 = new MainDbContex();
            _ctx2.RemoveAll<JobTitle>();
            _ctx2.SaveChanges();
            Console.WriteLine("Finshed Truncate JobTitle!");
 


            Console.WriteLine();
            PrintAllPeople();
            Console.WriteLine("Now Delete all rows People...");

            var _ctx3 = new MainDbContex();
            _ctx3.RemoveAll<Person>();
            _ctx3.SaveChanges();
            PrintAllPeople();

            Console.WriteLine("all People rows Deleted!");
            Console.ReadLine();
        }

        private static void PrintAllPeople()
        {
            var _ctx = new MainDbContex();
            var list = _ctx.People.ToList();

            Console.WriteLine("list people : ");
            foreach (var item in list)
            {

                Console.WriteLine($"Id={item.PersonId}  FirstName={item.FirstName}  LastName={item.LastName}  Email={item.Email}");
            }
        }
    }
}
