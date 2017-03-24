using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using IntegrationTests.Entities;
using IntegrationTests.Repositories;
using NUnit.Framework;
using WebCrm.Client;
using WebCrm.Client.Entities;
using WebCrm.Client.Repository;

namespace IntegrationTests
{
    [TestFixture]
    public class OrganisationTests : TestBase
    {


        public void SetUp()
        {
            
        }
    }


    [TestFixture]
    public class OpportunityTests : TestBase
    {
        private KeyValuePair _currency;
        private KeyValuePair _level;
        private Repository<Organisation> _organisationRepository;
        private CustomOpportunityRepository _repository;
        private KeyValuePair _type;
        private KeyValuePair _updatedCurrency;
        private KeyValuePair _updatedLevel;
        private KeyValuePair _updatedType;
        private KeyValuePair _updatedwinProbability;
        private KeyValuePair _winProbability;

        [OneTimeSetUp]
        public void SetUp()
        {
            Context.Initialise("cm25202tRCWof", "markhoxtontech", "markhoxtontech");

            CustomMappingBuilder
                <CustomOpportunity, Opportunity, Opportunity.CustomFields>
                customMappingBuilder = Context.CustomiseOpportunity<CustomOpportunity>();

            customMappingBuilder
                .AddMapping(c => c.DeliveryAddress, Opportunity.CustomFields.op_custom9)
                .AddMapping(c => c.PotentialAnnualRevenue, Opportunity.CustomFields.op_pcust14)
                .AddLookUpMapping(
                    c => c.OpportunityType,
                    Opportunity.CustomFields.op_pcust1,
                    c => c.OpportunityTypeDescription).Build();

            _repository = new CustomOpportunityRepository();
            _organisationRepository = new Repository<Organisation>();

            SetUpBase();

            _type = _repository.GetLookUp(c => c.OpportunityType).First();
            _level = _repository.GetLookUp(c => c.Level).First();
            _currency = _repository.GetLookUp(c => c.Currency).First();
            _winProbability = _repository.GetLookUp(c => c.WinProbability).First();

            _updatedType = _repository.GetLookUp(c => c.OpportunityType).Skip(1).First();
            _updatedLevel = _repository.GetLookUp(c => c.Level).Skip(1).First();
            _updatedCurrency = _repository.GetLookUp(c => c.Currency).Skip(1).First();
            _updatedwinProbability = _repository.GetLookUp(c => c.WinProbability).Skip(1).First();
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
            customOpportunity.Currency = _updatedCurrency.Key;
            customOpportunity.DeliveryAddress = "1 Smith Street 1234";
            customOpportunity.Description = "This is a description 1234";
            customOpportunity.Level = _updatedLevel.Key;
            customOpportunity.OpportunityType = _updatedType.Key;
            customOpportunity.OrderDate = DateTime.Now;
            customOpportunity.WinProbability = _updatedwinProbability.Key;

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
                Currency = _currency.Key,
                DeliveryAddress = "1 Smith Street",
                Description = "This is a description",
                KeyContactId = contactId,
                Level = _level.Key,
                OpportunityType = _type.Key,
                OrderDate = DateTime.Now,
                OpportunityNumber = "-1",
                WinProbability = _winProbability.Key
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