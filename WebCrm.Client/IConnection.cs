using WebCrm.Client.Services.ClientProxy;

namespace WebCrm.Client
{
    internal interface IConnection
    {
        WebCrmApiSoapClient Proxy { get; }

        TicketHeader Ticket { get; set; }
    }
}