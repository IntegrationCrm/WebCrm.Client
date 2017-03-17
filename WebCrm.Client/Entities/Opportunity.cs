// ReSharper disable InconsistentNaming
#pragma warning disable SA1300 // Element must begin with upper-case letter
using System;
using WebCrm.Client.Repository;

namespace WebCrm.Client.Entities
{
    public class Opportunity : Entity, IWebCrmQueryable, IWebCrmUpdatable, ILogable
    {
        public enum CustomFields
        {
            op_custom9,
            op_pcust1,
            op_pcust14
        }

        internal enum BaseFields
        {
            o_divisionname,

            o_territory,

            op_currency,

            op_description,

            op_history,

            op_level,

            op_leveltext,

            op_lost1,

            op_lost2,

            op_lost3,

            op_number,

            op_orderdate,

            op_ordervalue,

            op_percent,

            op_personid,

            opportunity_id,

            organisation_id
        }

        public static string OpNumberAuto { get; } = "-1";

        public string CompanyDivision { get; set; }

        public string CompanyDivisionDescription { get; set; }

        public string CompanyName { get; set; }

        public string Competitor { get; set; }

        public string Currency { get; set; }

        public string CurrencyDescription { get; set; }

        public string Description { get; set; }

        public string Explanation { get; set; }

        public string KeyContactEmailAddress { get; set; }

        public long KeyContactId { get; set; }

        public string KeyContactJobTitle { get; set; }

        public string KeyContactName { get; set; }

        public string Level { get; set; }

        public string LevelDescription { get; set; }

        public string LevelText { get; set; }

        public string Log { get; set; }

        public string LostReason { get; set; }

        public string OpportunityNumber { get; set; }

        public DateTime? OrderDate
        {
            get
            {
                if (OrderDateRaw == null)
                {
                    return null;
                }

                if (OrderDateRaw.Length == 8)
                {
                    int year = int.Parse(OrderDateRaw.Substring(0, 4));
                    int month = int.Parse(OrderDateRaw.Substring(4, 2));
                    int day = int.Parse(OrderDateRaw.Substring(6, 2));
                    return new DateTime(year, month, day);
                }

                DateTime dateResult;

                bool result = DateTime.TryParse(OrderDateRaw, out dateResult);

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
                    OrderDateRaw = value.Value.ToString("yyyyMMdd");
                }
                else
                {
                    OrderDateRaw = null;
                }
            }
        }

        public string OrderDateRaw { get; set; }

        public long OrderValue { get; set; }

        public long OrganisationId { get; set; }

        public string SiteName { get; set; }

        public long WebCrmId { get; set; }

        public string WinProbability { get; set; }

        public string WinProbabilityDescription { get; set; }

        public static class LevelConstants
        {
            public static string Lost { get; } = "14";

            public static string Won { get; } = "13";
        }

        public static class TypeConstants
        {
            public static string Trial { get; } = "01";
        }
    }
}