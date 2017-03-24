using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using IntegrationTests.Contact;
using IntegrationTests.Opportunity;
using IntegrationTests.Repositories;
using NUnit.Framework;
using WebCrm.Client;
using WebCrm.Client.Entities;
using WebCrm.Client.Repository;

namespace IntegrationTests
{
    [TestFixture]
    public class OpportunityTests : TestBase
    {
        private Repository<Organisation> _organisationRepository;
        private CustomOpportunityRepository _repository;
        private KeyValuePair currencies;
        private KeyValuePair levels;
        private KeyValuePair type;
        private KeyValuePair winProbability;
        private KeyValuePair updatedType;
        private KeyValuePair updatedLevels;
        private KeyValuePair updatedcurrencies;
        private KeyValuePair updatedwinProbability;

        [OneTimeSetUp]
        public void SetUp()
        {
            Context.Initialise("cm25202tRCWof", "markhoxtontech", "markhoxtontech");

            CustomMappingBuilder
                <CustomOpportunity, WebCrm.Client.Entities.Opportunity, WebCrm.Client.Entities.Opportunity.CustomFields>
                customMappingBuilder = Context.CustomiseOpportunity<CustomOpportunity>();

            customMappingBuilder
                .AddMapping(c => c.DeliveryAddress, WebCrm.Client.Entities.Opportunity.CustomFields.op_custom9)
                .AddMapping(c => c.PotentialAnnualRevenue, WebCrm.Client.Entities.Opportunity.CustomFields.op_pcust14)
                .AddLookUpMapping(
                    c => c.OpportunityType,
                    WebCrm.Client.Entities.Opportunity.CustomFields.op_pcust1,
                    c => c.OpportunityTypeDescription).Build();

            _repository = new CustomOpportunityRepository();
            _organisationRepository = new Repository<Organisation>();

            SetUpBase();

            type = _repository.GetLookUp(c => c.OpportunityType).First();
            levels = _repository.GetLookUp(c => c.Level).First();
            currencies = _repository.GetLookUp(c => c.Currency).First();
            winProbability = _repository.GetLookUp(c => c.WinProbability).First();
            
            updatedType = _repository.GetLookUp(c => c.OpportunityType).Skip(1).First();
            updatedLevels = _repository.GetLookUp(c => c.Level).Skip(1).First();
            updatedcurrencies = _repository.GetLookUp(c => c.Currency).Skip(1).First();
            updatedwinProbability = _repository.GetLookUp(c => c.WinProbability).Skip(1).First();

        }

        [Test]
        public void TestAdd()
        {
            CustomOpportunity customOpportunity = CreateOpportunity();

            CustomOpportunity savedOpportunity = _repository.GetById(customOpportunity.WebCrmId);

            Assert.That(savedOpportunity.Description, Is.EqualTo(customOpportunity.Description));
            Assert.That(savedOpportunity.PotentialAnnualRevenue, Is.EqualTo(customOpportunity.PotentialAnnualRevenue));
            Assert.That(savedOpportunity.OrganisationId, Is.EqualTo(customOpportunity.OrganisationId));
            Assert.That(savedOpportunity.Currency, Is.EqualTo(customOpportunity.Currency));
            Assert.That(savedOpportunity.DeliveryAddress, Is.EqualTo(customOpportunity.DeliveryAddress));
            Assert.That(savedOpportunity.OpportunityType, Is.EqualTo(customOpportunity.OpportunityType));
            Assert.That(savedOpportunity.OrderDate, Is.EqualTo(customOpportunity.OrderDate));
            Assert.That(savedOpportunity.WinProbability, Is.EqualTo(customOpportunity.WinProbability));
            Assert.That(savedOpportunity.KeyContactId, Is.EqualTo(customOpportunity.KeyContactId));
        }

        [Test]
        public void TestAddDocument()
        {
            byte[] bArray;
            FileInfo test = GetDocument(out bArray);

            CustomOpportunity opportunity = CreateOpportunity();

            long documentId = _repository.AddDocument(
                bArray,
                opportunity.OrganisationId,
                "description",
                test.Extension,
                test.Name,
                string.Empty,
                opportunity.WebCrmId);

            ReadDocumentDataResult document = _repository.ReadDocument(documentId);

            Assert.That(document.Document.FileName, Is.EqualTo(test.Name));

            Assert.That(document.Document.LinkedEntityType, Is.EqualTo((long)Document.DocumentLinkTypes.Delivery));

            Assert.That(document.Document.LinkedEntityId, Is.EqualTo(opportunity.WebCrmId));
        }

