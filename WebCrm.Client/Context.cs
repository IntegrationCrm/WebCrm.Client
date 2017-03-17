using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;
using WebCrm.Client.Entities;
using WebCrm.Client.Mapping;
using WebCrm.Client.Mapping.Definitions;
using WebCrm.Client.Repository;
using WebCrm.Client.Services.ClientProxy;

namespace WebCrm.Client
{
    public static class Context
    {
        private static string _dbnCode;
        private static string _password;
        private static string _userId;

        internal static List<EntityMapperBase> Mappers { get; private set; }

        internal static FieldMetadata[] MetaData { get; private set; }

        public static void AddCustomDefinition<TCustomType, TBaseType>(
            IList<MappingDefinition<TCustomType>> definitions)
            where TCustomType : TBaseType, new()
            where TBaseType : Entity, new()
        {
            EntityMapper<TBaseType> type = GetMapperForType<TBaseType>();

            var customDefinition = new CustomDefinition<TCustomType>(
                type.Id,
                type.Table,
                type.DataEntityType,
                type.NameClause,
                definitions,
                type.DocumentLinkType);

            var customType = new EntityMapper<TCustomType>(MetaData, customDefinition);

            Mappers.Add(customType);
        }

        public static CustomMappingBuilder<TCustomType, Activity, Activity.CustomFields>
            CustomiseActivity
            <TCustomType>()
            where TCustomType : Activity, new()
        {
            return new CustomMappingBuilder<TCustomType, Activity, Activity.CustomFields>();
        }

        public static CustomMappingBuilder<TCustomType, Contact, Contact.CustomFields> CustomiseContact
            <TCustomType>()
            where TCustomType : Contact, new()
        {
            return new CustomMappingBuilder<TCustomType, Contact, Contact.CustomFields>();
        }

        public static CustomMappingBuilder<TCustomType, Opportunity, Opportunity.CustomFields>
            CustomiseOpportunity<TCustomType>()
            where TCustomType : Opportunity, new()
        {
            return new CustomMappingBuilder<TCustomType, Opportunity, Opportunity.CustomFields>();
        }

        public static CustomMappingBuilder<TCustomType, Organisation, Organisation.CustomFields>
            CustomiseOrganisation<TCustomType>()
            where TCustomType : Organisation, new()
        {
            return new CustomMappingBuilder<TCustomType, Organisation, Organisation.CustomFields>();
        }

        public static void Initialise(string dbnCode, string userId, string password)
        {
            _dbnCode = dbnCode;
            _userId = userId;
            _password = password;

            MetaData = MetaDataProvider.Create(CreateConnection()).GetMetaData();

            Mappers = new List<EntityMapperBase>
            {
                new EntityMapper<Contact>(
                    MetaData,
                    new ContactDefinitions()),
                new EntityMapper<Activity>(
                    MetaData,
                    new ActivityDefinitions()),
                new EntityMapper<Opportunity>(
                    MetaData,
                    new OpportunityDefinitions()),
                new EntityMapper<Organisation>(
                    MetaData,
                    new OrganisationDefinitions()),
                new EntityMapper<User>(
                    MetaData,
                    new UserDefinitions()),
                new EntityMapper<OrganisationRelation>(
                    MetaData,
                    new OrganisationRelationshipDefinitions())
            };
        }

        public static CustomMappingBuilder<TCustomType, TBaseType, TEnum> WithCustomMappingFor
            <TCustomType, TBaseType, TEnum>()
            where TCustomType : TBaseType, new()
            where TBaseType : Entity, new()
        {
            return new CustomMappingBuilder<TCustomType, TBaseType, TEnum>();
        }

        internal static IConnection CreateConnection()
        {
            WebCrmApiSoapClient proxy = CreateProxy();

            TicketHeader ticket = Connect(_dbnCode, _userId, _password, proxy);

            return new Connection { Proxy = proxy, Ticket = ticket };
        }

        internal static EntityMapper<T> GetMapperForType<T>()
            where T : Entity, new()
        {
            EntityMapperBase mapper = Mappers.FirstOrDefault(c => typeof(T) == c.Type);

            return (EntityMapper<T>)mapper;
        }

        private static TicketHeader Connect(string dbnCode, string userId, string password, WebCrmApiSoapClient proxy)
        {
            ErrorStatus errorStatus;
            TicketHeader ticket = proxy.Authenticate(
                dbnCode,
                userId,
                password,
                out errorStatus);
            if (errorStatus.Code != 0)
            {
                throw new Exception(
                    "Cannot connect to the web services, code: " + errorStatus.Code + ", reason: " +
                    errorStatus.Message);
            }

            return ticket;
        }

        private static WebCrmApiSoapClient CreateProxy()
        {
            Binding binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport)
            {
                AllowCookies = true,
                MaxReceivedMessageSize = 20000000,
                MaxBufferSize = 20000000,
                MaxBufferPoolSize = 20000000,
                ReaderQuotas = new XmlDictionaryReaderQuotas
                {
                    MaxDepth = 32,
                    MaxArrayLength = 200000000,
                    MaxStringContentLength = 200000000
                }
            };

            var endpoint = new EndpointAddress("https://webcrmapi5.b2bsys.net/WebCrmApi.asmx");
            return new WebCrmApiSoapClient(binding, endpoint);
        }
    }
}