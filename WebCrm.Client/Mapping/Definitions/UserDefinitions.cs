using System;
using System.Collections.Generic;
using WebCrm.Client.Entities;

namespace WebCrm.Client.Mapping.Definitions
{
    internal sealed class UserDefinitions : DefinitionBase<User>
    {
        public override DataEntityType DataEntityType => DataEntityType.Users;

        public override IEnumerable<MappingDefinition<User>> Definitions
        {
            get
            {
                return new[]
                {
                    new MappingDefinition<User>
                    {
                        WebCrmField = User.BaseFields.cmuser_id.ToString(),
                        Property = dto => dto.WebCrmId
                    },
                    new MappingDefinition<User>
                    {
                        WebCrmField = User.BaseFields.u_email.ToString(),
                        Property = dto => dto.Email
                    },
                    new MappingDefinition<User>
                    {
                        WebCrmField = User.BaseFields.u_name.ToString(),
                        Property = dto => dto.Name
                    }
                };
            }
        }

        public override string Id => User.BaseFields.cmuser_id.ToString();

        public override string Table => "cmuser";

        public override string NameClause => "(u_name = '{0}')";

        public override Document.DocumentLinkTypes DocumentLinkType
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}