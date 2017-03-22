using System;
using System.Collections.Generic;
using WebCrm.Client.Entities;

namespace WebCrm.Client.Mapping.Definitions
{
    internal sealed class OpportunityDefinitions : DefinitionBase<Opportunity>
    {
        public override DataEntityType DataEntityType => DataEntityType.Opportunities;

        public override IEnumerable<MappingDefinition<Opportunity>> Definitions
        {
            get
            {
                return new[]
                {
                    new MappingDefinition<Opportunity>
                    {
                        Property = c => c.OrganisationId,
                        WebCrmField = Opportunity.BaseFields.organisation_id.ToString()
                    },
                    new MappingDefinition<Opportunity>
                    {
                        Property = dto => dto.WebCrmId,
                        WebCrmField = Opportunity.BaseFields.opportunity_id.ToString()
                    },
                    new LookUpMappingDefinition<Opportunity>
                    {
                        Property = c => c.Currency,
                        WebCrmField = Opportunity.BaseFields.op_currency.ToString(),
                        DescriptionProperty = c => c.CurrencyDescription
                    },
                    new MappingDefinition<Opportunity>
                    {
                        Property = c => c.OrderValue,
                        WebCrmField = Opportunity.BaseFields.op_ordervalue.ToString()
                    },
                    new MappingDefinition<Opportunity>
                    {
                        Property = c => c.Description,
                        WebCrmField = Opportunity.BaseFields.op_description.ToString()
                    },
                    new LookUpMappingDefinition<Opportunity>
                    {
                        Property = c => c.Level,
                        WebCrmField = Opportunity.BaseFields.op_level.ToString(),
                        DescriptionProperty = dto => dto.LevelDescription
                    },
                    new MappingDefinition<Opportunity>
                    {
                        Property = c => c.LevelText,
                        WebCrmField = Opportunity.BaseFields.op_leveltext.ToString()
                    },

                    // For some reason these are coming back from the API with the wrong level
                    new LookUpMappingDefinition<Opportunity>
                    {
                        Property = c => c.CompanyDivision,
                        WebCrmField = Opportunity.BaseFields.o_territory.ToString(),
                        DescriptionProperty = dto => dto.CompanyDivisionDescription
                    },
                    new MappingDefinition<Opportunity>
                    {
                        Property = c => c.SiteName,
                        WebCrmField = Opportunity.BaseFields.o_divisionname.ToString()
                    },
                    new MappingDefinition<Opportunity>
                    {
                        Property = c => c.OpportunityNumber,
                        WebCrmField = Opportunity.BaseFields.op_number.ToString()
                    },
                    new MappingDefinition<Opportunity>
                    {
                        Property = c => c.KeyContactName,
                        WebCrmField = Contact.BaseFields.p_name.ToString()
                    },
                    new MappingDefinition<Opportunity>
                    {
                        Property = c => c.KeyContactJobTitle,
                        WebCrmField = Contact.BaseFields.p_title.ToString()
                    },
                    new MappingDefinition<Opportunity>
                    {
                        Property = c => c.KeyContactEmailAddress,
                        WebCrmField = Contact.BaseFields.p_email.ToString()
                    },
                    new MappingDefinition<Opportunity>
                    {
                        Property = c => c.CompanyName,
                        WebCrmField = Client.Entities.Organisation.BaseFields.o_organisation.ToString()
                    },
                    new LookUpMappingDefinition<Opportunity>
                    {
                        Property = c => c.WinProbability,
                        WebCrmField = Opportunity.BaseFields.op_percent.ToString(),
                        DescriptionProperty = c => c.WinProbabilityDescription
                    },
                    new MappingDefinition<Opportunity>
                    {
                        Property = c => c.LostReason,
                        WebCrmField = Opportunity.BaseFields.op_lost1.ToString()
                    },
                    new MappingDefinition<Opportunity>
                    {
                        Property = dto => dto.Competitor,
                        WebCrmField = Opportunity.BaseFields.op_lost2.ToString()
                    },
                    new MappingDefinition<Opportunity>
                    {
                        Property = dto => dto.Explanation,
                        WebCrmField = Opportunity.BaseFields.op_lost3.ToString()
                    },
                    new MappingDefinition<Opportunity>
                    {
                        Property = dto => dto.OrderDateRaw,
                        WebCrmField = Opportunity.BaseFields.op_orderdate.ToString()
                    },
                    new MappingDefinition<Opportunity>
                    {
                        Property = dto => dto.KeyContactId,
                        WebCrmField = Opportunity.BaseFields.op_personid.ToString()
                    },
                    new MappingDefinition<Opportunity>
                    {
                        Property = dto => dto.Log,
                        WebCrmField = Opportunity.BaseFields.op_history.ToString()
                    }
                };
            }
        }

        public override string Id => Opportunity.BaseFields.opportunity_id.ToString();

        public override string NameClause => Opportunity.BaseFields.op_number + "= '{0}'";


        public override string Table
            =>
                "((( opportunity LEFT JOIN organisation ON opportunity.op_orgid = organisation.organisation_id ) LEFT JOIN person ON person.person_id = opportunity.op_personid ) ) "
        ;

        public override Document.DocumentLinkTypes DocumentLinkType => Document.DocumentLinkTypes.Delivery;
    }
}