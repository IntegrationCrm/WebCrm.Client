using WebCrm.Client.Services.ClientProxy;

namespace WebCrm.Client
{
    internal class Connection : IConnection
    {
        public WebCrmApiSoapClient Proxy { get; set; }

        public TicketHeader Ticket { get; set; }
    }
}