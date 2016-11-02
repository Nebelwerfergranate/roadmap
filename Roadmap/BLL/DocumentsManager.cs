using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Roadmap.DAL.Core;
using Roadmap.Models;
using Roadmap.DAL;
using Roadmap.Utils;
using Roadmap.Models.ViewModels;

namespace Roadmap.BLL
{
    public class DocumentsManager
    {
        private UnitOfWork db;

        public DocumentsManager(UnitOfWork db)
        {
            this.db = db;
        }

        public ItemsResult<Document> GetDocuments(PagingDefinition paging)
        {
            ItemsResult<Document> res = new ItemsResult<Document>();
            int total;
            int page = paging.Page;

            try
            {
                IQueryable<DocumentData> data = GetDocumentsData();

                //TODO filter

                IOrderedQueryable<DocumentData> ordData = GetOrderedDocumentData(data, paging);

                res.Items = ordData
                    .Paging(paging.PageSize, ref page, out total)
                    .Select(x => new Document
                    {
                        Id = x.Id,
                        DocumentUrl = x.DocumentUrl,
                        ContractorFirstName = x.ContractorFirstName,
                        ContractorLastname = x.ContractorLastname,
                        Date = x.Date,
                        DocumentNumber = x.DocumentNumber,
                        Description = x.Description,
                        Status = x.Status,
                        Type = x.Type
                    }).ToList();

                res.IsSuccess = true;
                res.PageSize = paging.PageSize;
                res.Page = page;
                res.Total = total;
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
                res.IsSuccess = false;
                res.Message = Debug.GetDefaultErrorMessage();
            }

            return res;
        }

        public ItemsResult<Contract> GetContracts(PagingDefinition paging)
        {
            ItemsResult<Contract> res = new ItemsResult<Contract>();
            int total;
            int page = paging.Page;              

            try
            {
                IQueryable<DocumentData> data = GetDocumentsData();

                int contractId = db.DocumentsRepository.GetDocumentTypeIdByCode(DocumentTypes.CONTRACT);
                data = data.Where(x => x.TypeId == contractId);

                // TODO filter

                IOrderedQueryable<DocumentData> ordData = GetOrderedDocumentData(data, paging);             
                
                res.Items = ordData
                    .Paging(paging.PageSize, ref page, out total)
                    .Select(x => new Contract
                    {
                        Id = x.Id,
                        DocumentUrl = x.DocumentUrl,
                        ContractorFirstName = x.ContractorFirstName,
                        ContractorLastname = x.ContractorLastname,
                        Date = x.Date,
                        DocumentNumber = x.DocumentNumber,
                        Description = x.Description,
                        Status = x.Status,
                        ActsCount = x.ActsCount,
                        AgreementsCount = x.AgreementsCount
                    }).ToList();

                res.IsSuccess = true;
                res.PageSize = paging.PageSize;
                res.Page = page;
                res.Total = total;
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
                res.IsSuccess = false;
                res.Message = Debug.GetDefaultErrorMessage();
            }

            return res;
        }

        public ItemsResult<Act> GetActs(PagingDefinition paging)
        {
            ItemsResult<Act> res = new ItemsResult<Act>();
            int total;
            int page = paging.Page;

            try
            {
                IQueryable<DocumentData> data = GetDocumentsData();

                int actId = db.DocumentsRepository.GetDocumentTypeIdByCode(DocumentTypes.ACT);
                data = data.Where(x => x.TypeId == actId);

                // TODO filter

                IOrderedQueryable<DocumentData> ordData = GetOrderedDocumentData(data, paging);

                res.Items = ordData
                    .Paging(paging.PageSize, ref page, out total)
                    .Select(x => new Act
                    {
                        Id = x.Id,
                        DocumentUrl = x.DocumentUrl,
                        ContractorFirstName = x.ContractorFirstName,
                        ContractorLastname = x.ContractorLastname,
                        Date = x.Date,
                        DocumentNumber = x.DocumentNumber,
                        Description = x.Description,
                        Status = x.Status,
                        ParentDocumentUrl = x.ParentDocumentUrl
                    }).ToList();

                res.IsSuccess = true;
                res.PageSize = paging.PageSize;
                res.Page = page;
                res.Total = total;
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                Debug.LogError(ex);
                res.Message = Debug.GetDefaultErrorMessage();
            }

            return res;
        }

