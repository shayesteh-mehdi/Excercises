using System;
using System.Collections.Generic;
using System.Text;

namespace UpdateSelectedFieldsOfEntity
{
  public  class Person
    {
        public int PersonId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address_Line1 { get; set; }
        public string address_Line2 { get; set; }
        public string address_Line3 { get; set; }
        public string Phone { get;set; }
        public string Email { get; set; }
    }
}
