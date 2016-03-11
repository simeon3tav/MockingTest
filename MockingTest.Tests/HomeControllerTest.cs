using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockingTest;
using MockingTest.Controllers;
using MockingTest.Services;
using MockingTest.Entities;
using MockingTest.Models;
using Moq;
using System.Web.Mvc;

namespace MockingTest.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<IContactService> _mockContactService;
        private HomeController _controller;

        [TestInitialize]
        public void TestInitialize()
        { 
            _mockContactService = new Mock<IContactService>();
            _controller = new HomeController(_mockContactService.Object);
        } 
       
        [TestCleanup]
        public void TestCleanup()
        {
            _mockContactService.VerifyAll();
        }
      
        [TestMethod]
        public void Index_ExpectViewResultReturned()
        {
            var stubContacts = ReturnStubContacts();

            _mockContactService.Setup(x => x.GetAllContacts()).Returns(stubContacts);

            var expectedModel = new List<ContactViewModel>();

            foreach(var stubContact in stubContacts)
            {
                expectedModel.Add(new ContactViewModel(){
                    Id = stubContact.Id,
                    Email = stubContact.Email,
                    FirstName = stubContact.FirstName,
                    LastName = stubContact.LastName
                });
            }

            var result = _controller.Index() as ViewResult;

            var actualModel = result.Model as List<ContactViewModel>;

            for (int i = 0; i < expectedModel.Count; i++)
            {
                Assert.AreEqual(expectedModel[i].Id, actualModel[i].Id);
            }
        }

        private List<Contact> ReturnStubContacts()
        {
            var contacts = new List<Contact>
            {
                new Contact()
                {
                    Id = 1,
                    FirstName = "Peter",
                    LastName = "Klepec",
                    Email = "klepo.car@gmail.com"
                },
                new Contact()
                {
                    Id = 1,
                    FirstName = "Peter",
                    LastName = "Klepec",
                    Email = "klepo.car@gmail.com"
                }
            };

            return contacts;
        }
    }
}
