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
        private IEnumerable<KeyValuePair> _division;
        private IEnumerable<KeyValuePair> _lookup1;
        private IEnumerable<KeyValuePair> _lookup2;
        private IEnumerable<KeyValuePair> _lookup3;
        private CustomOrganisationRepository _repository;
        private User _responsible;

        private Repository<User> _userrepository
            ;

        private User _updatedResponsible;

        [OneTimeSetUp]
        public void SetUp()
        {
            Context.Initialise("cm25202tRCWof", "markhoxtontech", "markhoxtontech");

            SetUpBase();

            CustomMappingBuilder<CustomOrganisation, Organisation, Organisation.CustomFields> customMapperBuilder =
                Context.CustomiseOrganisation<CustomOrganisation>();

            customMapperBuilder.AddLookUpMapping(
                c => c.CompanyType1,
                Organisation.CustomFields.o_custom1,
                d => d.CompanyType1Description);
            customMapperBuilder.AddLookUpMapping(
                c => c.CompanyType2,
                Organisation.CustomFields.o_custom2,
                d => d.CompanyType2Description);
            customMapperBuilder.AddLookUpMapping(
                c => c.CompanyType3,
                Organisation.CustomFields.o_custom3,
                d => d.CompanyType3Description);

            customMapperBuilder.AddMapping(c => c.ConsignmentStock, Organisation.CustomFields.o_custom13);

            customMapperBuilder.Build();

            _repository = new CustomOrganisationRepository();
            _userrepository = new Repository<User>();

            _lookup1 = _repository.GetLookUp(c => c.CompanyType1);
            _lookup2 = _repository.GetLookUp(c => c.CompanyType2);
            _lookup3 = _repository.GetLookUp(c => c.CompanyType3);
            _responsible = _userrepository.GetByName("Mark Dixon");

            _updatedResponsible = _userrepository.GetAll().Skip(3).First();

            _division = _repository.GetLookUp(c => c.Division);
        }

        [Test]
        public void TestAdd()
        {
            CustomOrganisation customOrganisation = AddOrganisation();

            CustomOrganisation addOrganisation = _repository.GetById(customOrganisation.WebCrmId);

            Assert.That(addOrganisation.Name, Is.EqualTo(customOrganisation.Name));
            Assert.That(addOrganisation.ConsignmentStock, Is.EqualTo(customOrganisation.ConsignmentStock));
            Assert.That(addOrganisation.CompanyType1, Is.EqualTo(customOrganisation.CompanyType1));
            Assert.That(addOrganisation.CompanyType1Description, Is.EqualTo(_lookup1.First().Value));
            Assert.That(addOrganisation.CompanyType2, Is.EqualTo(customOrganisation.CompanyType2));
            Assert.That(addOrganisation.CompanyType2Description, Is.EqualTo(_lookup2.First().Value));
            Assert.That(addOrganisation.CompanyType3, Is.EqualTo(customOrganisation.CompanyType3));
            Assert.That(addOrganisation.CompanyType3Description, Is.EqualTo(_lookup3.First().Value));
            Assert.That(addOrganisation.Division, Is.EqualTo(customOrganisation.Division));
            Assert.That(addOrganisation.DivisionDescription, Is.EqualTo(_division.First().Value));
            Assert.That(addOrganisation.Responsible, Is.EqualTo(_responsible.WebCrmId));
        }

        [Test]
        public void TestAddDocument()
        {
            byte[] bArray;
            FileInfo test = GetDocument(out bArray);

            CustomOrganisation organisation = AddOrganisation();

            long documentId = _repository.AddDocument(
                bArray,
                organisation.OrganisationId,
                "description",
                test.Extension,
                test.Name,
                string.Empty,
                organisation.OrganisationId);

            ReadDocumentDataResult document = _repository.ReadDocument(documentId);

            Assert.That(document.Document.FileName, Is.EqualTo(test.Name));
        }

        [Test]
        public void TestUpdate()
        {
            CustomOrganisation organisation = AddOrganisation();

            CustomOrganisation addedOrganisation = _repository.GetById(organisation.WebCrmId);

            addedOrganisation.CompanyType1 = _lookup1.Skip(1).First().Key;
            addedOrganisation.CompanyType2 = _lookup2.Skip(1).First().Key;
            addedOrganisation.CompanyType3 = _lookup3.Skip(1).First().Key;
            addedOrganisation.Division = _division.Skip(1).First().Key;
            addedOrganisation.Name = "Updated Name";
            addedOrganisation.Responsible = _updatedResponsible.WebCrmId;

            IEnumerable<Expression<Func<CustomOrganisation, object>>> fields = new List
                <Expression<Func<CustomOrganisation, object>>>
                {
                    customOrganisation => customOrganisation.Name,
                    customOrganisation => customOrganisation.CompanyType1,
                    customOrganisation => customOrganisation.CompanyType2,
                    customOrganisation => customOrganisation.CompanyType3, 
                    customOrganisation => customOrganisation.Division, 
                    customOrganisation => customOrganisation.Responsible    
                };

            _repository.Update(addedOrganisation, fields);

            CustomOrganisation updatedOrganisation = _repository.GetById(organisation.WebCrmId);

            Assert.That(updatedOrganisation.Name, Is.EqualTo(addedOrganisation.Name));
            Assert.That(updatedOrganisation.ConsignmentStock, Is.EqualTo(addedOrganisation.ConsignmentStock));
            Assert.That(updatedOrganisation.CompanyType1, Is.EqualTo(addedOrganisation.CompanyType1));
            Assert.That(updatedOrganisation.CompanyType1Description, Is.EqualTo(_lookup1.Skip(1).First().Value));
            Assert.That(updatedOrganisation.CompanyType2, Is.EqualTo(addedOrganisation.CompanyType2));
            Assert.That(updatedOrganisation.CompanyType2Description, Is.EqualTo(_lookup2.Skip(1).First().Value));
            Assert.That(updatedOrganisation.CompanyType3, Is.EqualTo(addedOrganisation.CompanyType3));
            Assert.That(updatedOrganisation.CompanyType3Description, Is.EqualTo(_lookup3.Skip(1).First().Value));
            Assert.That(updatedOrganisation.Division, Is.EqualTo(addedOrganisation.Division));
            Assert.That(updatedOrganisation.DivisionDescription, Is.EqualTo(_division.Skip(1).First().Value));
            Assert.That(updatedOrganisation.Responsible, Is.EqualTo(_updatedResponsible.WebCrmId));
        }

        private CustomOrganisation AddOrganisation()
        {
            var customOrganisation = new CustomOrganisation
            {
                ConsignmentStock = "Yes",
                CompanyType1 = _lookup1.First().Key,
                CompanyType2 = _lookup2.First().Key,
                CompanyType3 = _lookup3.First().Key,
                Name = "Custom Organisation",
                Division = _division.First().Key,
                Responsible = _responsible.WebCrmId
            };

            IEnumerable<Expression<Func<CustomOrganisation, object>>> fields = new Expression
                <Func<CustomOrganisation, object>>[]
                {
                    organisation => organisation.ConsignmentStock,
                    organisation => organisation.CompanyType1,
                    organisation => organisation.CompanyType2,
                    organisation => organisation.CompanyType3,
                    organisation => organisation.Name,
                    organisation => organisation.Division,
                    organisation => organisation.Responsible
                };

            long id = _repository.Add(customOrganisation, fields);

            customOrganisation.WebCrmId = id;
            return customOrganisation;
        }
    }
}