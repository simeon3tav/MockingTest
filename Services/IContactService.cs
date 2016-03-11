using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MockingTest.Entities;

namespace MockingTest.Services
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAllContacts();
    }
}
