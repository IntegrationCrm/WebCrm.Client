using System.Collections.Generic;
using WebCrm.Client.Entities;

namespace WebCrm.Client.Mapping.Definitions
{
    internal sealed class OrganisationDefinitions : DefinitionBase<Organisation>
    {
        public override DataEntityType DataEntityType => DataEntityType.Organisations;

        public override IEnumerable<MappingDefinition<Organisation>> Definitions
        {
            get
            {
                return new[]
                {
                    new MappingDefinition<Organisation>
                    {
                        Property = c => c.SiteName,
                        WebCrmField = Opportunity.BaseFields.o_divisionname.ToString()
                    },
                    new LookUpMappingDefinition<Organisation>
                    {
                        Property = c => c.Division,
                        WebCrmField = Opportunity.BaseFields.o_territory.ToString(),
                        DescriptionProperty = dto => dto.DivisionDescription
                    },
                    new MappingDefinition<Organisation>
                    {
                        Property = c => c.Name,
                        WebCrmField = Organisation.BaseFields.o_organisation.ToString()
                    },
                    new MappingDefinition<Organisation>
                    {
                        Property = c => c.WebCrmId,
                        WebCrmField = Opportunity.BaseFields.organisation_id.ToString()
                    },
                    new MappingDefinition<Organisation>
                    {
                        Property = dto => dto.Type,
                        WebCrmField = Organisation.BaseFields.o_type.ToString()
                    },
                    new MappingDefinition<Organisation>
                    {
                        Property = dto => dto.Telephone,
                        WebCrmField = Organisation.BaseFields.o_telephone.ToString()
                    },
                    new MappingDefinition<Organisation>
                    {
                        Property = dto => dto.Status,
                        WebCrmField = Organisation.BaseFields.o_status.ToString()
                    },
                    new MappingDefinition<Organisation>
                    {
                        Property = dto => dto.Responsible,
                        WebCrmField = Organisation.BaseFields.o_owner.ToString()
                    }
                };
            }
        }

        public override Document.DocumentLinkTypes DocumentLinkType => Document.DocumentLinkTypes.Company;

        public override string Id => Opportunity.BaseFields.organisation_id.ToString();

        public override string NameClause => Organisation.BaseFields.o_organisation + " = '{0}'";

        public override string Table => "organisation";
    }
}