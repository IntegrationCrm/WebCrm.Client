// ReSharper disable InconsistentNaming
#pragma warning disable SA1300 // Element must begin with upper-case letter
using WebCrm.Client.Repository;

namespace WebCrm.Client.Entities
{
    public class Contact : Entity, IWebCrmQueryable, IWebCrmUpdatable, ILogable
    {
        public enum CustomFields
        {
            p_pcust5,
            p_pcust13,
            p_pcust4,
            p_pcust10,
            p_pcust6,
            p_pcust3,
            p_pcust11,
            p_pcust8,
            p_pcust9,
            p_pcust1,
            p_pcust7,
            p_pcust12
        }

        public enum StatusEnum
        {
            Active = 0,
            Resigned = 1,
            Other = 2
        }

        internal enum BaseFields
        {
            p_mobiletel,
            organisation_id,
            p_dirtel,
            p_email,
            p_firstname,
            p_lastname,
            p_name,
            p_status,
            p_title,
            person_id
        }

        public string CompanyType { get; set; }

        public string Division { get; set; }

        public string DivisionDescription { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string FullName { get; set; }

        public string JobTitle { get; set; }

        public string LastName { get; set; }

        public string Log { get; set; }

        public string Mobile_telephone { get; set; }

        public long OrganisationId { get; set; }

        public string OrganisationName { get; set; }

        public string OrganisationStatus { get; set; }

        public long ResponsibleUser { get; set; }

        public string Status { get; set; }

        public string Telephone { get; set; }

        public long WebCrmId { get; set; }
    }
}