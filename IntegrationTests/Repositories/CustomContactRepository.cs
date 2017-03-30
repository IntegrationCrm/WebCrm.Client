using IntegrationTests.Entities;
using WebCrm.Client.Repository;

namespace IntegrationTests.Repositories
{
    public class CustomContactRepository : CustomRepository<CustomContact, WebCrm.Client.Entities.Contact>
    {
    }
}