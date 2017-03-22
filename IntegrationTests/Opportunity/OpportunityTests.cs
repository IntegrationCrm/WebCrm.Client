using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IntegrationTests.Contact;
using IntegrationTests.Repositories;
using NUnit.Framework;
using WebCrm.Client;
using WebCrm.Client.Entities;
using WebCrm.Client.Repository;

namespace IntegrationTests.Opportunity
{
    [TestFixture]
    public class OpportunityTests : TestBase
    {
        private Repository<Organisation> _organisationRepository;
        private CustomOpportunityRepository _repository;

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
        }

        [Test]
        public void TestAdd()
        {
            KeyValuePair type = _repository.GetLookUp(c => c.OpportunityType).First();
            KeyValuePair levels = _repository.GetLookUp(c => c.Level).First();
            KeyValuePair currencies = _repository.GetLookUp(c => c.Currency).First();
            KeyValuePair winProbability = _repository.GetLookUp(c => c.WinProbability).First();

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

            CustomOpportunity savedOpportunity = _repository.GetById(id);

            Assert.That(savedOpportunity.Description, Is.EqualTo(customOpportunity.Description));
            Assert.That(savedOpportunity.PotentialAnnualRevenue, Is.EqualTo(customOpportunity.PotentialAnnualRevenue));
            Assert.That(savedOpportunity.WebCrmId, Is.EqualTo(id));
            Assert.That(savedOpportunity.OrganisationId, Is.EqualTo(customOpportunity.OrganisationId));
            Assert.That(savedOpportunity.Currency, Is.EqualTo(customOpportunity.Currency));
            Assert.That(savedOpportunity.DeliveryAddress, Is.EqualTo(customOpportunity.DeliveryAddress));
            Assert.That(savedOpportunity.OpportunityType, Is.EqualTo(customOpportunity.OpportunityType));
            Assert.That(savedOpportunity.OrderDate, Is.EqualTo(customOpportunity.OrderDate));
            Assert.That(savedOpportunity.WinProbability, Is.EqualTo(customOpportunity.WinProbability));
            Assert.That(savedOpportunity.KeyContactId, Is.EqualTo(customOpportunity.KeyContactId));
        }

        public void TestAddDocument()
        {
        }

        public void TestGetByName()
        {
        }

        [Test]
        public void TestOpportunityTypeLookUp()
        {
            IEnumerable<KeyValuePair> types = _repository.GetLookUp(c => c.OpportunityType);

            Assert.That(types.Count(), Is.GreaterThan(0));
        }

        public void TestUpdate()
        {
        }
    }
}