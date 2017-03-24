namespace IntegrationTests.Entities
{
    public class CustomOpportunity : WebCrm.Client.Entities.Opportunity
    {
        public string DeliveryAddress { get; set; }

        public string OpportunityType { get; set; }

        public string OpportunityTypeDescription { get; set; }

        public decimal PotentialAnnualRevenue { get; set; }
    }
}