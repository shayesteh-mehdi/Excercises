using System;
using System.Collections.Generic;
using System.Text;

namespace RemoveAll
{
   public  class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public List<JobTitle> jobTitles { get; set; } = new List<JobTitle>();
    }
}
