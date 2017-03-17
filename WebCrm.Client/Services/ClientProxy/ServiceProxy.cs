using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace WebCrm.Client.Services.ClientProxy
{
    [DebuggerStepThrough]
    [GeneratedCode("System.ServiceModel", "4.0.0.0")]
    internal class WebCrmApiSoapClient : ClientBase<WebCrmApiSoap>, WebCrmApiSoap
    {
        internal WebCrmApiSoapClient(Binding binding, EndpointAddress remoteAddress)
            :
            base(binding, remoteAddress)
        {
        }

        public TicketHeader Authenticate(
            string dbnCode,
            string userName,
            string password,
            out ErrorStatus AuthenticateResult)
        {
            var inValue = new AuthenticateRequest();
            inValue.dbnCode = dbnCode;
            inValue.userName = userName;
            inValue.password = password;
            AuthenticateResponse retVal = ((WebCrmApiSoap)this).Authenticate(inValue);
            AuthenticateResult = retVal.AuthenticateResult;
            return retVal.TicketHeader;
        }

        public Task<AuthenticateResponse> AuthenticateAsync(string dbnCode, string userName, string password)
        {
            var inValue = new AuthenticateRequest();
            inValue.dbnCode = dbnCode;
            inValue.userName = userName;
            inValue.password = password;
            return ((WebCrmApiSoap)this).AuthenticateAsync(inValue);
        }

        public ErrorStatus ChangeOrganisationForOpportunity(
            TicketHeader TicketHeader,
            long opportunityID,
            long organisationID)
        {
            var inValue = new ChangeOrganisationForOpportunityRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.opportunityID = opportunityID;
            inValue.organisationID = organisationID;
            ChangeOrganisationForOpportunityResponse retVal =
                ((WebCrmApiSoap)this).ChangeOrganisationForOpportunity(inValue);
            return retVal.ChangeOrganisationForOpportunityResult;
        }

        public Task<ChangeOrganisationForOpportunityResponse> ChangeOrganisationForOpportunityAsync(
            TicketHeader TicketHeader,
            long opportunityID,
            long organisationID)
        {
            var inValue = new ChangeOrganisationForOpportunityRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.opportunityID = opportunityID;
            inValue.organisationID = organisationID;
            return ((WebCrmApiSoap)this).ChangeOrganisationForOpportunityAsync(inValue);
        }

        public DeleteLinkedDataResult DeleteLinkedData(TicketHeader TicketHeader, DataEntityType entityType)
        {
            var inValue = new DeleteLinkedDataRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            DeleteLinkedDataResponse retVal = ((WebCrmApiSoap)this).DeleteLinkedData(inValue);
            return retVal.DeleteLinkedDataResult;
        }

        public Task<DeleteLinkedDataResponse> DeleteLinkedDataAsync(
            TicketHeader TicketHeader,
            DataEntityType entityType)
        {
            var inValue = new DeleteLinkedDataRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            return ((WebCrmApiSoap)this).DeleteLinkedDataAsync(inValue);
        }

        public DeletePossibleQuotationsResult DeletePossibleQuotations(TicketHeader TicketHeader)
        {
            var inValue = new DeletePossibleQuotationsRequest();
            inValue.TicketHeader = TicketHeader;
            DeletePossibleQuotationsResponse retVal = ((WebCrmApiSoap)this).DeletePossibleQuotations(inValue);
            return retVal.DeletePossibleQuotationsResult;
        }

        public Task<DeletePossibleQuotationsResponse> DeletePossibleQuotationsAsync(TicketHeader TicketHeader)
        {
            var inValue = new DeletePossibleQuotationsRequest();
            inValue.TicketHeader = TicketHeader;
            return ((WebCrmApiSoap)this).DeletePossibleQuotationsAsync(inValue);
        }

        public DeleteQuotationResult DeleteQuotation(TicketHeader TicketHeader, long opportunityId, long productId)
        {
            var inValue = new DeleteQuotationRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.opportunityId = opportunityId;
            inValue.productId = productId;
            DeleteQuotationResponse retVal = ((WebCrmApiSoap)this).DeleteQuotation(inValue);
            return retVal.DeleteQuotationResult;
        }

        public Task<DeleteQuotationResponse> DeleteQuotationAsync(
            TicketHeader TicketHeader,
            long opportunityId,
            long productId)
        {
            var inValue = new DeleteQuotationRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.opportunityId = opportunityId;
            inValue.productId = productId;
            return ((WebCrmApiSoap)this).DeleteQuotationAsync(inValue);
        }

        public ErrorStatus EndSession(TicketHeader TicketHeader)
        {
            var inValue = new EndSessionRequest();
            inValue.TicketHeader = TicketHeader;
            EndSessionResponse retVal = ((WebCrmApiSoap)this).EndSession(inValue);
            return retVal.EndSessionResult;
        }

        public Task<EndSessionResponse> EndSessionAsync(TicketHeader TicketHeader)
        {
            var inValue = new EndSessionRequest();
            inValue.TicketHeader = TicketHeader;
            return ((WebCrmApiSoap)this).EndSessionAsync(inValue);
        }

        public IpAddressResult GetIpInfo(TicketHeader TicketHeader)
        {
            var inValue = new GetIpInfoRequest();
            inValue.TicketHeader = TicketHeader;
            GetIpInfoResponse retVal = ((WebCrmApiSoap)this).GetIpInfo(inValue);
            return retVal.GetIpInfoResult;
        }

        public Task<GetIpInfoResponse> GetIpInfoAsync(TicketHeader TicketHeader)
        {
            var inValue = new GetIpInfoRequest();
            inValue.TicketHeader = TicketHeader;
            return ((WebCrmApiSoap)this).GetIpInfoAsync(inValue);
        }

        public QuickSearchResult QuickSearch(
            string dbnCode,
            string userName,
            string password,
            QuickSearchMode searchMode,
            string searchValue,
            long userID,
            SearchOptions options)
        {
            return Channel.QuickSearch(dbnCode, userName, password, searchMode, searchValue, userID, options);
        }

        public Task<QuickSearchResult> QuickSearchAsync(
            string dbnCode,
            string userName,
            string password,
            QuickSearchMode searchMode,
            string searchValue,
            long userID,
            SearchOptions options)
        {
            return Channel.QuickSearchAsync(dbnCode, userName, password, searchMode, searchValue, userID, options);
        }

        public ReadDocumentDataResult ReadDocument(TicketHeader TicketHeader, long documentId)
        {
            var inValue = new ReadDocumentRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.documentId = documentId;
            ReadDocumentResponse retVal = ((WebCrmApiSoap)this).ReadDocument(inValue);
            return retVal.ReadDocumentResult;
        }

        public Task<ReadDocumentResponse> ReadDocumentAsync(TicketHeader TicketHeader, long documentId)
        {
            var inValue = new ReadDocumentRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.documentId = documentId;
            return ((WebCrmApiSoap)this).ReadDocumentAsync(inValue);
        }

        public WebCrmDataCollection ReadFromWebcrmByDates(
            TicketHeader TicketHeader,
            DataEntityType entityType,
            DateTime fromDateTime,
            DateTime toDateTime,
            DateFilterType dateMode)
        {
            var inValue = new ReadFromWebcrmByDatesRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            inValue.fromDateTime = fromDateTime;
            inValue.toDateTime = toDateTime;
            inValue.dateMode = dateMode;
            ReadFromWebcrmByDatesResponse retVal = ((WebCrmApiSoap)this).ReadFromWebcrmByDates(inValue);
            return retVal.ReadFromWebcrmByDatesResult;
        }

        public Task<ReadFromWebcrmByDatesResponse> ReadFromWebcrmByDatesAsync(
            TicketHeader TicketHeader,
            DataEntityType entityType,
            DateTime fromDateTime,
            DateTime toDateTime,
            DateFilterType dateMode)
        {
            var inValue = new ReadFromWebcrmByDatesRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            inValue.fromDateTime = fromDateTime;
            inValue.toDateTime = toDateTime;
            inValue.dateMode = dateMode;
            return ((WebCrmApiSoap)this).ReadFromWebcrmByDatesAsync(inValue);
        }

        public WebCrmDataCollection ReadFromWebcrmByDatesDirect(
            TicketHeader TicketHeader,
            DataEntityType entityType,
            DateTime fromDateTime,
            DateTime toDateTime,
            DateFilterType dateMode)
        {
            var inValue = new ReadFromWebcrmByDatesDirectRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            inValue.fromDateTime = fromDateTime;
            inValue.toDateTime = toDateTime;
            inValue.dateMode = dateMode;
            ReadFromWebcrmByDatesDirectResponse retVal = ((WebCrmApiSoap)this).ReadFromWebcrmByDatesDirect(inValue);
            return retVal.ReadFromWebcrmByDatesDirectResult;
        }

        public Task<ReadFromWebcrmByDatesDirectResponse> ReadFromWebcrmByDatesDirectAsync(
            TicketHeader TicketHeader,
            DataEntityType entityType,
            DateTime fromDateTime,
            DateTime toDateTime,
            DateFilterType dateMode)
        {
            var inValue = new ReadFromWebcrmByDatesDirectRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            inValue.fromDateTime = fromDateTime;
            inValue.toDateTime = toDateTime;
            inValue.dateMode = dateMode;
            return ((WebCrmApiSoap)this).ReadFromWebcrmByDatesDirectAsync(inValue);
        }

        public WebCrmDataCollection ReadFromWebcrmById(
            TicketHeader TicketHeader,
            DataEntityType entityType,
            long organisationID,
            long recordID)
        {
            var inValue = new ReadFromWebcrmByIdRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            inValue.organisationID = organisationID;
            inValue.recordID = recordID;
            ReadFromWebcrmByIdResponse retVal = ((WebCrmApiSoap)this).ReadFromWebcrmById(inValue);
            return retVal.ReadFromWebcrmByIdResult;
        }

        public Task<ReadFromWebcrmByIdResponse> ReadFromWebcrmByIdAsync(
            TicketHeader TicketHeader,
            DataEntityType entityType,
            long organisationID,
            long recordID)
        {
            var inValue = new ReadFromWebcrmByIdRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            inValue.organisationID = organisationID;
            inValue.recordID = recordID;
            return ((WebCrmApiSoap)this).ReadFromWebcrmByIdAsync(inValue);
        }

        public WebCrmDataCollection ReadFromWebcrmByIdDirect(
            TicketHeader TicketHeader,
            DataEntityType entityType,
            long organisationID,
            long recordID)
        {
            var inValue = new ReadFromWebcrmByIdDirectRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            inValue.organisationID = organisationID;
            inValue.recordID = recordID;
            ReadFromWebcrmByIdDirectResponse retVal = ((WebCrmApiSoap)this).ReadFromWebcrmByIdDirect(inValue);
            return retVal.ReadFromWebcrmByIdDirectResult;
        }

        public Task<ReadFromWebcrmByIdDirectResponse> ReadFromWebcrmByIdDirectAsync(
            TicketHeader TicketHeader,
            DataEntityType entityType,
            long organisationID,
            long recordID)
        {
            var inValue = new ReadFromWebcrmByIdDirectRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            inValue.organisationID = organisationID;
            inValue.recordID = recordID;
            return ((WebCrmApiSoap)this).ReadFromWebcrmByIdDirectAsync(inValue);
        }

        public ReadLinkedDataResult ReadLinkedData(TicketHeader TicketHeader, DataEntityType entityType)
        {
            var inValue = new ReadLinkedDataRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            ReadLinkedDataResponse retVal = ((WebCrmApiSoap)this).ReadLinkedData(inValue);
            return retVal.ReadLinkedDataResult;
        }

        public Task<ReadLinkedDataResponse> ReadLinkedDataAsync(TicketHeader TicketHeader, DataEntityType entityType)
        {
            var inValue = new ReadLinkedDataRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            return ((WebCrmApiSoap)this).ReadLinkedDataAsync(inValue);
        }

        public ReadPossibleQuotationsResult ReadPossibleQuotations(TicketHeader TicketHeader)
        {
            var inValue = new ReadPossibleQuotationsRequest();
            inValue.TicketHeader = TicketHeader;
            ReadPossibleQuotationsResponse retVal = ((WebCrmApiSoap)this).ReadPossibleQuotations(inValue);
            return retVal.ReadPossibleQuotationsResult;
        }

        public Task<ReadPossibleQuotationsResponse> ReadPossibleQuotationsAsync(TicketHeader TicketHeader)
        {
            var inValue = new ReadPossibleQuotationsRequest();
            inValue.TicketHeader = TicketHeader;
            return ((WebCrmApiSoap)this).ReadPossibleQuotationsAsync(inValue);
        }

        public ReadQuotationLinesResult ReadQuotationLines(TicketHeader TicketHeader, long opportunityId)
        {
            var inValue = new ReadQuotationLinesRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.opportunityId = opportunityId;
            ReadQuotationLinesResponse retVal = ((WebCrmApiSoap)this).ReadQuotationLines(inValue);
            return retVal.ReadQuotationLinesResult;
        }

        public Task<ReadQuotationLinesResponse> ReadQuotationLinesAsync(TicketHeader TicketHeader, long opportunityId)
        {
            var inValue = new ReadQuotationLinesRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.opportunityId = opportunityId;
            return ((WebCrmApiSoap)this).ReadQuotationLinesAsync(inValue);
        }

        public RetrieveByQueryResult RetrieveByQuery(
            TicketHeader TicketHeader,
            string selectFields,
            string tables,
            string whereClause,
            string orderBy)
        {
            var inValue = new RetrieveByQueryRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.selectFields = selectFields;
            inValue.tables = tables;
            inValue.whereClause = whereClause;
            inValue.orderBy = orderBy;
            RetrieveByQueryResponse retVal = ((WebCrmApiSoap)this).RetrieveByQuery(inValue);
            return retVal.RetrieveByQueryResult;
        }

        public Task<RetrieveByQueryResponse> RetrieveByQueryAsync(
            TicketHeader TicketHeader,
            string selectFields,
            string tables,
            string whereClause,
            string orderBy)
        {
            var inValue = new RetrieveByQueryRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.selectFields = selectFields;
            inValue.tables = tables;
            inValue.whereClause = whereClause;
            inValue.orderBy = orderBy;
            return ((WebCrmApiSoap)this).RetrieveByQueryAsync(inValue);
        }

        public ReadAllFieldsDescriptionResult ReturnAllFieldDescription(TicketHeader TicketHeader)
        {
            var inValue = new ReturnAllFieldDescriptionRequest();
            inValue.TicketHeader = TicketHeader;
            ReturnAllFieldDescriptionResponse retVal = ((WebCrmApiSoap)this).ReturnAllFieldDescription(inValue);
            return retVal.ReturnAllFieldDescriptionResult;
        }

        public Task<ReturnAllFieldDescriptionResponse> ReturnAllFieldDescriptionAsync(TicketHeader TicketHeader)
        {
            var inValue = new ReturnAllFieldDescriptionRequest();
            inValue.TicketHeader = TicketHeader;
            return ((WebCrmApiSoap)this).ReturnAllFieldDescriptionAsync(inValue);
        }

        public ReturnAllUsersResult ReturnAllUsers(TicketHeader TicketHeader)
        {
            var inValue = new ReturnAllUsersRequest();
            inValue.TicketHeader = TicketHeader;
            ReturnAllUsersResponse retVal = ((WebCrmApiSoap)this).ReturnAllUsers(inValue);
            return retVal.ReturnAllUsersResult;
        }

        public Task<ReturnAllUsersResponse> ReturnAllUsersAsync(TicketHeader TicketHeader)
        {
            var inValue = new ReturnAllUsersRequest();
            inValue.TicketHeader = TicketHeader;
            return ((WebCrmApiSoap)this).ReturnAllUsersAsync(inValue);
        }

        public ReadFieldDescriptionResult ReturnFieldDescription(
            TicketHeader TicketHeader,
            DataEntityType entityType,
            long fieldID)
        {
            var inValue = new ReturnFieldDescriptionRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            inValue.fieldID = fieldID;
            ReturnFieldDescriptionResponse retVal = ((WebCrmApiSoap)this).ReturnFieldDescription(inValue);
            return retVal.ReturnFieldDescriptionResult;
        }

        public Task<ReturnFieldDescriptionResponse> ReturnFieldDescriptionAsync(
            TicketHeader TicketHeader,
            DataEntityType entityType,
            long fieldID)
        {
            var inValue = new ReturnFieldDescriptionRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            inValue.fieldID = fieldID;
            return ((WebCrmApiSoap)this).ReturnFieldDescriptionAsync(inValue);
        }

        public ReturnUserDetailsResult ReturnUserDetails(TicketHeader TicketHeader, string loginName)
        {
            var inValue = new ReturnUserDetailsRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.loginName = loginName;
            ReturnUserDetailsResponse retVal = ((WebCrmApiSoap)this).ReturnUserDetails(inValue);
            return retVal.ReturnUserDetailsResult;
        }

        public Task<ReturnUserDetailsResponse> ReturnUserDetailsAsync(TicketHeader TicketHeader, string loginName)
        {
            var inValue = new ReturnUserDetailsRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.loginName = loginName;
            return ((WebCrmApiSoap)this).ReturnUserDetailsAsync(inValue);
        }

        public SaveDocumentDataResult SaveDocument(TicketHeader TicketHeader, WebCrmDocumentData document, byte[] file)
        {
            var inValue = new SaveDocumentRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.document = document;
            inValue.file = file;
            SaveDocumentResponse retVal = ((WebCrmApiSoap)this).SaveDocument(inValue);
            return retVal.SaveDocumentResult;
        }

        public Task<SaveDocumentResponse> SaveDocumentAsync(
            TicketHeader TicketHeader,
            WebCrmDocumentData document,
            byte[] file)
        {
            var inValue = new SaveDocumentRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.document = document;
            inValue.file = file;
            return ((WebCrmApiSoap)this).SaveDocumentAsync(inValue);
        }

        public SearchOpportunityResult SearchDelivery(
            TicketHeader TicketHeader,
            int searchFieldNumber,
            string searchValue,
            long organisationID,
            SearchOptions options)
        {
            var inValue = new SearchDeliveryRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.searchFieldNumber = searchFieldNumber;
            inValue.searchValue = searchValue;
            inValue.organisationID = organisationID;
            inValue.options = options;
            SearchDeliveryResponse retVal = ((WebCrmApiSoap)this).SearchDelivery(inValue);
            return retVal.SearchDeliveryResult;
        }

        public Task<SearchDeliveryResponse> SearchDeliveryAsync(
            TicketHeader TicketHeader,
            int searchFieldNumber,
            string searchValue,
            long organisationID,
            SearchOptions options)
        {
            var inValue = new SearchDeliveryRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.searchFieldNumber = searchFieldNumber;
            inValue.searchValue = searchValue;
            inValue.organisationID = organisationID;
            inValue.options = options;
            return ((WebCrmApiSoap)this).SearchDeliveryAsync(inValue);
        }

        public SearchOpportunityResult SearchOpportunity(
            TicketHeader TicketHeader,
            int searchFieldNumber,
            string searchValue,
            long organisationID,
            SearchOptions options)
        {
            var inValue = new SearchOpportunityRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.searchFieldNumber = searchFieldNumber;
            inValue.searchValue = searchValue;
            inValue.organisationID = organisationID;
            inValue.options = options;
            SearchOpportunityResponse retVal = ((WebCrmApiSoap)this).SearchOpportunity(inValue);
            return retVal.SearchOpportunityResult;
        }

        public Task<SearchOpportunityResponse> SearchOpportunityAsync(
            TicketHeader TicketHeader,
            int searchFieldNumber,
            string searchValue,
            long organisationID,
            SearchOptions options)
        {
            var inValue = new SearchOpportunityRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.searchFieldNumber = searchFieldNumber;
            inValue.searchValue = searchValue;
            inValue.organisationID = organisationID;
            inValue.options = options;
            return ((WebCrmApiSoap)this).SearchOpportunityAsync(inValue);
        }

        public SearchOrganisationResult SearchOrganisation(
            TicketHeader TicketHeader,
            int searchFieldNumber,
            string searchValue,
            string postcode,
            SearchOptions options)
        {
            var inValue = new SearchOrganisationRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.searchFieldNumber = searchFieldNumber;
            inValue.searchValue = searchValue;
            inValue.postcode = postcode;
            inValue.options = options;
            SearchOrganisationResponse retVal = ((WebCrmApiSoap)this).SearchOrganisation(inValue);
            return retVal.SearchOrganisationResult;
        }

        public Task<SearchOrganisationResponse> SearchOrganisationAsync(
            TicketHeader TicketHeader,
            int searchFieldNumber,
            string searchValue,
            string postcode,
            SearchOptions options)
        {
            var inValue = new SearchOrganisationRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.searchFieldNumber = searchFieldNumber;
            inValue.searchValue = searchValue;
            inValue.postcode = postcode;
            inValue.options = options;
            return ((WebCrmApiSoap)this).SearchOrganisationAsync(inValue);
        }

        public SearchPersonResult SearchPerson(
            TicketHeader TicketHeader,
            int searchFieldNumber,
            string searchValue,
            long organisationID,
            SearchOptions options)
        {
            var inValue = new SearchPersonRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.searchFieldNumber = searchFieldNumber;
            inValue.searchValue = searchValue;
            inValue.organisationID = organisationID;
            inValue.options = options;
            SearchPersonResponse retVal = ((WebCrmApiSoap)this).SearchPerson(inValue);
            return retVal.SearchPersonResult;
        }

        public Task<SearchPersonResponse> SearchPersonAsync(
            TicketHeader TicketHeader,
            int searchFieldNumber,
            string searchValue,
            long organisationID,
            SearchOptions options)
        {
            var inValue = new SearchPersonRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.searchFieldNumber = searchFieldNumber;
            inValue.searchValue = searchValue;
            inValue.organisationID = organisationID;
            inValue.options = options;
            return ((WebCrmApiSoap)this).SearchPersonAsync(inValue);
        }

        public SearchQuotationDataResult SearchQuotationData(TicketHeader TicketHeader, long opportunityId)
        {
            var inValue = new SearchQuotationDataRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.opportunityId = opportunityId;
            SearchQuotationDataResponse retVal = ((WebCrmApiSoap)this).SearchQuotationData(inValue);
            return retVal.SearchQuotationDataResult;
        }

        public Task<SearchQuotationDataResponse> SearchQuotationDataAsync(TicketHeader TicketHeader, long opportunityId)
        {
            var inValue = new SearchQuotationDataRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.opportunityId = opportunityId;
            return ((WebCrmApiSoap)this).SearchQuotationDataAsync(inValue);
        }

        public SearchQuotationIdResult SearchQuotationID(TicketHeader TicketHeader, long opportunityId)
        {
            var inValue = new SearchQuotationIDRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.opportunityId = opportunityId;
            SearchQuotationIDResponse retVal = ((WebCrmApiSoap)this).SearchQuotationID(inValue);
            return retVal.SearchQuotationIDResult;
        }

        public Task<SearchQuotationIDResponse> SearchQuotationIDAsync(TicketHeader TicketHeader, long opportunityId)
        {
            var inValue = new SearchQuotationIDRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.opportunityId = opportunityId;
            return ((WebCrmApiSoap)this).SearchQuotationIDAsync(inValue);
        }

        public UpdateLinkedDataResult UpdateLinkedData(
            TicketHeader TicketHeader,
            DataEntityType entityType,
            string dataList)
        {
            var inValue = new UpdateLinkedDataRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            inValue.dataList = dataList;
            UpdateLinkedDataResponse retVal = ((WebCrmApiSoap)this).UpdateLinkedData(inValue);
            return retVal.UpdateLinkedDataResult;
        }

        public Task<UpdateLinkedDataResponse> UpdateLinkedDataAsync(
            TicketHeader TicketHeader,
            DataEntityType entityType,
            string dataList)
        {
            var inValue = new UpdateLinkedDataRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            inValue.dataList = dataList;
            return ((WebCrmApiSoap)this).UpdateLinkedDataAsync(inValue);
        }

        public WriteCollectionToWebCrmResult WriteCollectionToWebcrm(
            TicketHeader TicketHeader,
            DataEntityType entityType,
            WebCrmDataCollection collection)
        {
            var inValue = new WriteCollectionToWebcrmRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            inValue.collection = collection;
            WriteCollectionToWebcrmResponse retVal = ((WebCrmApiSoap)this).WriteCollectionToWebcrm(inValue);
            return retVal.WriteCollectionToWebcrmResult;
        }

        public Task<WriteCollectionToWebcrmResponse> WriteCollectionToWebcrmAsync(
            TicketHeader TicketHeader,
            DataEntityType entityType,
            WebCrmDataCollection collection)
        {
            var inValue = new WriteCollectionToWebcrmRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            inValue.collection = collection;
            return ((WebCrmApiSoap)this).WriteCollectionToWebcrmAsync(inValue);
        }

        public WriteCollectionToWebCrmResult WriteCollectionToWebcrmDirect(
            TicketHeader TicketHeader,
            DataEntityType entityType,
            WebCrmDataCollection collection)
        {
            var inValue = new WriteCollectionToWebcrmDirectRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            inValue.collection = collection;
            WriteCollectionToWebcrmDirectResponse retVal = ((WebCrmApiSoap)this).WriteCollectionToWebcrmDirect(inValue);
            return retVal.WriteCollectionToWebcrmDirectResult;
        }

        public Task<WriteCollectionToWebcrmDirectResponse> WriteCollectionToWebcrmDirectAsync(
            TicketHeader TicketHeader,
            DataEntityType entityType,
            WebCrmDataCollection collection)
        {
            var inValue = new WriteCollectionToWebcrmDirectRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            inValue.collection = collection;
            return ((WebCrmApiSoap)this).WriteCollectionToWebcrmDirectAsync(inValue);
        }

        public WritePossibleQuotationsResult WritePossibleQuotations(
            TicketHeader TicketHeader,
            PossibleQuotationData[] possibleQuotations)
        {
            var inValue = new WritePossibleQuotationsRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.possibleQuotations = possibleQuotations;
            WritePossibleQuotationsResponse retVal = ((WebCrmApiSoap)this).WritePossibleQuotations(inValue);
            return retVal.WritePossibleQuotationsResult;
        }

        public Task<WritePossibleQuotationsResponse> WritePossibleQuotationsAsync(
            TicketHeader TicketHeader,
            PossibleQuotationData[] possibleQuotations)
        {
            var inValue = new WritePossibleQuotationsRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.possibleQuotations = possibleQuotations;
            return ((WebCrmApiSoap)this).WritePossibleQuotationsAsync(inValue);
        }

        public WriteQuotationLinesResult WriteQuotationLines(TicketHeader TicketHeader, QuotationLine[] quotationLines)
        {
            var inValue = new WriteQuotationLinesRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.quotationLines = quotationLines;
            WriteQuotationLinesResponse retVal = ((WebCrmApiSoap)this).WriteQuotationLines(inValue);
            return retVal.WriteQuotationLinesResult;
        }

        public Task<WriteQuotationLinesResponse> WriteQuotationLinesAsync(
            TicketHeader TicketHeader,
            QuotationLine[] quotationLines)
        {
            var inValue = new WriteQuotationLinesRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.quotationLines = quotationLines;
            return ((WebCrmApiSoap)this).WriteQuotationLinesAsync(inValue);
        }

        public WriteToWebCrmResult WriteToWebcrm(
            TicketHeader TicketHeader,
            DataEntityType entityType,
            long organisationID,
            long recordID,
            WebCrmData data)
        {
            var inValue = new WriteToWebcrmRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            inValue.organisationID = organisationID;
            inValue.recordID = recordID;
            inValue.data = data;
            WriteToWebcrmResponse retVal = ((WebCrmApiSoap)this).WriteToWebcrm(inValue);
            return retVal.WriteToWebcrmResult;
        }

        public Task<WriteToWebcrmResponse> WriteToWebcrmAsync(
            TicketHeader TicketHeader,
            DataEntityType entityType,
            long organisationID,
            long recordID,
            WebCrmData data)
        {
            var inValue = new WriteToWebcrmRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            inValue.organisationID = organisationID;
            inValue.recordID = recordID;
            inValue.data = data;
            return ((WebCrmApiSoap)this).WriteToWebcrmAsync(inValue);
        }

        public WriteToWebCrmResult WriteToWebcrmDirect(
            TicketHeader TicketHeader,
            DataEntityType entityType,
            long organisationID,
            long recordID,
            WebCrmData data)
        {
            var inValue = new WriteToWebcrmDirectRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            inValue.organisationID = organisationID;
            inValue.recordID = recordID;
            inValue.data = data;
            WriteToWebcrmDirectResponse retVal = ((WebCrmApiSoap)this).WriteToWebcrmDirect(inValue);
            return retVal.WriteToWebcrmDirectResult;
        }

        public Task<WriteToWebcrmDirectResponse> WriteToWebcrmDirectAsync(
            TicketHeader TicketHeader,
            DataEntityType entityType,
            long organisationID,
            long recordID,
            WebCrmData data)
        {
            var inValue = new WriteToWebcrmDirectRequest();
            inValue.TicketHeader = TicketHeader;
            inValue.entityType = entityType;
            inValue.organisationID = organisationID;
            inValue.recordID = recordID;
            inValue.data = data;
            return ((WebCrmApiSoap)this).WriteToWebcrmDirectAsync(inValue);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        AuthenticateResponse WebCrmApiSoap.Authenticate(AuthenticateRequest request)
        {
            return Channel.Authenticate(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<AuthenticateResponse> WebCrmApiSoap.AuthenticateAsync(AuthenticateRequest request)
        {
            return Channel.AuthenticateAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        ChangeOrganisationForOpportunityResponse WebCrmApiSoap.ChangeOrganisationForOpportunity(
            ChangeOrganisationForOpportunityRequest request)
        {
            return Channel.ChangeOrganisationForOpportunity(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<ChangeOrganisationForOpportunityResponse> WebCrmApiSoap.ChangeOrganisationForOpportunityAsync(
            ChangeOrganisationForOpportunityRequest request)
        {
            return Channel.ChangeOrganisationForOpportunityAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        DeleteLinkedDataResponse WebCrmApiSoap.DeleteLinkedData(DeleteLinkedDataRequest request)
        {
            return Channel.DeleteLinkedData(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<DeleteLinkedDataResponse> WebCrmApiSoap.DeleteLinkedDataAsync(DeleteLinkedDataRequest request)
        {
            return Channel.DeleteLinkedDataAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        DeletePossibleQuotationsResponse WebCrmApiSoap.DeletePossibleQuotations(DeletePossibleQuotationsRequest request)
        {
            return Channel.DeletePossibleQuotations(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<DeletePossibleQuotationsResponse> WebCrmApiSoap.DeletePossibleQuotationsAsync(
            DeletePossibleQuotationsRequest request)
        {
            return Channel.DeletePossibleQuotationsAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        DeleteQuotationResponse WebCrmApiSoap.DeleteQuotation(DeleteQuotationRequest request)
        {
            return Channel.DeleteQuotation(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<DeleteQuotationResponse> WebCrmApiSoap.DeleteQuotationAsync(DeleteQuotationRequest request)
        {
            return Channel.DeleteQuotationAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        EndSessionResponse WebCrmApiSoap.EndSession(EndSessionRequest request)
        {
            return Channel.EndSession(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<EndSessionResponse> WebCrmApiSoap.EndSessionAsync(EndSessionRequest request)
        {
            return Channel.EndSessionAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        GetIpInfoResponse WebCrmApiSoap.GetIpInfo(GetIpInfoRequest request)
        {
            return Channel.GetIpInfo(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<GetIpInfoResponse> WebCrmApiSoap.GetIpInfoAsync(GetIpInfoRequest request)
        {
            return Channel.GetIpInfoAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        ReadDocumentResponse WebCrmApiSoap.ReadDocument(ReadDocumentRequest request)
        {
            return Channel.ReadDocument(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<ReadDocumentResponse> WebCrmApiSoap.ReadDocumentAsync(ReadDocumentRequest request)
        {
            return Channel.ReadDocumentAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        ReadFromWebcrmByDatesResponse WebCrmApiSoap.ReadFromWebcrmByDates(ReadFromWebcrmByDatesRequest request)
        {
            return Channel.ReadFromWebcrmByDates(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<ReadFromWebcrmByDatesResponse> WebCrmApiSoap.ReadFromWebcrmByDatesAsync(
            ReadFromWebcrmByDatesRequest request)
        {
            return Channel.ReadFromWebcrmByDatesAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        ReadFromWebcrmByDatesDirectResponse WebCrmApiSoap.ReadFromWebcrmByDatesDirect(
            ReadFromWebcrmByDatesDirectRequest request)
        {
            return Channel.ReadFromWebcrmByDatesDirect(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<ReadFromWebcrmByDatesDirectResponse> WebCrmApiSoap.ReadFromWebcrmByDatesDirectAsync(
            ReadFromWebcrmByDatesDirectRequest request)
        {
            return Channel.ReadFromWebcrmByDatesDirectAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        ReadFromWebcrmByIdResponse WebCrmApiSoap.ReadFromWebcrmById(ReadFromWebcrmByIdRequest request)
        {
            return Channel.ReadFromWebcrmById(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<ReadFromWebcrmByIdResponse> WebCrmApiSoap.ReadFromWebcrmByIdAsync(ReadFromWebcrmByIdRequest request)
        {
            return Channel.ReadFromWebcrmByIdAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        ReadFromWebcrmByIdDirectResponse WebCrmApiSoap.ReadFromWebcrmByIdDirect(ReadFromWebcrmByIdDirectRequest request)
        {
            return Channel.ReadFromWebcrmByIdDirect(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<ReadFromWebcrmByIdDirectResponse> WebCrmApiSoap.ReadFromWebcrmByIdDirectAsync(
            ReadFromWebcrmByIdDirectRequest request)
        {
            return Channel.ReadFromWebcrmByIdDirectAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        ReadLinkedDataResponse WebCrmApiSoap.ReadLinkedData(ReadLinkedDataRequest request)
        {
            return Channel.ReadLinkedData(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<ReadLinkedDataResponse> WebCrmApiSoap.ReadLinkedDataAsync(ReadLinkedDataRequest request)
        {
            return Channel.ReadLinkedDataAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        ReadPossibleQuotationsResponse WebCrmApiSoap.ReadPossibleQuotations(ReadPossibleQuotationsRequest request)
        {
            return Channel.ReadPossibleQuotations(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<ReadPossibleQuotationsResponse> WebCrmApiSoap.ReadPossibleQuotationsAsync(
            ReadPossibleQuotationsRequest request)
        {
            return Channel.ReadPossibleQuotationsAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        ReadQuotationLinesResponse WebCrmApiSoap.ReadQuotationLines(ReadQuotationLinesRequest request)
        {
            return Channel.ReadQuotationLines(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<ReadQuotationLinesResponse> WebCrmApiSoap.ReadQuotationLinesAsync(ReadQuotationLinesRequest request)
        {
            return Channel.ReadQuotationLinesAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        RetrieveByQueryResponse WebCrmApiSoap.RetrieveByQuery(RetrieveByQueryRequest request)
        {
            return Channel.RetrieveByQuery(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<RetrieveByQueryResponse> WebCrmApiSoap.RetrieveByQueryAsync(RetrieveByQueryRequest request)
        {
            return Channel.RetrieveByQueryAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        ReturnAllFieldDescriptionResponse WebCrmApiSoap.ReturnAllFieldDescription(
            ReturnAllFieldDescriptionRequest request)
        {
            return Channel.ReturnAllFieldDescription(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<ReturnAllFieldDescriptionResponse> WebCrmApiSoap.ReturnAllFieldDescriptionAsync(
            ReturnAllFieldDescriptionRequest request)
        {
            return Channel.ReturnAllFieldDescriptionAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        ReturnAllUsersResponse WebCrmApiSoap.ReturnAllUsers(ReturnAllUsersRequest request)
        {
            return Channel.ReturnAllUsers(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<ReturnAllUsersResponse> WebCrmApiSoap.ReturnAllUsersAsync(ReturnAllUsersRequest request)
        {
            return Channel.ReturnAllUsersAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        ReturnFieldDescriptionResponse WebCrmApiSoap.ReturnFieldDescription(ReturnFieldDescriptionRequest request)
        {
            return Channel.ReturnFieldDescription(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<ReturnFieldDescriptionResponse> WebCrmApiSoap.ReturnFieldDescriptionAsync(
            ReturnFieldDescriptionRequest request)
        {
            return Channel.ReturnFieldDescriptionAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        ReturnUserDetailsResponse WebCrmApiSoap.ReturnUserDetails(ReturnUserDetailsRequest request)
        {
            return Channel.ReturnUserDetails(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<ReturnUserDetailsResponse> WebCrmApiSoap.ReturnUserDetailsAsync(ReturnUserDetailsRequest request)
        {
            return Channel.ReturnUserDetailsAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        SaveDocumentResponse WebCrmApiSoap.SaveDocument(SaveDocumentRequest request)
        {
            return Channel.SaveDocument(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<SaveDocumentResponse> WebCrmApiSoap.SaveDocumentAsync(SaveDocumentRequest request)
        {
            return Channel.SaveDocumentAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        SearchDeliveryResponse WebCrmApiSoap.SearchDelivery(SearchDeliveryRequest request)
        {
            return Channel.SearchDelivery(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<SearchDeliveryResponse> WebCrmApiSoap.SearchDeliveryAsync(SearchDeliveryRequest request)
        {
            return Channel.SearchDeliveryAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        SearchOpportunityResponse WebCrmApiSoap.SearchOpportunity(SearchOpportunityRequest request)
        {
            return Channel.SearchOpportunity(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<SearchOpportunityResponse> WebCrmApiSoap.SearchOpportunityAsync(SearchOpportunityRequest request)
        {
            return Channel.SearchOpportunityAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        SearchOrganisationResponse WebCrmApiSoap.SearchOrganisation(SearchOrganisationRequest request)
        {
            return Channel.SearchOrganisation(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<SearchOrganisationResponse> WebCrmApiSoap.SearchOrganisationAsync(SearchOrganisationRequest request)
        {
            return Channel.SearchOrganisationAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        SearchPersonResponse WebCrmApiSoap.SearchPerson(SearchPersonRequest request)
        {
            return Channel.SearchPerson(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<SearchPersonResponse> WebCrmApiSoap.SearchPersonAsync(SearchPersonRequest request)
        {
            return Channel.SearchPersonAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        SearchQuotationDataResponse WebCrmApiSoap.SearchQuotationData(SearchQuotationDataRequest request)
        {
            return Channel.SearchQuotationData(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<SearchQuotationDataResponse> WebCrmApiSoap.SearchQuotationDataAsync(SearchQuotationDataRequest request)
        {
            return Channel.SearchQuotationDataAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        SearchQuotationIDResponse WebCrmApiSoap.SearchQuotationID(SearchQuotationIDRequest request)
        {
            return Channel.SearchQuotationID(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<SearchQuotationIDResponse> WebCrmApiSoap.SearchQuotationIDAsync(SearchQuotationIDRequest request)
        {
            return Channel.SearchQuotationIDAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        UpdateLinkedDataResponse WebCrmApiSoap.UpdateLinkedData(UpdateLinkedDataRequest request)
        {
            return Channel.UpdateLinkedData(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<UpdateLinkedDataResponse> WebCrmApiSoap.UpdateLinkedDataAsync(UpdateLinkedDataRequest request)
        {
            return Channel.UpdateLinkedDataAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        WriteCollectionToWebcrmResponse WebCrmApiSoap.WriteCollectionToWebcrm(WriteCollectionToWebcrmRequest request)
        {
            return Channel.WriteCollectionToWebcrm(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<WriteCollectionToWebcrmResponse> WebCrmApiSoap.WriteCollectionToWebcrmAsync(
            WriteCollectionToWebcrmRequest request)
        {
            return Channel.WriteCollectionToWebcrmAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        WriteCollectionToWebcrmDirectResponse WebCrmApiSoap.WriteCollectionToWebcrmDirect(
            WriteCollectionToWebcrmDirectRequest request)
        {
            return Channel.WriteCollectionToWebcrmDirect(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<WriteCollectionToWebcrmDirectResponse> WebCrmApiSoap.WriteCollectionToWebcrmDirectAsync(
            WriteCollectionToWebcrmDirectRequest request)
        {
            return Channel.WriteCollectionToWebcrmDirectAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        WritePossibleQuotationsResponse WebCrmApiSoap.WritePossibleQuotations(WritePossibleQuotationsRequest request)
        {
            return Channel.WritePossibleQuotations(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<WritePossibleQuotationsResponse> WebCrmApiSoap.WritePossibleQuotationsAsync(
            WritePossibleQuotationsRequest request)
        {
            return Channel.WritePossibleQuotationsAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        WriteQuotationLinesResponse WebCrmApiSoap.WriteQuotationLines(WriteQuotationLinesRequest request)
        {
            return Channel.WriteQuotationLines(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<WriteQuotationLinesResponse> WebCrmApiSoap.WriteQuotationLinesAsync(WriteQuotationLinesRequest request)
        {
            return Channel.WriteQuotationLinesAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        WriteToWebcrmResponse WebCrmApiSoap.WriteToWebcrm(WriteToWebcrmRequest request)
        {
            return Channel.WriteToWebcrm(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<WriteToWebcrmResponse> WebCrmApiSoap.WriteToWebcrmAsync(WriteToWebcrmRequest request)
        {
            return Channel.WriteToWebcrmAsync(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        WriteToWebcrmDirectResponse WebCrmApiSoap.WriteToWebcrmDirect(WriteToWebcrmDirectRequest request)
        {
            return Channel.WriteToWebcrmDirect(request);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        Task<WriteToWebcrmDirectResponse> WebCrmApiSoap.WriteToWebcrmDirectAsync(WriteToWebcrmDirectRequest request)
        {
            return Channel.WriteToWebcrmDirectAsync(request);
        }
    }
}