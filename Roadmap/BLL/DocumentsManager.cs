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

        public ItemsResult<Contract> GetContracts(PagingDefinition paging)
        {
            ItemsResult<Contract> res = new ItemsResult<Contract>();
            int total;
            int page = paging.Page;
               
            int contractId = db.DocumentsRepository.GetDocumentTypeIdByCode(DocumentTypes.CONTRACT);
            int actId = db.DocumentsRepository.GetDocumentTypeIdByCode(DocumentTypes.ACT);
            int agreementId = db.DocumentsRepository.GetDocumentTypeIdByCode(DocumentTypes.AGREEMENT);

            try
            {                
                IQueryable<Contract> data =
                    db.RoadmapRepository
                    .Get<rdm_documents>()
                    .Where(x => x.typeID == contractId)
                    .Select(x => new Contract() {
                        Id = x.id,
                        DocumentUrl = x.documentUrl,
                        ContractorFirstName = x.rdm_contractors.firstName,
                        ContractorLastname = x.rdm_contractors.lastName,
                        Date = x.date,
                        DocumentNumber = x.documentNumber,
                        Description = x.description,
                        Status = x.rdm_documentStatuses.name,
                        ActSCount = x.rdm_documents1.Where(item => item.typeID == actId).Count(),
                        AgreementsCount = x.rdm_documents1.Where(item => item.typeID == agreementId).Count()
                    });

                // TODO filter

                IOrderedQueryable<Contract> ordData;

                switch (paging.Sort)
                {
                    case "DocumentUrl": ordData = data.OrderBy(x => x.DocumentUrl, paging.Direction); break;
                    case "ContractorFirstName": ordData = data.OrderBy(x => x.ContractorFirstName, paging.Direction); break;
                    case "ContractorLastname": ordData = data.OrderBy(x => x.ContractorLastname, paging.Direction); break;
                    case "Date": ordData = data.OrderBy(x => x.Date, paging.Direction); break;
                    case "DocumentNumber": ordData = data.OrderBy(x => x.DocumentNumber, paging.Direction); break;
                    case "Description": ordData = data.OrderBy(x => x.Description, paging.Direction); break;
                    case "Status": ordData = data.OrderBy(x => x.Status, paging.Direction); break;
                    case "ActsCount": ordData = data.OrderBy(x => x.ActSCount, paging.Direction); break;
                    case "AgreementsCount": ordData = data.OrderBy(x => x.AgreementsCount, paging.Direction); break;
                    default: ordData = data.OrderBy(x => x.Id, paging.Direction); break;
                }

                res.Items = ordData.Paging(paging.PageSize, ref page, out total).ToList();
                res.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
                res.IsSuccess = false;
                res.Message = "Во время выполнения операции произошла ошибка";
            }

            return res;
        }

        public ItemsResult<rdm_documentStatuses> GetDocumentStatuses()
        {
            ItemsResult<rdm_documentStatuses> res = new ItemsResult<rdm_documentStatuses>();

            try
            {
                // TODO cache
                res.Items = db.RoadmapRepository.Get<rdm_documentStatuses>().ToList();
                res.IsSuccess = true;
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
                res.IsSuccess = false;
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