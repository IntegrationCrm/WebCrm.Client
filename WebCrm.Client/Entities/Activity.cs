// ReSharper disable InconsistentNaming
#pragma warning disable SA1300 // Element must begin with upper-case letter
using System;
using WebCrm.Client.Repository;

namespace WebCrm.Client.Entities
{
    public class Activity : Entity, IWebCrmQueryable, IWebCrmUpdatable, ILogable
    {
        public enum BaseFields
        {
            a_action,

            a_assignedto,

            activity_id,

            a_date,

            a_description,

            a_history,

            a_opportunityid,

            a_organisationid,

            a_personid,

            a_status
        }

        public enum CustomFields
        {
            a_custom7
        }

        public enum StatusEnum
        {
            Planned = 0,
            Ongoing = 1,
            Complete = 2
        }

        public string Action { get; set; }

        public long AssignedTo { get; set; }

        public long ContactId { get; set; }

        public DateTime? Date
        {
            get
            {
                if (DateRaw == null)
                {
                    return null;
                }

                if (DateRaw.Length == 8)
                {
                    int year = int.Parse(DateRaw.Substring(0, 4));
                    int month = int.Parse(DateRaw.Substring(4, 2));
                    int day = int.Parse(DateRaw.Substring(6, 2));
                    return new DateTime(year, month, day);
                }

                DateTime dateResult;

                bool result = DateTime.TryParse(DateRaw, out dateResult);

                if (result)
                {
                    return dateResult;
                }

                return null;
            }

            set
            {
                if (value.HasValue)
                {
                    DateRaw = value.Value.ToString("yyyyMMdd HH:mm:ss");
                }
                else
                {
                    DateRaw = null;
                }
            }
        }

        public string DateRaw { get; set; }

        // Mapped fields
        public string Description { get; set; }

        public string Log { get; set; }

        public long OpportunityId { get; set; }

        public long OrganisationId { get; set; }

        public string Status { get; set; }

        public long WebCrmId { get; set; }
    }
}