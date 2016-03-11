using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockingTest.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
    }
}