using System;
using System.Collections.Generic;
using WebCrm.Client.Entities;

namespace WebCrm.Client.Mapping.Definitions
{
    internal sealed class ActivityDefinitions : DefinitionBase<Activity>
    {
        public override DataEntityType DataEntityType => DataEntityType.Activities;

        public override IEnumerable<MappingDefinition<Activity>> Definitions
        {
            get
            {
                return new List<MappingDefinition<Activity>>
                {
                    new MappingDefinition<Activity>
                    {
                        Property = dto => dto.Action,
                        WebCrmField = Activity.BaseFields.a_action.ToString()
                    },
                    new MappingDefinition<Activity>
                    {
                        Property = dto => dto.AssignedTo,
                        WebCrmField = Activity.BaseFields.a_assignedto.ToString()
                    },
                    new MappingDefinition<Activity>
                    {
                        Property = dto => dto.ContactId,
                        WebCrmField = Activity.BaseFields.a_personid.ToString()
                    },
                    new MappingDefinition<Activity>
                    {
                        Property = dto => dto.DateRaw,
                        WebCrmField = Activity.BaseFields.a_date.ToString()
                    },
                    new MappingDefinition<Activity>
                    {
                        Property = dto => dto.Status,
                        WebCrmField = Activity.BaseFields.a_status.ToString()
                    },
                    new MappingDefinition<Activity>
                    {
                        Property = dto => dto.Description,
                        WebCrmField = Activity.BaseFields.a_description.ToString()
                    },
                    new MappingDefinition<Activity>
                    {
                        Property = dto => dto.Log,
                        WebCrmField = Activity.BaseFields.a_history.ToString()
                    },
                    new MappingDefinition<Activity>
                    {
                        Property = dto => dto.OrganisationId,
                        WebCrmField = Activity.BaseFields.a_organisationid.ToString()
                    },
                    new MappingDefinition<Activity>
                    {
                        Property = dto => dto.WebCrmId,
                        WebCrmField = Activity.BaseFields.activity_id.ToString()
                    },
                    new MappingDefinition<Activity>
                    {
                        Property = dto => dto.OpportunityId,
                        WebCrmField = Activity.BaseFields.a_opportunityid.ToString()
                    }
                };
            }
        }

        public override Document.DocumentLinkTypes DocumentLinkType => Document.DocumentLinkTypes.Activity;

        public override string Id => Activity.BaseFields.activity_id.ToString();

        public override string NameClause
        {
            get { throw new NotImplementedException(); }
        }

        public override string Table => "activity";
    }
}