        public ItemsResult<Agreement> GetAgreements(PagingDefinition paging)
        {
            ItemsResult<Agreement> res = new ItemsResult<Agreement>();
            int total;
            int page = paging.Page;

            try
            {
                IQueryable<DocumentData> data = GetDocumentsData();

                int agreementId = db.DocumentsRepository.GetDocumentTypeIdByCode(DocumentTypes.AGREEMENT);
                data = data.Where(x => x.TypeId == agreementId);

                // TODO filter

                IOrderedQueryable<DocumentData> ordData = GetOrderedDocumentData(data, paging);

                res.Items = ordData
                    .Paging(paging.PageSize, ref page, out total)
                    .Select(x => new Agreement
                    {
                        Id = x.Id,
                        DocumentUrl = x.DocumentUrl,
                        ContractorFirstName = x.ContractorFirstName,
                        ContractorLastname = x.ContractorLastname,
                        Date = x.Date,
                        DocumentNumber = x.DocumentNumber,
                        Description = x.Description,
                        Status = x.Status,
                        ParentDocumentUrl = x.ParentDocumentUrl
                    }).ToList();

                res.IsSuccess = true;
                res.PageSize = paging.PageSize;
                res.Page = page;
                res.Total = total;
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                Debug.LogError(ex);
                res.Message = Debug.GetDefaultErrorMessage();
            }

            return res;
        }

        private IQueryable<DocumentData> GetDocumentsData()
        {            
            int actId = db.DocumentsRepository.GetDocumentTypeIdByCode(DocumentTypes.ACT);
            int agreementId = db.DocumentsRepository.GetDocumentTypeIdByCode(DocumentTypes.AGREEMENT);

            return db.RoadmapRepository
                    .Get<rdm_documents>()                    
                    .Select(x => new DocumentData()
                    {
                        Id = x.id,
                        DocumentUrl = x.documentUrl,
                        ContractorFirstName = x.rdm_contractors.firstName,
                        ContractorLastname = x.rdm_contractors.lastName,
                        Date = x.date,
                        DocumentNumber = x.documentNumber,
                        Description = x.description,
                        Status = x.rdm_documentStatuses.name,
                        ActsCount = x.rdm_documents1.Where(item => item.typeID == actId).Count(),
                        AgreementsCount = x.rdm_documents1.Where(item => item.typeID == agreementId).Count(),
                        ParentDocumentUrl = x.rdm_documents2 != null ? x.rdm_documents2.documentUrl : "",
                        Type = x.rdm_documentTypes.name,
                        TypeId = x.rdm_documentTypes.id                        
                    });
        }

        private IOrderedQueryable<DocumentData> GetOrderedDocumentData(IQueryable<DocumentData> data, PagingDefinition paging)
        {
            IOrderedQueryable<DocumentData> res;

            switch (paging.Sort)
            {
                case "ContractorFirstName": res = data.OrderBy(x => x.ContractorFirstName, paging.Direction); break;
                case "ContractorLastname": res = data.OrderBy(x => x.ContractorLastname, paging.Direction); break;
                case "Date": res = data.OrderBy(x => x.Date, paging.Direction); break;
                case "DocumentNumber": res = data.OrderBy(x => x.DocumentNumber, paging.Direction); break;
                case "Description": res = data.OrderBy(x => x.Description, paging.Direction); break;
                case "Status": res = data.OrderBy(x => x.Status, paging.Direction); break;
                case "ActsCount": res = data.OrderBy(x => x.ActsCount, paging.Direction); break;
                case "AgreementsCount": res = data.OrderBy(x => x.AgreementsCount, paging.Direction); break;
                case "Type": res = data.OrderBy(x => x.Type, paging.Direction); break;
                default: res = data.OrderBy(x => x.Id, paging.Direction); break;
            }

            return res;
        }
    }

    public static class DocumentStatuses
    {
        public const string CREATED = "created"; // создан
        public const string APPROVEMENT = "approvement"; // на согласовании
        public const string SIGNED = "signed"; // подписан
        public const string RECIEVED = "recieved"; // получена утверждённая копия
    }

    public static class DocumentTypes
    {
        public const string CONTRACT = "contract"; // договор
        public const string ACT = "act"; // акт
        public const string AGREEMENT = "supplementaryAgreement"; // дополнительное соглашение
    }
}