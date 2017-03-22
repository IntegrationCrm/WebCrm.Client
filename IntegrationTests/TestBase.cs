using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebCrm.Client;
using WebCrm.Client.Entities;
using WebCrm.Client.Repository;

namespace IntegrationTests.Contact
{
    public class TestBase
    {
        protected CustomContactRepository ContactRepository { get; set; }

        protected Repository<Organisation> OrganisationRepository { get; set; }

        public void SetUpBase()
        {

            CustomMappingBuilder
               <CustomContact, WebCrm.Client.Entities.Contact, WebCrm.Client.Entities.Contact.CustomFields> builder =
                   Context.CustomiseContact<CustomContact>();

            builder.AddMapping(c => c.EmailConfirmedRaw, WebCrm.Client.Entities.Contact.CustomFields.p_pcust13);
            builder.Build();


            ContactRepository = new CustomContactRepository();



            OrganisationRepository = new Repository<Organisation>();
        }

        protected long AddContact(CustomContact customContact)
        {
            long? organisationId = OrganisationRepository.ResolveId("Integration Crm");

            if (organisationId == null)
            {
                var organisation = new Organisation
                {
                    Name = "Integration Crm"
                };

                var columns = new Expression<Func<Organisation, object>>[]
                {
                    organisation1 => organisation1.Name
                };

                organisationId = OrganisationRepository.Add(organisation, columns);
            }

            customContact.OrganisationId = organisationId.Value;

            IEnumerable<Expression<Func<CustomContact, object>>> contactColumns = new List
                <Expression<Func<CustomContact, object>>>
                {
                    contact => contact.FirstName,
                    contact => contact.LastName,
                    contact => contact.Email
                };

            long contactResult = ContactRepository.Add(customContact, contactColumns);
            return contactResult;
        }
    }
}