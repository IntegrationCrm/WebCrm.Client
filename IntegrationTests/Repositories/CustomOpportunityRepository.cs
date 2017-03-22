using IntegrationTests.Opportunity;
using WebCrm.Client.Repository;

namespace IntegrationTests.Repositories
{
    public class CustomOpportunityRepository : CustomRepository<CustomOpportunity, WebCrm.Client.Entities.Opportunity>
    {
    }
}