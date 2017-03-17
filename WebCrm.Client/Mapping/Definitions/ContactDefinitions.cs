using System.Collections.Generic;
using WebCrm.Client.Entities;

namespace WebCrm.Client.Mapping.Definitions
{
    internal sealed class ContactDefinitions : DefinitionBase<Contact>
    {
        public override DataEntityType DataEntityType => DataEntityType.Persons;

        public override Document.DocumentLinkTypes DocumentLinkType => Document.DocumentLinkTypes.Contact;

        public override IEnumerable<MappingDefinition<Contact>> Definitions
        {
            get
            {
                return new[]
                {
                    new MappingDefinition<Contact>
                    {
                        Property = dto => dto.WebCrmId,
                        WebCrmField = Contact.BaseFields.person_id.ToString()
                    },
                    new MappingDefinition<Contact>
                    {
                        Property = dto => dto.OrganisationId,
                        WebCrmField = Contact.BaseFields.organisation_id.ToString()
                    },
                    new MappingDefinition<Contact>
                    {
                        Property = dto => dto.Mobile_telephone,
                        WebCrmField = Contact.BaseFields.p_mobiletel.ToString()
                    },
                    new MappingDefinition<Contact>
                    {
                        Property = dto => dto.Email,
                        WebCrmField = Contact.BaseFields.p_email.ToString()
                    },
                    new MappingDefinition<Contact>
                    {
                        Property = dto => dto.FullName,
                        WebCrmField = Contact.BaseFields.p_name.ToString()
                    },
                    new MappingDefinition<Contact>
                    {
                        Property = dto => dto.FirstName,
                        WebCrmField = Contact.BaseFields.p_firstname.ToString()
                    },
                    new MappingDefinition<Contact>
                    {
                        Property = dto => dto.LastName,
                        WebCrmField = Contact.BaseFields.p_lastname.ToString()
                    },
                    new MappingDefinition<Contact>
                    {
                        Property = dto => dto.JobTitle,
                        WebCrmField = Contact.BaseFields.p_title.ToString()
                    },
                    new MappingDefinition<Contact>
                    {
                        Property = dto => dto.Status,
                        WebCrmField = Contact.BaseFields.p_status.ToString()
                    },
                    new MappingDefinition<Contact>
                    {
                        Property = dto => dto.CompanyType,
                        WebCrmField = Client.Entities.Organisation.BaseFields.o_type.ToString()
                    },
                    new MappingDefinition<Contact>
                    {
                        Property = dto => dto.Telephone,
                        WebCrmField = Contact.BaseFields.p_dirtel.ToString()
                    },
                    new MappingDefinition<Contact>
                    {
                        Property = dto => dto.OrganisationStatus,
                        WebCrmField = Client.Entities.Organisation.BaseFields.o_status.ToString()
                    },
                    new LookUpMappingDefinition<Contact>
                    {
                        Property = c => c.Division,
                        WebCrmField = Opportunity.BaseFields.o_territory.ToString(),
                        DescriptionProperty = dto => dto.DivisionDescription
                    },
                    new MappingDefinition<Contact>
                    {
                        Property = dto => dto.OrganisationName,
                        WebCrmField = Client.Entities.Organisation.BaseFields.o_organisation.ToString()
                    },
                    new MappingDefinition<Contact>
                    {
                        Property = dto => dto.ResponsibleUser,
                        WebCrmField = Client.Entities.Organisation.BaseFields.o_owner.ToString()
                    }
                };
            }
        }

        public override string Id => Contact.BaseFields.person_id.ToString();

        public override string NameClause => Contact.BaseFields.p_name + "= '{0}'";

        public override string Table
            => "person LEFT JOIN organisation ON person.p_organisationid = organisation.organisation_id";
    }
}