        [Test]
        public void TestGetByName()
        {
            CustomOpportunity newOpportunity = CreateOpportunity();

            CustomOpportunity opportunityById = _repository.GetById(newOpportunity.WebCrmId);

            CustomOpportunity opportunityByName = _repository.GetByName(opportunityById.OpportunityNumber);

            Assert.That(opportunityByName.WebCrmId, Is.EqualTo(opportunityById.WebCrmId));
        }

        [Test]
        public void TestOpportunityTypeLookUp()
        {
            IEnumerable<KeyValuePair> types = _repository.GetLookUp(c => c.OpportunityType);

            Assert.That(types.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void TestUpdate()
        {
            CustomOpportunity customOpportunity = CreateOpportunity();

            customOpportunity.PotentialAnnualRevenue = 12345;
            customOpportunity.Currency = updatedcurrencies.Key;
            customOpportunity.DeliveryAddress = "1 Smith Street 1234";
            customOpportunity.Description = "This is a description 1234";
            customOpportunity.Level = updatedLevels.Key;
            customOpportunity.OpportunityType = updatedType.Key;
            customOpportunity.OrderDate = DateTime.Now;
            customOpportunity.WinProbability = updatedwinProbability.Key;

            IEnumerable<Expression<Func<CustomOpportunity, object>>> columns = new List
                <Expression<Func<CustomOpportunity, object>>>
                {
                    c => c.PotentialAnnualRevenue,
                    opportunity => opportunity.Currency,
                    opportunity => opportunity.DeliveryAddress,
                    opportunity => opportunity.Description,
                    opportunity => opportunity.KeyContactId,
                    opportunity => opportunity.Level,
                    opportunity => opportunity.OpportunityType,
                    opportunity => opportunity.OrderDateRaw,
                    opportunity => opportunity.OpportunityNumber,
                    opportunity => opportunity.WinProbability
                };

            _repository.Update(customOpportunity, columns);

            CustomOpportunity savedOpportunity = _repository.GetById(customOpportunity.WebCrmId);

            Assert.That(savedOpportunity.Description, Is.EqualTo(customOpportunity.Description));
            Assert.That(savedOpportunity.PotentialAnnualRevenue, Is.EqualTo(customOpportunity.PotentialAnnualRevenue));
            Assert.That(savedOpportunity.OrganisationId, Is.EqualTo(customOpportunity.OrganisationId));
            Assert.That(savedOpportunity.Currency, Is.EqualTo(customOpportunity.Currency));
            Assert.That(savedOpportunity.DeliveryAddress, Is.EqualTo(customOpportunity.DeliveryAddress));
            Assert.That(savedOpportunity.OpportunityType, Is.EqualTo(customOpportunity.OpportunityType));
            Assert.That(savedOpportunity.OrderDate, Is.EqualTo(customOpportunity.OrderDate));
            Assert.That(savedOpportunity.WinProbability, Is.EqualTo(customOpportunity.WinProbability));
            Assert.That(savedOpportunity.KeyContactId, Is.EqualTo(customOpportunity.KeyContactId));
        }

        private CustomOpportunity CreateOpportunity()
        {
            long? organisationId = _organisationRepository.ResolveId("Integration Crm");

            if (organisationId == null)
            {
                throw new Exception("Could not create Organisation");
            }

            var customContact = new CustomContact
            {
                FirstName = "First",
                LastName = "Last",
                Email = "markpdixon@outlook.com"
            };

            long contactId = AddContact(customContact);

            var customOpportunity = new CustomOpportunity
            {
                PotentialAnnualRevenue = 1234,
                OrganisationId = organisationId.Value,
                Currency = currencies.Key,
                DeliveryAddress = "1 Smith Street",
                Description = "This is a description",
                KeyContactId = contactId,
                Level = levels.Key,
                OpportunityType = type.Key,
                OrderDate = DateTime.Now,
                OpportunityNumber = "-1",
                WinProbability = winProbability.Key
            };

            IEnumerable<Expression<Func<CustomOpportunity, object>>> columns = new List
                <Expression<Func<CustomOpportunity, object>>>
                {
                    c => c.PotentialAnnualRevenue,
                    opportunity => opportunity.Currency,
                    opportunity => opportunity.DeliveryAddress,
                    opportunity => opportunity.Description,
                    opportunity => opportunity.KeyContactId,
                    opportunity => opportunity.Level,
                    opportunity => opportunity.OpportunityType,
                    opportunity => opportunity.OrderDateRaw,
                    opportunity => opportunity.OpportunityNumber,
                    opportunity => opportunity.WinProbability
                };

            long id = _repository.Add(customOpportunity, columns);

            customOpportunity.WebCrmId = id;

            return customOpportunity;
        }
    }
}