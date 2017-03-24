using IntegrationTests.Entities;
using WebCrm.Client.Repository;

namespace IntegrationTests.Contact
{
    public class CustomContactRepository : CustomRepository<CustomContact, WebCrm.Client.Entities.Contact>
    {
    }
}