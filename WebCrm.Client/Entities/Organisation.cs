// ReSharper disable InconsistentNaming
#pragma warning disable SA1300 // Element must begin with upper-case letter

using WebCrm.Client.Repository;

namespace WebCrm.Client.Entities
{
    public class Organisation : Entity, IWebCrmQueryable, IWebCrmUpdatable, ILogable
    {
        public enum CustomFields
        {
            o_custom1,

            o_custom2,

            o_custom3,

            o_custom13
        }

        internal enum BaseFields
        {
            o_organisation,
            o_status,
            o_telephone,
            o_type,
            o_owner
        }

        public string Division { get; set; }

        public string DivisionDescription { get; set; }

        public string Log { get; set; }

        public string Name { get; set; }

        public long OrganisationId
        {
            get { return WebCrmId; }
            set { WebCrmId = value; }
        }

        public long Responsible { get; set; }

        public string SiteName { get; set; }

        public string Status { get; set; }

        public string Telephone { get; set; }

        public string Type { get; set; }

        public long WebCrmId { get; set; }
    }
}