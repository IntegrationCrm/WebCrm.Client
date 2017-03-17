// ReSharper disable InconsistentNaming
#pragma warning disable SA1300 // Element must begin with upper-case letter
using WebCrm.Client.Repository;

namespace WebCrm.Client.Entities
{
    public class User : Entity, IWebCrmUpdatable, IWebCrmQueryable, ILogable
    {
        internal enum BaseFields
        {
            cmuser_id,
            u_email,
            u_name
        }

        public string Email { get; set; }

        public string Log { get; set; }

        public string Name { get; set; }

        public long OrganisationId { get; set; }

        public long WebCrmId { get; set; }
    }
}