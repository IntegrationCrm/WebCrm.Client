using WebCrm.Client.Repository;

namespace WebCrm.Client.Entities
{
    public class OrganisationRelation : Entity, IWebCrmUpdatable, IWebCrmQueryable, ILogable
    {
        public string Log { get; set; }

        public long Organisation2Id { get; set; }

        public long OrganisationId { get; set; }

        public string RelationshipCode { get; set; }

        public Relationship.RelationshipType RelationshipType { get; set; }

        long IWebCrmQueryable.WebCrmId { get; set; }
    }
}