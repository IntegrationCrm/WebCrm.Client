// ReSharper disable InconsistentNaming
#pragma warning disable SA1300 // Element must begin with upper-case letter

namespace WebCrm.Client.Entities
{
    public static class Relationship
    {
        public enum BaseFields
        {
            r_code,

            r_org1Id,

            r_org2Id,

            r_type
        }

        public enum RelationshipType
        {
            PersonPerson = 1,
            OrganisationPerson = 2,
            OrganisationOrganisation = 3,
            LinkedOrganisations = 4
        }
    }
}