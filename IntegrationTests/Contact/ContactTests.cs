using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using NUnit.Framework;
using WebCrm.Client;
using WebCrm.Client.Entities;
using WebCrm.Client.Repository;

namespace IntegrationTests.Contact
{
    [TestFixture]
    public class ContactTests
    {
        private Expression<Func<Organisation, object>>[] _columns;

        private CustomContactRepository _contactRepository;

        private Repository<Organisation> _organisationRepository;

        [OneTimeSetUp]
        public void SetUp()
        {
            Context.Initialise("cm25202tRCWof", "markhoxtontech", "markhoxtontech");

            CustomMappingBuilder
                <CustomContact, WebCrm.Client.Entities.Contact, WebCrm.Client.Entities.Contact.CustomFields> builder =
                    Context.CustomiseContact<CustomContact>();

            builder.AddMapping(c => c.EmailConfirmedRaw, WebCrm.Client.Entities.Contact.CustomFields.p_pcust13);
            builder.Build();

            _contactRepository = new CustomContactRepository();
            _organisationRepository = new Repository<Organisation>();
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

            CustomContact newContact = _contactRepository.GetById(contactId);

            Assert.That(newContact.FirstName, Is.EqualTo(newContact.FirstName));
        }

        [Test]
        public void TestAddDocument()
        {
            string directoryName = Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory);

            var test = new FileInfo(directoryName + "\\debug\\Test Document.docx");

            byte[] bArray = File.ReadAllBytes(directoryName + "\\debug\\Test Document.docx");

            long? organisation = _organisationRepository.ResolveId("Integration Crm");

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

            long documentId = _contactRepository.AddDocument(
                bArray,
                organisation.Value,
                "description",
                test.Extension,
                test.Name,
                string.Empty,
                id);

            ReadDocumentDataResult document = _contactRepository.ReadDocument(documentId);

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

            WebCrm.Client.Entities.Contact contact = _contactRepository.GetById(contactId);

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

            WebCrm.Client.Entities.Contact contact = _contactRepository.GetByName("First Last");

            Assert.That(contact.FullName, Is.EqualTo("First Last"));
        }

        [Test]
        public void TestLog()
        {
            long? organisation = _organisationRepository.ResolveId("Integration Crm");

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

            _contactRepository.Log(id, organisation.Value, "Test log");
        }

        [Test]
        public void TestLookUp()
        {
            IEnumerable<KeyValuePair> division = _contactRepository.GetLookUp(c => c.Division);

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

            _contactRepository.Update(
                customContact,
                new List<Expression<Func<CustomContact, object>>>
                {
                    contact => contact.EmailConfirmedRaw,
                    contact => contact.Mobile_telephone
                });

            CustomContact updateContact = _contactRepository.GetById(contactId);

            Assert.That(updateContact.EmailConfirmedRaw, Is.EqualTo("Yes"));
            Assert.That(updateContact.Mobile_telephone, Is.EqualTo("1234"));
        }

        private long AddContact(CustomContact customContact)
        {
            long? organisationId = _organisationRepository.ResolveId("Integration Crm");

            if (organisationId == null)
            {
                var organisation = new Organisation
                {
                    Name = "Integration Crm"
                };

                _columns = new Expression<Func<Organisation, object>>[]
                {
                    organisation1 => organisation1.Name
                };

                organisationId = _organisationRepository.Add(organisation, _columns);
            }

            customContact.OrganisationId = organisationId.Value;

            IEnumerable<Expression<Func<CustomContact, object>>> contactColumns = new List
                <Expression<Func<CustomContact, object>>>
                {
                    contact => contact.FirstName,
                    contact => contact.LastName,
                    contact => contact.Email
                };

            long contactResult = _contactRepository.Add(customContact, contactColumns);
            return contactResult;
        }
    }
}