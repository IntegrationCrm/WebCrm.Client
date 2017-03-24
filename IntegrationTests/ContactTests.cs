using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using IntegrationTests.Contact;
using IntegrationTests.Entities;
using NUnit.Framework;
using WebCrm.Client;

namespace IntegrationTests
{
    [TestFixture]
    public class ContactTests : TestBase
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            Context.Initialise("cm25202tRCWof", "markhoxtontech", "markhoxtontech");
            
            SetUpBase();
        }

        [Test]
        public void TestAddCustomContact()
        {
            var customContact = new CustomContact
            {
                FirstName = "First",
                LastName = "Last",
                Email = "markpdixon@outlook.com"
            };

            long contactId = AddContact(customContact);

            CustomContact newContact = ContactRepository.GetById(contactId);

            Assert.That(newContact.FirstName, Is.EqualTo(newContact.FirstName));
        }

        [Test]
        public void TestAddDocument()
        {
            byte[] bArray;
            FileInfo test = GetDocument(out bArray);

            long? organisation = OrganisationRepository.ResolveId("Integration Crm");

            if (organisation == null)
            {
                return;
            }

            var customContact = new CustomContact
            {
                FirstName = "First",
                LastName = "Last",
                Email = "markpdixon@outlook.com",
                OrganisationId = organisation.Value
            };

            long id = AddContact(customContact);

            long documentId = ContactRepository.AddDocument(
                bArray,
                organisation.Value,
                "description",
                test.Extension,
                test.Name,
                string.Empty,
                id);

            ReadDocumentDataResult document = ContactRepository.ReadDocument(documentId);

            Assert.That(document.Document.FileName, Is.EqualTo(test.Name));
        }

        

        [Test]
        public void TestGetContactById()
        {
            var customContact = new CustomContact
            {
                FirstName = "First",
                LastName = "Last",
                Email = "markpdixon@outlook.com"
            };

            long contactId = AddContact(customContact);

            WebCrm.Client.Entities.Contact contact = ContactRepository.GetById(contactId);

            Assert.That(contact.WebCrmId, Is.EqualTo(contactId));
        }

        [Test]
        public void TestGetContactByName()
        {
            var customContact = new CustomContact
            {
                FirstName = "First",
                LastName = "Last",
                Email = "markpdixon@outlook.com"
            };

            AddContact(customContact);

            WebCrm.Client.Entities.Contact contact = ContactRepository.GetByName("First Last");

            Assert.That(contact.FullName, Is.EqualTo("First Last"));
        }

        [Test]
        public void TestLog()
        {
            long? organisation = OrganisationRepository.ResolveId("Integration Crm");

            if (organisation == null)
            {
                return;
            }

            var customContact = new CustomContact
            {
                FirstName = "First",
                LastName = "Last",
                Email = "markpdixon@outlook.com",
                OrganisationId = organisation.Value
            };

            long id = AddContact(customContact);

            ContactRepository.Log(id, organisation.Value, "Test log");
        }

        [Test]
        public void TestLookUp()
        {
            IEnumerable<KeyValuePair> division = ContactRepository.GetLookUp(c => c.Division);

            Assert.That(division.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void TestUpdate()
        {
            var customContact = new CustomContact
            {
                FirstName = "First",
                LastName = "Last",
                Email = "markpdixon@outlook.com"
            };

            long contactId = AddContact(customContact);

            customContact.EmailConfirmedRaw = "Yes";
            customContact.Mobile_telephone = "1234";
            customContact.WebCrmId = contactId;

            ContactRepository.Update(
                customContact,
                new List<Expression<Func<CustomContact, object>>>
                {
                    contact => contact.EmailConfirmedRaw,
                    contact => contact.Mobile_telephone
                });

            CustomContact updateContact = ContactRepository.GetById(contactId);

            Assert.That(updateContact.EmailConfirmedRaw, Is.EqualTo("Yes"));
            Assert.That(updateContact.Mobile_telephone, Is.EqualTo("1234"));
        }
    }
}