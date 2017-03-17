using System;
using System.Collections.Generic;
using WebCrm.Client.Entities;

namespace WebCrm.Client.Mapping.Definitions
{
    internal sealed class OrganisationRelationshipDefinitions : DefinitionBase<OrganisationRelation>
    {
        public override DataEntityType DataEntityType => DataEntityType.Relations;

        public override IEnumerable<MappingDefinition<OrganisationRelation>> Definitions
        {
            get
            {
                return new[]
                {
                    new MappingDefinition<OrganisationRelation>
                    {
                        Property = dto => dto.RelationshipCode,
                        WebCrmField = Relationship.BaseFields.r_code.ToString()
                    },
                    new MappingDefinition<OrganisationRelation>
                    {
                        Property = dto => dto.OrganisationId,
                        WebCrmField = Relationship.BaseFields.r_org1Id.ToString()
                    },
                    new MappingDefinition<OrganisationRelation>
                    {
                        Property = dto => dto.Organisation2Id,
                        WebCrmField = Relationship.BaseFields.r_org2Id.ToString()
                    },
                    new MappingDefinition<OrganisationRelation>
                    {
                        Property = dto => dto.RelationshipType,
                        WebCrmField = Relationship.BaseFields.r_type.ToString()
                    }
                };
            }
        }

        public override string Id => string.Empty;

        public override string Table => string.Empty;

        public override string NameClause
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override Document.DocumentLinkTypes DocumentLinkType => Document.DocumentLinkTypes.Company;
    }
}