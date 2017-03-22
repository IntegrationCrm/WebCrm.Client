namespace IntegrationTests.Contact
{
    public class CustomContact : WebCrm.Client.Entities.Contact
    {
        public string ConsignmentStockRaw { get; set; }

        public string EmailConfirmedRaw { get; set; }
    }
}