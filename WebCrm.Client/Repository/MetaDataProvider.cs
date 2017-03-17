namespace WebCrm.Client.Repository
{
    internal sealed class MetaDataProvider
    {
        private readonly IConnection _connection;

        public MetaDataProvider(IConnection connection)
        {
            _connection = connection;
        }

        public static MetaDataProvider Create(IConnection connection)
        {
            return new MetaDataProvider(connection);
        }

        public FieldMetadata[] GetMetaData()
        {
            ReadAllFieldsDescriptionResult result = _connection.Proxy.ReturnAllFieldDescription(_connection.Ticket);

            return result.MetadataArray;
        }
    }
}