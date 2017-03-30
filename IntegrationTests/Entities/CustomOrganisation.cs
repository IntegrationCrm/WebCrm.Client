using WebCrm.Client.Entities;

namespace IntegrationTests.Entities
{
    public class CustomOrganisation : Organisation
    {
        public string CompanyType1 { get; set; }

        public string CompanyType1Description { get; set; }

        public string CompanyType2 { get; set; }

        public string CompanyType2Description { get; set; }

        public string CompanyType3 { get; set; }

        public string CompanyType3Description { get; set; }

        public string ConsignmentStock { get; set; }
    }
}